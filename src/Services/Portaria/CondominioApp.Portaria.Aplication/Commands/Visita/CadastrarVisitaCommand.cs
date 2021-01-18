﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitaCommand : VisitaCommand
    {
        public CadastrarVisitaCommand
            (DateTime dataDeEntrada, string observacao, StatusVisita status,
            Guid visitanteId, string nomeVisitante, string documentoVisitante, string emailVisitante,
            string fotoVisitante, string nomeOriginalFotoVisitante,TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid condominioId, string nomeCondominio, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo, Guid usuarioId, string nomeUsuario)
        {
            SetDataDeEntrada(dataDeEntrada);            
            Observacao = observacao;
            Status = status;

            SetVisitanteId(visitanteId);
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documentoVisitante);
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

            TemVeiculo = temVeiculo;           
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);

            SetUsuario(usuarioId, nomeUsuario);

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
