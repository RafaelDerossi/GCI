using System;
using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.ValueObjects;

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

        public void setUrl(Url url)
        {
            this.Url = url;
        }

        public void setNome(string nomeDoProduto)
        {
            if (string.IsNullOrEmpty(nomeDoProduto))
                return;

            Guarda.ValidarTamanho(nomeDoProduto, NomeMaximo);
            Nome = nomeDoProduto;
        }

        public void setChamada(string chamadaDoProduto)
        {
            if (string.IsNullOrEmpty(chamadaDoProduto))
                return;

            Guarda.ValidarTamanho(chamadaDoProduto, ChamadaMaximo);
            Chamada = chamadaDoProduto;
        }

        public void setDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                return;

            Guarda.ValidarTamanho(descricao, DescricaoMaximo);
            Descricao = descricao;
        }

        public void setEspecificacaoTecnica(string especificacaoTecnica)
        {
            if (string.IsNullOrEmpty(especificacaoTecnica))
                return;

            EspecificacaoTecnica = especificacaoTecnica;
        }

        public void AdicionarFotos(FotoDoProduto Foto)
        {
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

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome)) throw new DomainException("O Nome do produto não pode estar vazio!");
            if (string.IsNullOrEmpty(Descricao)) throw new DomainException("A descrição não pode estar vazia!");
            if (string.IsNullOrEmpty(Chamada)) throw new DomainException("A chamada não pode estar vazia!");
            if (ParceiroId == Guid.Empty) throw new DomainException("O Id do parceiro não pode estar vazio!");
        }
    }
}
