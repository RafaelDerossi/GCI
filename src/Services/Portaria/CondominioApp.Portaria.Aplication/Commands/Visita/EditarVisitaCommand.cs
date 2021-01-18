using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class EditarVisitaCommand : VisitaCommand
    {

        public EditarVisitaCommand
            (Guid id, string observacao, string nomeVisitante, string documentoVisitante, string emailVisitante,
            string fotoVisitante, string nomeOriginalFotoVisitante, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, bool temVeiculo, string placaVeiculo, string modeloVeiculo, string corVeiculo,
            Guid usuarioId, string nomeUsuario)
        {
            Id = id;
            Observacao = observacao;
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documentoVisitante);
            SetTipoDeVisitante(tipoDeVisitante);
            SetEmailVisitante(emailVisitante);
            SetFotoVisitante(nomeOriginalFotoVisitante, fotoVisitante);
            SetNomeEmpresaVisitante(nomeEmpresaVisitante);

            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(grupoUnidade);

            TemVeiculo = temVeiculo;           
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);

            SetUsuario(usuarioId, nomeUsuario);
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
                ValidateNomeVisitante();
                ValidateTipoDeDocumentoVisitante();                
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoUnidade();
                ValidateUsuarioId();
                ValidateNomeUsuario();
            }
        }

    }
}
