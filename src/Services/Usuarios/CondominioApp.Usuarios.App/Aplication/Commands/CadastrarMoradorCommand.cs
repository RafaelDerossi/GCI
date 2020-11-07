using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using FluentValidation;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMoradorCommand : Command
    {
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public Cpf Cpf { get; private set; }

        public Telefone Cel { get; private set; }

        public Email Email { get; private set; }

        public Foto Foto { get; private set; }

        public TipoDeUsuario TpUsuario { get; private set; }

        public Permissao Permissao { get; private set; }

        public DateTime? DataNascimento { get; private set; }

        public CadastrarMoradorCommand(string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null, string foto = null, 
            string nomeOriginal = null, DateTime? dataNascimento = null)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = TipoDeUsuario.CLIENTE;
            Permissao = Permissao.USUARIO;

            Cpf = new Cpf(cpf);
            Cel = new Telefone(cel);
            Email = new Email(email);
            Foto = new Foto(nomeOriginal, foto);
        }

        public override bool EstaValido()
        {
            var Result = new CadastroDeMoradorValidation().Validate(this);
            return Result.IsValid;
        }

        public class CadastroDeMoradorValidation : AbstractValidator<CadastrarMoradorCommand>
        {
            public CadastroDeMoradorValidation()
            {
                RuleFor(c => c.Nome)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Nome do morador não pode estar vazio!");

                RuleFor(c => c.Email.Endereco)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("E-mail do morador não pode estar vazio!");
            }
        }
    }
}