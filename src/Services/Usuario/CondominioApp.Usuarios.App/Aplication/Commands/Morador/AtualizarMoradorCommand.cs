using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtualizarMoradorCommand : UsuarioCommand
    {

        public AtualizarMoradorCommand(Guid usuarioId, string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null,
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
            SetFoto(nomeOriginal);
        }
        
        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        

        public class AtualizarMoradorCommandValidation : UsuarioValidation<AtualizarMoradorCommand>
        {
            public AtualizarMoradorCommandValidation()
            {
                ValidateNome();
                ValidateEmail();
                ValidateId();
            }
        }
    }
}