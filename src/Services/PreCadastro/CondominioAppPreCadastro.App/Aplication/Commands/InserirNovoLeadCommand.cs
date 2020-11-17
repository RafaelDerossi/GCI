using CondominioApp.Core.Messages;
using CondominioAppPreCadastro.App.ViewModel;
using FluentValidation;
using System.Collections.Generic;

namespace CondominioAppPreCadastro.App.Aplication.Commands
{
    public class InserirNovoLeadCommand : Command
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public int Plano { get; private set; }

        public int StatusPreCadastro { get; private set; }

        public string MotivoStatus { get; private set; }

        public List<CondominioModel> Condominios { get; private set; }

        public InserirNovoLeadCommand(string nome, string email, string telefone, int plano, int statusPreCadastro,
            string motivoStatus, List<CondominioModel> condominios)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Plano = plano;
            StatusPreCadastro = statusPreCadastro;
            MotivoStatus = motivoStatus;
            Condominios = condominios;
        }

        public override bool EstaValido()
        {
            var result = new InserirNovoLeadValidation().Validate(this);
            return result.IsValid;
        }

        public class InserirNovoLeadValidation : AbstractValidator<InserirNovoLeadCommand>
        {
            public InserirNovoLeadValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Nome não pode ser vazio!");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .NotNull()
                    .EmailAddress().WithMessage("E-mail não é válido!")
                    .WithMessage("E-mail não pode ser vazio!");

                RuleFor(c => c.Telefone)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Telefone não pode ser vazio!");

                RuleForEach(c => c.Condominios).ChildRules(regra =>
                {
                    regra.RuleFor(c => c.nomeDoCondominio)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Nome do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.nomeDoSindico)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Nome do síndico não pode ser vazio!");

                    regra.RuleFor(c => c.emailDoSindico)
                        .NotNull()
                        .NotEmpty()
                        .EmailAddress().WithMessage("E-mail do síndico não é válido!")
                        .WithMessage("E-mail do síndico não pode ser vazio!");

                    regra.RuleFor(c => c.telefoneDoSindico)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Telefone do síndico não pode ser vazio!");


                    regra.RuleFor(c => c.logradouro)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("logradouro do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.numero)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Número do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.cep)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Cep do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.bairro)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Bairro do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.cidade)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Cidade do condomínio não pode ser vazio!");

                    regra.RuleFor(c => c.estado)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("Estado do condomínio não pode ser vazio!");

                });
            }
        }
    }
}