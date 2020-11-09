using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Identidade.Api.Email;
using CondominioApp.Identidade.Api.Models;
using CondominioApp.WebApi.Core.Controllers;
using CondominioApp.WebApi.Core.Identidade;
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
        
        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
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

        [HttpPost("Esqueceu-senha")]
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

        [HttpPost("Alterar-senha")]
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


        [HttpPost("Nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = IdentityUserFactory(usuarioRegistro);

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                usuarioRegistro.UsuarioId = Guid.Parse(user.Id);

               await _userManager.AddClaimAsync(user, new Claim("TipoUsuario",
                    Enum.GetName(typeof(TipoDeUsuario), usuarioRegistro.TpUsuario)));

                //var usuarioResult = await RegistrarUsuario(usuarioRegistro);

                //if (!usuarioResult.ValidationResult.IsValid)
                //{
                //    await _userManager.DeleteAsync(user);
                //    return CustomResponse(usuarioResult.ValidationResult);
                //}

                var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastro(user, _appSettings.LinkConfirmacaoDeCadastro, usuarioRegistro.Nome));
                await DisparadorDeEmail.Disparar();

                return CustomResponse();
            }

            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("Autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
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

        private async Task<UsuarioRespostaLogin> GerarJwt(string login)
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

        private UsuarioRespostaLogin ObterRespostaToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);


        //private async Task<ValidationResult> CriarInscricaoDeUsuario(InscricaoModel Model)
        //{
        //    var Http = new HttpClient();

        //    Http.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", GerarJwt(Model.Email).Result.AccessToken);

        //    var conteudo = ObterConteudo(Model);


        //    var response = await Http.PostAsync("https://inscricoes.conect.studio/api/inscricao", conteudo);
           
        //    return await DeserializarObjetoResponse<ValidationResult>(response);

        //}

        #region MétodosAuxiliares

        private IdentityUser IdentityUserFactory(UsuarioRegistro usuarioRegistro)
        {
            return new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };
        }
        #endregion
    }
}