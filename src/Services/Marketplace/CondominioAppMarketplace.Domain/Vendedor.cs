using System;
using System.Collections.Generic;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.ValueObjects;

namespace CondominioAppMarketplace.Domain
{
    public class Vendedor : Entity
    {
        public const int NomeMaximo = 150;

        public string Nome { get; private set; }

        public Email Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public Telefone Telefone { get; private set; }

        public Endereco Endereco { get; private set; }

        public Guid ParceiroId { get; private set; }

        public Parceiro Parceiro { get; private set; }

        public ICollection<ItemDeVenda> ItensDeVenda { get; private set; }

        protected Vendedor() { }
        public Vendedor(string nome, Email email, Cpf cpf, Telefone telefone, Endereco endereco, Guid parceiroId)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            ParceiroId = parceiroId;

            Validar();
        }

        public void setNome(string nomeDoVendedor)
        {
            if (!string.IsNullOrEmpty(nomeDoVendedor))
                Nome = nomeDoVendedor;
        }

        public void setEmail(Email email)
        {
            Email = email;
        }

        public void setTelefone(TelefoneMovel telefone)
        {
            Telefone = telefone;
        }

        public void setEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome)) throw new DomainException("O Nome do vendedor não pode estar vazio!");
            if (Email == null) throw new DomainException("O Email não pode ser vazio!");
            if (Telefone == null) throw new DomainException("O Telefone não pode estar vazia!");
            if (ParceiroId == Guid.Empty) throw new DomainException("O Id do parceiro não pode estar vazio!");
        }

        public override bool Equals(object obj)
        {
            Vendedor vendedor = (Vendedor)obj;
            if (vendedor.Email.Endereco == Email.Endereco && vendedor.ParceiroId == ParceiroId)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
