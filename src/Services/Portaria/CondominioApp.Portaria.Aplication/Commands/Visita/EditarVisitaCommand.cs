using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class EditarVisitaCommand : VisitaCommand
    {

        public EditarVisitaCommand
            (Guid id, string nomeCondomino, string nomeVisitante, string documentoVisitante,
            string emailVisitante, string fotoVisitante, string nomeOriginalFotoVisitante, 
            TipoDeVisitante tipoDeVisitante, string nomeEmpresaVisitante, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            Id = id;
            NomeCondomino = nomeCondomino;            
            NomeVisitante = nomeVisitante;
            SetTipoDeVisitante(tipoDeVisitante);
            SetNomeEmpresaVisitante(nomeEmpresaVisitante);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(grupoUnidade);
            TemVeiculo = temVeiculo;
            

            SetDocumentoVisitante(documentoVisitante);
            SetEmailVisitante(emailVisitante);
            SetFotoVisitante(nomeOriginalFotoVisitante, fotoVisitante);
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVisitaCommandValidation : VisitaValidation<EditarVisitaCommand>
        {
            public EditarVisitaCommandValidation()
            {
                ValidateNomeCondomino();                   
                ValidateNomeVisitante();
                ValidateTipoDeDocumentoVisitante();                
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoUnidade();
                
            }
        }

    }
}
