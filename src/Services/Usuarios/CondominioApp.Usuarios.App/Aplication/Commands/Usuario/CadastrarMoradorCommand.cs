using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMoradorCommand : UsuarioCommand
    {
        public CadastrarMoradorCommand(Guid usuarioId, string nome, string sobrenome, string email,
            Guid condominioId, string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, string foto, string nomeOriginal, string rg = null, string cpf = null,
            string tel = null, string cel = null, bool proprietario = false, bool principal = false, 
            string logradouro = null, string complemento = null, string numeroEndereco = null,
            string cep = null, string bairro = null, string cidade = null, string estado = null,
            DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = TipoDeUsuario.MORADOR;
            Permissao = Permissao.USUARIO;

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            
            Proprietario = proprietario;
            Principal = principal;

            SetCpf(cpf);
            SetCelular(cel);
            SetTelefone(tel);
            SetEmail(email);
            SetFoto(foto, nomeOriginal);
            SetEndereco(logradouro, complemento, numeroEndereco, cep, bairro, cidade, estado);

        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarMoradorCommandValidation : UsuarioValidation<CadastrarMoradorCommand>
        {
            public CadastrarMoradorCommandValidation()
            {
                ValidateId();
                ValidateCondominioId();
                ValidateUnidadeId();
                ValidateNome();
                ValidateSobrenome();
                ValidateEmail();                      
            }
        }

    }
}