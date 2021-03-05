using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarUsuarioCommand : UsuarioCommand
    {
        public CadastrarUsuarioCommand(Guid usuarioId, string nome, string sobrenome, string email,           
            string foto, string nomeOriginal, string rg, string cpf, string tel = null,
            string cel = null, string logradouro = null, string complemento = null, string numeroEndereco = null,
            string cep = null, string bairro = null, string cidade = null, string estado = null,
            DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;                

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

            ValidationResult = new CadastrarUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarUsuarioCommandValidation : UsuarioValidation<CadastrarUsuarioCommand>
        {
            public CadastrarUsuarioCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateSobrenome();
                ValidateEmail();                  
            }
        }

    }
}