using System;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.ValueObjects;

namespace CondominioAppMarketplace.Domain
{
    public class Lead : Entity, IAggregateRoot
    {
        public const int NomeDoCondominioMaximo = 150, NomeDoClienteMaximo = 150, BlocoMaximo = 150, UnidadeMaximo = 50, ObservacaoMaxmo = 300;

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

            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NomeDoCondominio)) throw new DomainException("O Nome do condominio do lead não pode estar vazio!");
            if (string.IsNullOrEmpty(NomeDoCliente)) throw new DomainException("O Nome do cliente do lead não pode estar vazio!");
            if (string.IsNullOrEmpty(Bloco)) throw new DomainException("O Bloco no lead não pode estar vazio!");
            if (string.IsNullOrEmpty(Unidade)) throw new DomainException("A Unidade no lead não pode estar vazio!");
            if (Telefone == null) throw new DomainException("O Telefone do cliente no lead não pode estar vazio!");
            if (EmailDoCliente == null) throw new DomainException("O E-mail do cliente no lead não pode estar vazio!");
            if (ItemDeVendaId == Guid.Empty) throw new DomainException("O Id do item de venda no lead não pode estar vazio!");
        }
    }
}
