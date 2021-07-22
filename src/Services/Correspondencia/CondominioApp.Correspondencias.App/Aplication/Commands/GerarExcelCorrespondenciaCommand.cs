using CondominioApp.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class GerarExcelCorrespondenciaCommand : Command
    {
        public List<Guid> ListaCorrespondenciaId { get; set; }

        public MemoryStream Ms { get; set; }

        public GerarExcelCorrespondenciaCommand(
            List<Guid> correspondenciaId, MemoryStream ms)
        {            
            ListaCorrespondenciaId = correspondenciaId;
            Ms = ms;
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
           

            public GerarExcelCorrespondenciaCommandValidation()
            {
                ValidateListaCorrespondenciaId();                
            }

        }
    }
}
