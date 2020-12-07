using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class GerarExcelCorrespondenciaCommand : Command
    {
        public List<Guid> ListaCorrespondenciaId { get; set; }
       
        public string CaminhoRaiz { get; set; }

        public string NomeArquivo { get; set; }

        public GerarExcelCorrespondenciaCommand(
            List<Guid> condominioId, string caminhoRaiz, string nomeArquivo)
        {            
            ListaCorrespondenciaId = condominioId;
            CaminhoRaiz = caminhoRaiz;
            NomeArquivo = nomeArquivo;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new GerarExcelCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class GerarExcelCorrespondenciaCommandValidation: AbstractValidator<GerarExcelCorrespondenciaCommand>
        {  
            protected void ValidateListaCorrespondenciaId()
            {
                RuleFor(c => c.ListaCorrespondenciaId)
                      .NotNull()
                      .NotEmpty()
                      .WithMessage("Lista de Correspondencias não pode estar vazio!");
            }

            protected void ValidateCaminhoRaiz()
            {
                RuleFor(c => c.CaminhoRaiz)
                      .NotNull()
                      .NotEmpty()
                      .WithMessage("Caminho Raiz não pode estar vazio!");
            }

            protected void ValidateNomeArquivo()
            {
                RuleFor(c => c.NomeArquivo)
                      .NotNull()
                      .NotEmpty()
                      .WithMessage("Nome do Arquivo não pode estar vazio!");
            }

            public GerarExcelCorrespondenciaCommandValidation()
            {
                ValidateListaCorrespondenciaId();
                ValidateCaminhoRaiz();
                ValidateNomeArquivo();
            }

        }
    }
}
