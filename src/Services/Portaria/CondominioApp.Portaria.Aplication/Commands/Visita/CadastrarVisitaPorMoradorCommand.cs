﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitaPorMoradorCommand : VisitaCommand
    {
        public CadastrarVisitaPorMoradorCommand
            (DateTime dataDeEntrada, string observacao, StatusVisita status,
            Guid visitanteId, Guid condominioId, string nomeCondominio, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string grupoUnidade,
            bool temVeiculo, string placa, string modelo, string cor,
            Guid moradorId, string nomeMorador)
        {
            SetDataDeEntrada(dataDeEntrada);            
            Observacao = observacao;
            Status = status;

            SetVisitanteId(visitanteId);
            SetCondominioId(condominioId);
            SetNomeDoCondominio(nomeCondominio);

            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(grupoUnidade);
                        
            SetVeiculoPeloMorador(temVeiculo, placa, modelo, cor);

            SetMorador(moradorId, nomeMorador);

        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarVisitaPorMoradorValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVisitaPorMoradorValidation : VisitaValidation<CadastrarVisitaPorMoradorCommand>
        {
            public CadastrarVisitaPorMoradorValidation()
            {               
                ValidateObservacao();
                ValidateStatus();
                ValidateVisitanteId();                
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
