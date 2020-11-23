using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarResponsavelDaLojaCommand : UsuarioCommand
    {
        public CadastrarResponsavelDaLojaCommand(Guid usuarioId, string nome, string sobrenome, string email, 
            string cpf = null, string cel = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            SetCelular(cel);
            SetEmail(email);
            SetCpf(cpf);
        }

        public override bool EstaValido()
        {
            ValidationResult = new CadastrarResponsavelDaLojaValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarResponsavelDaLojaValidation : UsuarioValidation<CadastrarResponsavelDaLojaCommand>
        {
            public CadastrarResponsavelDaLojaValidation()
            {
                ValidateNome();
                ValidateEmail();
                ValidateId();
            }
        }
    }
}