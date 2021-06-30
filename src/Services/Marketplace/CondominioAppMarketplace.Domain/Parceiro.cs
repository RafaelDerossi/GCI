using System;
using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioAppMarketplace.Domain.ValueObjects;
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


        public CategoriaParceiro Categoria { get; set; }

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

        public Parceiro
            (string nomeCompleto, string descricao, string cnpj, string nomeDoResponsavel, 
             string email, string telefoneCelular, string telefoneFixo, string logoMarca, string cor,
             string logradouro, string complemento, string numero, string cep, string bairro,
             string cidade, string estado, DateTime dataInicio, DateTime dataRenovacao, string descricaoContrato,
             bool preCadastro, bool whatsApp, CategoriaParceiro categoria)
        {

            _Vendedores = new List<Vendedor>();

            _Produtos = new List<Produto>();

            NomeCompleto = nomeCompleto;
            NomeDoResponsavel = nomeDoResponsavel;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Cor = cor;            
            LogoMarca = logoMarca;
            Cor = cor;
            Categoria = categoria;

            SetTelefoneMovel(telefoneCelular, whatsApp);
            SetTelefoneFixo(telefoneFixo);
            SetCnpj(cnpj);
            SetEmail(email);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);
            SetContrato(dataInicio, dataRenovacao, descricaoContrato);

            if (preCadastro) AtivarPreCadastro();
        }

        public void AtivarPreCadastro() => PreCadastro = true;

        public void DesativarPreCadastro() => PreCadastro = false;
      
        public void LimparLogoMarca() => LogoMarca = null;
       
        public void setNomeDoResponsavel(string nome) => NomeDoResponsavel = nome;

        public void SetTelefoneMovel(string celular, bool whatsApp)
        {
            TelefoneCelular = new Telefone(celular, whatsApp);
            
        }

        public void SetTelefoneFixo(string telefone)
        {
            TelefoneFixo = new Telefone(telefone);
        }

        public void SetEmail(string email)
        {
            Email = new Email(email);
        }
       
        public void SetContrato(DateTime dataInicio, DateTime dataRenovacao, string descricao)
        {
            Contrato = new Contrato(dataInicio, dataRenovacao, descricao);
        }

        public void SetEndereco(string logradouro, string complemento, string numero, string cep, string bairro, string cidade, string estado)
        {
            Endereco = new Endereco(logradouro, complemento, numero, cep, bairro, cidade, estado);
        }
       
        public void setNomeCompleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
        
        public void setCorDoLayout(string cor) => Cor = cor;
       
        public void setDescricao(string descricao) => Descricao = descricao;
        
        public void setLogoMarca(string logoMarca) => LogoMarca = logoMarca;

        public void SetCnpj(string cnpj)
        {
            Cnpj = new Cnpj(cnpj);
        }

        public void SetCategoria(CategoriaParceiro categoria) => Categoria = categoria;


        public ValidationResult Contratar(Vendedor vendedor)
        {
            if (_Vendedores.Any(x => x.Email.Endereco == vendedor.Email.Endereco))
            {
                AdicionarErrosDaEntidade("Vendedor já cadastrado para este parceiro!");
                return ValidationResult;
            }

            vendedor.AssociarAoParceiro(this);

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
