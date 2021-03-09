using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarUsuarioCommand : UsuarioCommand
    {

        public EditarUsuarioCommand(Guid usuarioId, string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null, string foto = null,
            string nomeOriginal = null, DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;
            
            Permissao = Permissao.USUARIO;

            SetCpf(cpf);
            SetCelular(cel);
            SetEmail(email);
            SetFoto(foto, nomeOriginal);
        }
        
        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        

        public class EditarUsuarioCommandValidation : UsuarioValidation<EditarUsuarioCommand>
        {
            public EditarUsuarioCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateEmail();                
            }
        }
    }
}