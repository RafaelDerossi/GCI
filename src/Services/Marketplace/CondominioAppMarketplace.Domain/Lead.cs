using System;
using CondominioApp.Core.DomainObjects;
using CondominioAppMarketplace.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Domain
{
    public class Lead : Entity, IAggregateRoot
    {
        public const int NomeDoCondominioMaximo = 150, NomeDoClienteMaximo = 150, BlocoMaximo = 150, 
            UnidadeMaximo = 50, ObservacaoMaxmo = 300;

        public string NomeDoCondominio { get; private set; }

        public string NomeDoCliente { get; private set; }

        public string Bloco { get; private set; }

        public string Unidade { get; private set; }

        public string Observacao { get; private set; }

        public Telefone Telefone { get; private set; }

        public Email EmailDoCliente { get; private set; }

        public Guid ItemDeVendaId { get; private set; }

        public ItemDeVenda ItemDeVenda { get; private set; }

        protected Lead() { }

        public Lead(string nomeDoCondominio, string nomeDoCliente, string bloco, string unidade, string observacao,
            Telefone telefone, Email emailDoCliente, Guid itemDeVendaId)
        {
            NomeDoCondominio = nomeDoCondominio;
            NomeDoCliente = nomeDoCliente;
            Bloco = bloco;
            Unidade = unidade;
            Observacao = observacao;
            Telefone = telefone;
            EmailDoCliente = emailDoCliente;
            ItemDeVendaId = itemDeVendaId;
        }

        public ValidationResult Validar()
        {
            var Resultado = new LeadValidation().Validate(this);

            return Resultado;
        }

        public class LeadValidation : AbstractValidator<Lead>
        {
            public LeadValidation()
            {
                RuleFor(c => c.NomeDoCondominio)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Nome do condominio do lead não pode estar vazio!");

                RuleFor(c => c.NomeDoCliente)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Nome do cliente do lead não pode estar vazio!");

                RuleFor(c => c.Bloco)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Bloco no lead não pode estar vazio!");

                RuleFor(c => c.Unidade)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A Unidade no lead não pode estar vazio!");

                RuleFor(c => c.Telefone)
                    .NotNull()
                    .WithMessage("O Telefone do cliente no lead não pode estar vazio!");

                RuleFor(c => c.EmailDoCliente)
                    .NotNull()
                    .WithMessage("O E-mail do cliente no lead não pode estar vazio!");

                RuleFor(c => c.ItemDeVendaId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O Id do item de venda no lead não pode estar vazio!");
            }
        }
    }
}
