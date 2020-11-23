using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using FluentValidation;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMoradorCommand : UsuarioCommand
    {
        public CadastrarMoradorCommand(Guid usuarioId, string nome, string sobrenome, string email,
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