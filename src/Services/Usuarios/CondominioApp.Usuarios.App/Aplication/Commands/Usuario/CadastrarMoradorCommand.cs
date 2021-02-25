using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMoradorCommand : UsuarioCommand
    {
        public CadastrarMoradorCommand(Guid usuarioId, string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null, string foto = null,
            string nomeOriginal = null, DateTime? dataNascimento = null,
            TipoDeUsuario tpUsuario = TipoDeUsuario.CLIENTE, Permissao permissao = Permissao.USUARIO)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = tpUsuario;
            Permissao = permissao;

            SetCpf(cpf);
            SetCelular(cel);
            SetEmail(email);
            SetFoto(foto, nomeOriginal);
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
                ValidateNome();
                ValidateEmail();
                ValidateId();                
            }
        }

    }
}