using System;
using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Domain
{
    public class Parceiro : Entity, IAggregateRoot
    {
        public const int NomeCompletoMaximo = 150, NomeDoResponsavelMaximo = 150,
            DescricaoMaximo = 1000, LogoMarcaMaximo = 50, CorMaximo = 50;

        public string NomeCompleto { get; private set; }

        public string NomeDoResponsavel { get; private set; }

        public Email Email { get; private set; }

        public Telefone TelefoneFixo { get; private set; }

        public Telefone TelefoneCelular { get; private set; }

        public string Descricao { get; private set; }

        public string LogoMarca { get; private set; }

        public string Cor { get; private set; }

        public bool PreCadastro { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Endereco Endereco { get; private set; }

        public Contrato Contrato { get; private set; }

        private readonly List<Produto> _Produtos;
        public IReadOnlyCollection<Produto> Produtos => _Produtos;


        private readonly List<Vendedor> _Vendedores;
        public IReadOnlyCollection<Vendedor> Vendedores => _Vendedores;

        public string Nome
        {
            get
            {
                if (!string.IsNullOrEmpty(NomeCompleto))
                    return NomeCompleto.Split(" ")[0];

                return string.Empty;
            }
        }

        protected Parceiro() { }

        public Parceiro(string nomeCompleto, string descricao, Cnpj cnpj, Endereco endereco, 
            string nomeDoResponsavel, Email email, Telefone telefoneCelular, Telefone telefoneFixo, bool preCadastro = false, Contrato contrato = null, string logoMarca = null, string cor = null)
        {

            _Vendedores = new List<Vendedor>();

            _Produtos = new List<Produto>();

            NomeCompleto = nomeCompleto;
            NomeDoResponsavel = nomeDoResponsavel;
            TelefoneCelular = telefoneCelular;
            TelefoneFixo = telefoneFixo;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Cor = cor;
            Cnpj = cnpj;
            Endereco = endereco;
            Contrato = contrato;
            Email = email;
            LogoMarca = logoMarca;
            Cor = cor;

            if (preCadastro) AtivarPreCadastro();
        }

        public void AtivarPreCadastro() => PreCadastro = true;

        public void DesativarPreCadastro() => PreCadastro = false;
      
        public void LimparLogoMarca() => LogoMarca = null;
       
        public void setNomeDoResponsavel(string nome) => NomeDoResponsavel = nome;

        public void setTelefoneMovel(Telefone celular) => TelefoneCelular = celular;
        
        public void setTelefoneFixo(Telefone telefone) => TelefoneFixo = telefone;
        
        public void setEmail(Email email) => Email = email;
       
        public void setContrato(Contrato contrato) => Contrato = contrato;
       
        public void setEndereco(Endereco endereco) => Endereco = endereco;
       
        public void setNomeCompleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
        
        public void setCorDoLayout(string cor) => Cor = cor;
       
        public void setDescricao(string descricao) => Descricao = descricao;
        
        public void setLogoMarca(string logoMarca) => LogoMarca = logoMarca;
        
        public void setCnpj(Cnpj cnpj) => Cnpj = cnpj;
       
        public ValidationResult Contratar(Vendedor vendedor)
        {
            if (this.Vendedores.Any(x => x.Email.Endereco == vendedor.Email.Endereco))
            {
                AdicionarErrosDaEntidade("Vendedor já cadastrado para este parceiro!");
                return ValidationResult;
            }

            _Vendedores.Add(vendedor);

            return ValidationResult;
        }

        public ValidationResult Validar()
        {
            if (PreCadastro)
            {
               var ResultValidation = new ParceiroPrecadastroValidation().Validate(this);
                return ResultValidation;
            }

            var Result = new ParceiroValidation().Validate(this);
            return Result;
        }


        public class ParceiroPrecadastroValidation : AbstractValidator<Parceiro>
        {
            public ParceiroPrecadastroValidation()
            {
                RuleFor(c => c.NomeCompleto)
                    .NotEmpty()
                    .NotNull().WithMessage("O Nome do parceiro não pode estar vazio!");

                RuleFor(c => c.NomeDoResponsavel)
                    .NotEmpty()
                    .NotNull().WithMessage("O nome do responsável não pode estar vazio!");

                RuleFor(c => c.Email)
                    .NotNull()
                    .WithMessage("O e-mail não pode estar vazio!");

                RuleFor(c => c.Email.Endereco)
                    .NotNull()
                    .NotEmpty().WithMessage("O Email não pode ser vazio!")
                    .EmailAddress().WithMessage("Digite um e-mail válido!");

                RuleFor(c => c.Cnpj)
                    .NotNull()
                    .WithMessage("O CNPJ não pode estar vazio!");

                RuleFor(c => c.TelefoneCelular)
                    .NotNull()
                    .WithMessage("O telefone celular não pode estar vazio!");
            }
        }

        public class ParceiroValidation : AbstractValidator<Parceiro>
        {
            public ParceiroValidation()
            {
                RuleFor(c => c.NomeCompleto)
                    .NotEmpty()
                    .NotNull().WithMessage("O Nome do parceiro não pode estar vazio!");

                RuleFor(c => c.Descricao)
                    .NotEmpty()
                    .NotNull().WithMessage("A Descrição não pode estar vazia!");

                RuleFor(c => c.LogoMarca)
                    .NotEmpty()
                    .NotNull().WithMessage("A Logomarca não pode estar vazia!");

                RuleFor(c => c.Cor)
                    .NotEmpty()
                    .NotNull().WithMessage("A cor do layout não pode estar vazia!");

                RuleFor(c => c.NomeDoResponsavel)
                    .NotEmpty()
                    .NotNull().WithMessage("O nome do responsável não pode estar vazio!");

                RuleFor(c => c.Email)
                    .NotNull()
                    .WithMessage("O e-mail não pode estar vazio!");

                RuleFor(c => c.Email.Endereco)
                    .NotNull()
                    .NotEmpty().WithMessage("O Email não pode ser vazio!")
                    .EmailAddress().WithMessage("Digite um e-mail válido!");

                RuleFor(c => c.Contrato)
                    .NotNull()
                    .WithMessage("O Contrato não pode estar vazio!");

                RuleFor(c => c.Cnpj)
                    .NotNull()
                    .WithMessage("O CNPJ não pode estar vazio!");
            }
        }
    }
}
