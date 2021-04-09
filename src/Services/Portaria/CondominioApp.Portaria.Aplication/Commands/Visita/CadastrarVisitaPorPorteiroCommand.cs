using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitaPorPorteiroCommand : VisitaCommand
    {
        public CadastrarVisitaPorPorteiroCommand
            (string observacao, StatusVisita status,
             Guid visitanteId, string nomeVisitante, TipoDeDocumento tipoDeDocumentoVisitante,
             string documentoVisitante, string emailVisitante,
             string fotoVisitante, string nomeOriginalFotoVisitante,TipoDeVisitante tipoDeVisitante,
             string nomeEmpresaVisitante, Guid condominioId, string nomeCondominio, Guid unidadeId,
             string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
             string placaVeiculo, string modeloVeiculo, string corVeiculo, Guid moradorId, string nomeMorador)
        {
            SetDataDeEntrada(DataHoraDeBrasilia.Get());            
            Observacao = observacao;
            Status = status;

            SetVisitanteId(visitanteId);
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documentoVisitante, tipoDeDocumentoVisitante);
            SetEmailVisitante(emailVisitante);
            SetFotoVisitante(nomeOriginalFotoVisitante, fotoVisitante);          
            SetTipoDeVisitante(tipoDeVisitante);
            SetNomeEmpresaVisitante(nomeEmpresaVisitante);

            SetCondominioId(condominioId);
            SetNomeDoCondominio(nomeCondominio);

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

            ValidationResult = new CadastrarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVisitaCommandValidation : VisitaValidation<CadastrarVisitaPorPorteiroCommand>
        {
            public CadastrarVisitaCommandValidation()
            {               
                ValidateObservacao();
                ValidateStatus();              
                ValidateNomeVisitante();
                ValidateTipoDeDocumentoVisitante();
                ValidateCondominioId();
                ValidateNomeCondominio();
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoUnidade();
                ValidateUnidadeId();
                ValidateNomeUsuario();
            }
        }

    }
}
