using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AdicionarUsuarioCommand : UsuarioCommand
    {
        public AdicionarUsuarioCommand(Guid usuarioId, string nome, string sobrenome, string email,           
            string nomeOriginalFoto, string rg, string cpf, string tel = null,
            string cel = null, string logradouro = null, string complemento = null, string numeroEndereco = null,
            string cep = null, string bairro = null, string cidade = null, string estado = null,
            DateTime? dataNascimento = null, bool enviarEmailDeConfirmacao = true)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;
            EnviarEmailDeConfirmacao = enviarEmailDeConfirmacao;

            SetCpf(cpf);
            SetCelular(cel);
            SetTelefone(tel);
            SetEmail(email);
            SetFoto(nomeOriginalFoto);
            SetEndereco(logradouro, complemento, numeroEndereco, cep, bairro, cidade, estado);

        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarUsuarioCommandValidation : UsuarioValidation<AdicionarUsuarioCommand>
        {
            public AdicionarUsuarioCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateSobrenome();
                ValidateEmail();                  
            }
        }

    }
}