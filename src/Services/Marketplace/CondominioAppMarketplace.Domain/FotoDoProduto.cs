using System;
using System.IO;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Domain
{
    public class FotoDoProduto : Entity
    {
        public const int NomeOriginalMaximo = 50, NomeArquivoMaximo = 50, ExtensaoMaximo = 10;

        public string NomeOriginal { get; private set; }

        public string NomeArquivo { get; private set; }

        public string Extensao { get; private set; }

        public bool Principal { get; private set; }

        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        protected FotoDoProduto() { }

        public FotoDoProduto(string nomeOriginal, bool principal, string nomeDoArquivo = null)
        {
            NomeOriginal = nomeOriginal;
            NomeArquivo = nomeDoArquivo;
            Principal = principal;

            setExtensao();
        }

        public void AssociarFotoAoProduto(Produto produto) => Produto = produto;

        public void MarcarComoPrincipal() => Principal = true;

        public void DesmarcarPrincipal() => Principal = false;

        public void setNomeOriginal(string nomeOriginal)
        {
            if (!string.IsNullOrEmpty(nomeOriginal))
                if (nomeOriginal.Contains("http:"))
                {
                    NomeArquivo = nomeOriginal;
                    NomeOriginal = nomeOriginal;
                }
                else
                    NomeOriginal = nomeOriginal;
        }

        public void setNomeArquivo(string nomeDoArquivo)
        {
            if (!string.IsNullOrEmpty(nomeDoArquivo))
                NomeArquivo = nomeDoArquivo;
        }

        public void setExtensao()
        {
            if (string.IsNullOrEmpty(NomeArquivo) || NomeArquivo.Contains("http:")) return;

            string[] arrExt = { ".jpg", ".jpeg", ".png", ".gif" };

            if (arrExt.Any(x => Path.GetExtension(NomeOriginal) == null)) return;

            Extensao = Path.GetExtension(NomeOriginal);
        }

        public ValidationResult Validar()
        {
            var Result = new FotoDoProdutoValidation().Validate(this);

            return Result;
        }

        public class FotoDoProdutoValidation : AbstractValidator<FotoDoProduto>
        {
            public FotoDoProdutoValidation()
            {
                RuleFor(c => c.NomeOriginal)
                    .NotEmpty()
                    .NotNull().WithMessage("O Nome original da foto não pode estar vazio!");

                RuleFor(c => c.NomeArquivo)
                    .NotEmpty()
                    .NotNull().WithMessage("O Nome do Arquivo da foto não pode estar vazio!");

                RuleFor(c => c.ProdutoId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O Id do produto não pode estar vazio!");
            }
        }
    }
}