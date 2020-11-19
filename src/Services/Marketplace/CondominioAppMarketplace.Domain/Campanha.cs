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

        public bool TodosOsCondominios { get; private set; }

        public int NumeroDeCliques { get; private set; }

        public Guid ItemDeVendaId { get; private set; }

        public ItemDeVenda ItemDeVenda { get; private set; }

        protected Campanha() { }

        public Campanha(string titulo, string descricao, string banner, DateTime dataDeInicio, DateTime dataDeFim,
            bool todosOsCondominios, Guid itemDeVendaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Banner = banner;
            TodosOsCondominios = todosOsCondominios;
            ItemDeVendaId = itemDeVendaId;

            ConfigurarIntervalo(dataDeInicio, dataDeFim);
            Validar();
        }

        public void ContaCliques() => NumeroDeCliques++;

        public void Desativar() => Ativo = false;

        public void Ativar() => Ativo = true;

        public void HabilitarTodosOsCondominios() => TodosOsCondominios = true;

        public void DesabilitarTodosOsCondominios() => TodosOsCondominios = false;

        public void setTitulo(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo))
                Titulo = titulo;
        }

        public void setDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                Descricao = descricao;
        }

        public void setBanner(string banner)
        {
            if (!string.IsNullOrEmpty(banner))
                Banner = banner;
        }

        public void ConfigurarIntervalo(DateTime dataDeInicio, DateTime dataDeFim)
        {
            if (dataDeInicio != null && dataDeFim != null)
            {
                if (dataDeFim < dataDeInicio)
                    throw new DomainException("Data de início da campanha não pode ser maior que a de fim");

                DataDeInicio = dataDeInicio;
                DataDeFim = dataDeFim;
            }
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

                RuleFor(c => c.ItemDeVendaId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O Id do Item de venda da campanha não pode estar vazio!");
            }
        }
    }
}
