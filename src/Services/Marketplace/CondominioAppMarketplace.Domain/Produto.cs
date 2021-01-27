using System;
using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioAppMarketplace.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public const int NomeMaximo = 50, DescricaoMaximo = 1000, ChamadaMaximo = 85, LinkMaximo = 250;

        public string Nome { get; private set; }

        public string Descricao { get; set; }

        public string Chamada { get; private set; }

        public string EspecificacaoTecnica { get; private set; }

        public bool Ativo { get; private set; }

        public Url Url { get; private set; }

        public Guid ParceiroId { get; private set; }
        public Parceiro Parceiro { get; private set; }

        public ICollection<FotoDoProduto> Fotos { get; private set; }

        public ICollection<ItemDeVenda> ItensDeVenda { get; private set; }

        public bool EVisualizacaoDaWeb
        {
            get
            {
                if (Url != null && !string.IsNullOrEmpty(Url.Endereco))
                    return true;
                return false;
            }
        }

        public FotoDoProduto FotoPrincipal
        {
            get
            {
                if (Fotos != null)
                    return Fotos.FirstOrDefault(x => x.Principal);

                return null;
            }
        }

        protected Produto() { }

        public Produto(string nome, string descricao, string chamada, string especificacaoTecnica, Url url, Guid parceiroId)
        {
            this.Fotos = new List<FotoDoProduto>();

            setNome(nome);
            setDescricao(descricao);
            setChamada(chamada);
            setEspecificacaoTecnica(especificacaoTecnica);
            Ativar();

            Url = url;
            ParceiroId = parceiroId;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void setUrl(Url url) => Url = url;
        
        public void setNome(string nomeDoProduto)
        {
            if (string.IsNullOrEmpty(nomeDoProduto))
                return;

            Guarda.ValidarTamanhoMaximo(nomeDoProduto, NomeMaximo);
            Nome = nomeDoProduto;
        }

        public void setChamada(string chamadaDoProduto) => Chamada = chamadaDoProduto;
       
        public void setDescricao(string descricao) => Descricao = descricao;
        
        public void setEspecificacaoTecnica(string especificacaoTecnica) => EspecificacaoTecnica = especificacaoTecnica;
       
        public void AdicionarFotos(FotoDoProduto Foto)
        {
            Foto.AssociarFotoAoProduto(this);
            Fotos.Add(Foto);
        }

        public void MarcarPrimeiraFotoPrincipal()
        {
            if (Fotos.Count > 0)
                Fotos.FirstOrDefault().MarcarComoPrincipal();
        }

        public void MarcarFotoPrincipal(Guid FotoDoProdutoId)
        {
            foreach (var Foto in Fotos)
                Foto.DesmarcarPrincipal();

            Fotos.FirstOrDefault(x => x.Id == FotoDoProdutoId).MarcarComoPrincipal();
        }

        public ValidationResult Validar()
        {
            var Result = new ProdutoValidation().Validate(this);

            return Result;
        }

        public class ProdutoValidation : AbstractValidator<Produto>
        {
            public ProdutoValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Nome do produto não pode estar vazio!");

                RuleFor(c => c.Descricao)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A descrição não pode estar vazia!");

                RuleFor(c => c.Chamada)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A chamada não pode estar vazia!");

                RuleFor(c => c.ParceiroId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O Id do parceiro não pode estar vazio!");
            }
        }
    }
}
