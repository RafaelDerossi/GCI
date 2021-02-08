using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarMoradorCommand : UsuarioCommand
    {

        public EditarMoradorCommand(Guid usuarioId, string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null, string foto = null,
            string nomeOriginal = null, DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = TipoDeUsuario.CLIENTE;
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

            ValidationResult = new EditarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        

        public class EditarMoradorCommandValidation : UsuarioValidation<EditarMoradorCommand>
        {
            public EditarMoradorCommandValidation()
            {
                ValidateNome();
                ValidateEmail();
                ValidateId();
            }
        }
    }
}