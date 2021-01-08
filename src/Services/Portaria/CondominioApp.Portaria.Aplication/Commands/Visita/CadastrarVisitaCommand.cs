using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitaCommand : VisitaCommand
    {

        public CadastrarVisitaCommand
            (DateTime dataDeEntrada, string nomeCondomino, string observacao, StatusVisita status,
            Guid visitanteId, string nomeVisitante, TipoDeDocumento tipoDeDocumentoVisitante,
            string documentoVisitante, string emailVisitante, string fotoVisitante,
            string nomeOriginalFotoVisitante, string nomeEmpresaVisitante, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, bool temVeiculo, string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {            
            DataDeEntrada = dataDeEntrada;            
            NomeCondomino = nomeCondomino;
            Observacao = observacao;
            Status = status;
            VisitanteId = visitanteId;
            NomeVisitante = nomeVisitante;
            TipoDeDocumentoVisitante = tipoDeDocumentoVisitante;
            NomeEmpresaVisitante = nomeEmpresaVisitante;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;

            SetDocumentoVisitante(documentoVisitante);
            SetEmailVisitante(emailVisitante);
            SetFotoVisitante(nomeOriginalFotoVisitante, fotoVisitante);
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVisitaCommandValidation : VisitaValidation<CadastrarVisitaCommand>
        {
            public CadastrarVisitaCommandValidation()
            {
                ValidateNomeCondomino();
                ValidateObservacao();
                ValidateStatus();
                ValidateVisitanteId();
                ValidateNomeVisitante();
                ValidateTipoDeDocumentoVisitante();
                ValidateCondominioId();
                ValidateNomeCondominio();
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoUnidade();
                
            }
        }

    }
}
