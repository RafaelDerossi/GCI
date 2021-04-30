using CondominioApp.Core.DomainObjects;
using System;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Domain
{
    public class Campanha : Entity, IAggregateRoot
    {
        public const int TituloMaximo = 100, DescricaoMaximo = 350, BannerMaximo = 50;

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Banner { get; private set; }

        public DateTime DataDeInicio { get; private set; }

        public DateTime DataDeFim { get; private set; }

        public bool Ativo { get; private set; }

        public int NumeroDeCliques { get; private set; }

        public Guid ItemDeVendaId { get; private set; }

        public ItemDeVenda ItemDeVenda { get; private set; }

        protected Campanha() { }

        public Campanha(string titulo, string descricao, string banner, DateTime dataDeInicio, DateTime dataDeFim, bool ativo, Guid itemDeVendaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Banner = banner;
            DataDeInicio = dataDeInicio;
            DataDeFim = dataDeFim;
            Ativo = ativo;
            ItemDeVendaId = itemDeVendaId;
        }

        public void AssociarAoItemDeVenda(ItemDeVenda itemDeVenda) => ItemDeVenda = itemDeVenda;

        public void ContaCliques() => NumeroDeCliques++;

        public void Desativar() => Ativo = false;

        public void Ativar() => Ativo = true;

        public void setTitulo(string titulo) => Titulo = titulo;

        public void setDescricao(string descricao) => Descricao = descricao;

        public void setBanner(string banner) => Banner = banner;

        public ValidationResult ConfigurarIntervalo(DateTime dataDeInicio, DateTime dataDeFim)
        {
            if (dataDeFim < dataDeInicio)
            {
                AdicionarErrosDaEntidade("Data de início da campanha não pode ser maior que a de fim");
                return ValidationResult;
            }
            
            DataDeInicio = dataDeInicio;
            DataDeFim = dataDeFim;

            return ValidationResult;
        }

        public ValidationResult Validar()
        {
            var Result = new CampanhaValidation().Validate(this);
            return Result;
        }

        public class CampanhaValidation : AbstractValidator<Campanha>
        {
            public CampanhaValidation()
            {
                RuleFor(c => c.Titulo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Titulo da campanha não pode estar vazio!");

                RuleFor(c => c.Banner)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Banner da campanha não pode estar vazio!");

                RuleFor(c => c.DataDeInicio)
                    .NotNull()
                    .WithMessage("O Data de fim da campanha não pode estar vazio!");

                RuleFor(c => c.DataDeFim)
                    .NotNull()
                    .WithMessage("O Data de fim da campanha não pode estar vazio!");

                RuleFor(c => c.DataDeFim)
                    .NotNull().WithMessage("Data de fim da campanha é obrigatória!")
                    .GreaterThan(m => m.DataDeInicio)
                    .WithMessage("Data de início da campanha deve ser menor que a de fim!");
            }
        }
    }
}
