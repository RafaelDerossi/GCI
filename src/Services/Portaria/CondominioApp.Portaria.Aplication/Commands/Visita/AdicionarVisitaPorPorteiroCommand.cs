using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AdicionarVisitaPorPorteiroCommand : VisitaCommand
    {
        public AdicionarVisitaPorPorteiroCommand
            (string observacao, Guid visitanteId, TipoDeVisitante tipoDeVisitante,
             string nomeEmpresaVisitante, Guid condominioId, string nomeCondominio, Guid unidadeId,
             string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
             string placaVeiculo, string modeloVeiculo, string corVeiculo, Guid moradorId, string nomeMorador)
        {
            SetDataDeEntrada(DataHoraDeBrasilia.Get());            
            Observacao = observacao;            

            SetVisitanteId(visitanteId);
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

            ValidationResult = new AdicionarVisitaPorPorteiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarVisitaPorPorteiroCommandValidation : VisitaValidation<AdicionarVisitaPorPorteiroCommand>
        {
            public AdicionarVisitaPorPorteiroCommandValidation()
            {               
                ValidateObservacao();                
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
