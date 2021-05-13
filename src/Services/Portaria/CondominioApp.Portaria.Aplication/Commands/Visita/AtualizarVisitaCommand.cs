using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AtualizarVisitaCommand : VisitaCommand
    {

        public AtualizarVisitaCommand
            (Guid id, string observacao, string nomeVisitante,TipoDeDocumento tipoDeDocumento, string documentoVisitante,
            string emailVisitante, string fotoVisitante, string nomeOriginalFotoVisitante, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, bool temVeiculo, string placaVeiculo, string modeloVeiculo, string corVeiculo,
            Guid moradorId, string nomeMorador)
        {
            Id = id;
            Observacao = observacao;
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documentoVisitante, tipoDeDocumento);
            SetTipoDeVisitante(tipoDeVisitante);
            SetEmailVisitante(emailVisitante);
            SetFotoVisitante(nomeOriginalFotoVisitante, fotoVisitante);
            SetNomeEmpresaVisitante(nomeEmpresaVisitante);

            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(grupoUnidade);
                           
            SetVeiculoPeloPorteiro(temVeiculo, placaVeiculo, modeloVeiculo, corVeiculo);

            SetMorador(moradorId, nomeMorador);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarVisitaCommandValidation : VisitaValidation<AtualizarVisitaCommand>
        {
            public AtualizarVisitaCommandValidation()
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
