using System;
using System.Collections.Generic;
using CondominioApp.Core.DomainObjects;
using CondominioAppMarketplace.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

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

        public Parceiro Parceiro { get; private set; }
        
        private readonly List<ItemDeVenda> _ItensDeVenda;

        public IReadOnlyCollection<ItemDeVenda> ItensDeVenda => _ItensDeVenda;

        protected Vendedor(){}

        public Vendedor(string nome, Email email, Cpf cpf, Telefone telefone, 
            Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;

            _ItensDeVenda = new List<ItemDeVenda>();
        }

        public void AssociarAoParceiro(Parceiro parceiro) => Parceiro = parceiro;

        public void setNome(string nomeDoVendedor)
        {
            if (!string.IsNullOrEmpty(nomeDoVendedor))
                Nome = nomeDoVendedor;
        }

        public void setEmail(Email email)
        {
            Email = email;
        }

        public void setTelefone(Telefone telefone) => Telefone = telefone;
       
        public void setEndereco(Endereco endereco) => Endereco = endereco;
       
        public override bool Equals(object obj)
        {
            Vendedor vendedor = (Vendedor)obj;
            if (vendedor.Email.Endereco == Email.Endereco && vendedor.Parceiro.Id == Parceiro.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ValidationResult Validar()
        {
            var Result = new VendedorValidation().Validate(this);
            return Result;
        }

        public class VendedorValidation : AbstractValidator<Vendedor>
        {
            public VendedorValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Nome do vendedor não pode estar vazio!");

                RuleFor(c => c.Email)
                    .NotNull()
                    .WithMessage("O Email não pode ser vazio!");

                RuleFor(c => c.Email.Endereco)
                    .NotNull()
                    .NotEmpty().WithMessage("O Email não pode ser vazio!")
                    .EmailAddress().WithMessage("Digite um e-mail válido!");

                RuleFor(c => c.Telefone)
                    .NotNull()
                    .NotEmpty().WithMessage("O Telefone não pode ser vazio!");
            }
        }
    }
}
