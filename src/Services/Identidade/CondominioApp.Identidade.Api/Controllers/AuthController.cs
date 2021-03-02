using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.Identidade.Api.Email;
using CondominioApp.Identidade.Api.Models;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.WebApi.Core.Controllers;
using CondominioApp.WebApi.Core.Identidade;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CondominioApp.Identidade.Api.Controllers
{
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery;

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IMediatorHandler mediatorHandler,
                              ICondominioQuery condominioQuery)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
        }


        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> AtualizarSenha(Guid Id, UsuarioSenhaViewModel UsuarioSenhaModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = await _userManager.FindByIdAsync(UsuarioSenhaModel.Id);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, UsuarioSenhaModel.Senha);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return CustomResponse("Senha alterada com sucesso!");


            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }

        [HttpPost("esqueceu-senha")]
        public async Task<IActionResult> EsqueciASenha(UsuarioEsqueciSenhaViewModel UsuarioModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByEmailAsync(UsuarioModel.Email);
            if (user == null)
                return CustomResponse("Email não encontrado");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var disparadorEmail = new DisparadorDeEmails(new EmailRecuperarSenha(user, token, _appSettings.LinkRedefinirSenha));
            await disparadorEmail.Disparar();

            return CustomResponse();
        }

        [HttpPost("alterar-senha")]
        public async Task<IActionResult> AlterarSenha(UsuarioRedefinirSenhaViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = await _userManager.FindByEmailAsync(usuarioViewModel.Email);
            if (user == null)
                return CustomResponse("Usuário não encontrado");
            var resetPassResult = await _userManager.ResetPasswordAsync(user, usuarioViewModel.Token, usuarioViewModel.Senha);

            if (resetPassResult.Succeeded) return CustomResponse();

            foreach (var error in resetPassResult.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }
            return CustomResponse();
        }


        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistroDTO usuarioRegistroVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            
            var user = await _userManager.FindByEmailAsync(usuarioRegistroVM.Email);
            if (user != null)
                return await RegistrarMoradorExistente(usuarioRegistroVM, user);
            


            user = IdentityUserFactory(usuarioRegistroVM);
            var result = await _userManager.CreateAsync(user, usuarioRegistroVM.Senha);
            if (result.Succeeded)
                return await RegistrarUsuarioNovo(usuarioRegistroVM, user);

              

            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("nova-conta-morador")]
        public async Task<ActionResult> RegistrarMorador(MoradorRegistroViewModel moradorVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            
            var user = await _userManager.FindByEmailAsync(moradorVM.Email);
            if (user != null)
                return await RegistrarMoradorUsuarioExistente(moradorVM, user);



            user = IdentityUserFactory(moradorVM.Email);
            var result = await _userManager.CreateAsync(user, moradorVM.Senha);
            if (result.Succeeded)
                return await RegistrarMoradorUsuarioNovo(moradorVM, user);



            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("nova-identidade")]
        public async Task<IActionResult> NovaIdentidade(List<UsuarioDTO> dtos)
        {
            foreach (var dto in dtos)
            {
                var Useridentity = new IdentityUser
                {
                    Id = dto.Id.ToString(),
                    UserName = dto.Email,
                    Email = dto.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(Useridentity, "123456");

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(Useridentity, new Claim("TipoUsuario", TipoDeUsuario.LOJISTA.ToString()));
                }
            }

            return CustomResponse();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Login, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(usuarioLogin.Login));
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }
      
        private async Task<UsuarioRespostaLoginViewModel> GerarJwt(string login)
        {
            var user = await _userManager.FindByNameAsync(login);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private UsuarioRespostaLoginViewModel ObterRespostaToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            return new UsuarioRespostaLoginViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);




        #region MétodosAuxiliares

        private IdentityUser IdentityUserFactory(string email)
        {
            return new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };
        }

        private async Task<ActionResult> RegistrarMoradorUsuarioExistente(MoradorRegistroViewModel moradorVM, IdentityUser user)
        {
            moradorVM.UsuarioId = Guid.Parse(user.Id);

            var Resultado = await PersistirMorador(moradorVM);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            await AddClaimAsync(user, TipoDeUsuario.MORADOR);

            await EnviarEmailDeConfirmacaoDeCadastro(user, moradorVM.Nome);

            return CustomResponse();
        }
        private async Task<ActionResult> RegistrarMoradorUsuarioNovo(MoradorRegistroViewModel moradorVM, IdentityUser user)
        {
            moradorVM.UsuarioId = Guid.Parse(user.Id);

            var Resultado = await PersistirMorador(moradorVM);

            if (!Resultado.IsValid)
            {
                await _userManager.DeleteAsync(user);
                return CustomResponse(Resultado);
            }

            await AddClaimAsync(user, TipoDeUsuario.MORADOR);

            await EnviarEmailDeConfirmacaoDeCadastro(user, moradorVM.Nome);

            return CustomResponse();

        }       
        private async Task<ValidationResult> PersistirMorador(MoradorRegistroViewModel moradorVM)
        {
            var validatioResult = new ValidationResult();                        

            var condominio = await _condominioQuery.ObterPorId(moradorVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado");

                validatioResult.Errors.Add(new ValidationFailure("CondominioId", "Condominio não encontrado"));
                return validatioResult;
            }

            var unidade = await _condominioQuery.ObterUnidadePorId(moradorVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada");

                validatioResult.Errors.Add(new ValidationFailure("UnidadeId", "Unidade não encontrada"));
                return validatioResult;
            }


            var comando = CadastrarMoradorCommandFactory(moradorVM, condominio, unidade);

            validatioResult = await _mediatorHandler.EnviarComando(comando);
            return validatioResult;
        }
        private CadastrarMoradorCommand CadastrarMoradorCommandFactory(MoradorRegistroViewModel moradorVM,
            CondominioFlat condominio, UnidadeFlat unidade)
        {
            return new CadastrarMoradorCommand
                (moradorVM.UsuarioId, moradorVM.Nome, moradorVM.Sobrenome, moradorVM.Email,
                 moradorVM.CondominioId, condominio.Nome, moradorVM.UnidadeId, unidade.Numero,
                 unidade.Andar, unidade.GrupoDescricao, moradorVM.Foto, moradorVM.NomeOriginal,
                 moradorVM.Rg, moradorVM.Cpf, moradorVM.Telefone, moradorVM.Celular,
                 moradorVM.Proprietario, moradorVM.Principal,
                 moradorVM.Logradouro, moradorVM.Complemento, moradorVM.Numero,
                 moradorVM.Cep, moradorVM.Bairro, moradorVM.Cidade, moradorVM.Estado,
                 moradorVM.DataNascimento);
        }


        private async Task<ActionResult> RegistrarFuncionarioUsuarioExistente(MoradorRegistroViewModel moradorVM, IdentityUser user)
        {
            moradorVM.UsuarioId = Guid.Parse(user.Id);

            var Resultado = await PersistirMorador(moradorVM);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            await AddClaimAsync(user, TipoDeUsuario.MORADOR);

            await EnviarEmailDeConfirmacaoDeCadastro(user, moradorVM.Nome);

            return CustomResponse();
        }
        private async Task<ActionResult> RegistrarFuncionarioUsuarioNovo(MoradorRegistroViewModel moradorVM, IdentityUser user)
        {
            moradorVM.UsuarioId = Guid.Parse(user.Id);

            var Resultado = await PersistirMorador(moradorVM);

            if (!Resultado.IsValid)
            {
                await _userManager.DeleteAsync(user);
                return CustomResponse(Resultado);
            }

            await AddClaimAsync(user, TipoDeUsuario.MORADOR);

            await EnviarEmailDeConfirmacaoDeCadastro(user, moradorVM.Nome);

            return CustomResponse();

        }
        private async Task<ValidationResult> PersistirFuncionario(UsuarioRegistroDTO usuarioRegistroVM)
        {
            var validatioResult = new ValidationResult();            

            var condominio = await _condominioQuery.ObterPorId(usuarioRegistroVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado");

                validatioResult.Errors.Add(new ValidationFailure("CondominioId", "Condominio não encontrado"));
                return validatioResult;
            }           

            var comando = CadastrarFuncionarioCommandFactory(usuarioRegistroVM, condominio);

            validatioResult = await _mediatorHandler.EnviarComando(comando);
            return validatioResult;
        }
        private CadastrarFuncionarioCommand CadastrarFuncionarioCommandFactory(UsuarioRegistroDTO usuarioRegistro,
           CondominioFlat condominio)
        {
            return new CadastrarFuncionarioCommand
                (usuarioRegistro.UsuarioId, usuarioRegistro.Nome, usuarioRegistro.Sobrenome, usuarioRegistro.Email,
                 usuarioRegistro.CondominioId, condominio.Nome, usuarioRegistro.Foto, usuarioRegistro.NomeOriginal,
                 usuarioRegistro.Rg, usuarioRegistro.Cpf, usuarioRegistro.Celular, usuarioRegistro.Telefone,
                 usuarioRegistro.Atribuicao, usuarioRegistro.Funcao, usuarioRegistro.Logradouro, usuarioRegistro.Complemento,
                 usuarioRegistro.Numero, usuarioRegistro.Cep, usuarioRegistro.Bairro, usuarioRegistro.Cidade, usuarioRegistro.Estado,
                 usuarioRegistro.DataNascimento, usuarioRegistro.Permissao);
        }


        private async Task AddClaimAsync(IdentityUser user, TipoDeUsuario tipoDeUsuario)
        {
            await _userManager.AddClaimAsync(user, new Claim("TipoUsuario",
                 Enum.GetName(typeof(TipoDeUsuario), tipoDeUsuario)));
        }
        private async Task EnviarEmailDeConfirmacaoDeCadastro(IdentityUser user, string nomeUsuario)
        {
            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastro(user, _appSettings.LinkConfirmacaoDeCadastro, nomeUsuario));
            await DisparadorDeEmail.Disparar();
        }

       

        #endregion
    }
}