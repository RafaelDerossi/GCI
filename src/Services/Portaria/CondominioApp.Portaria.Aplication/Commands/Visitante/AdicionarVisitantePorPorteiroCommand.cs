﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AdicionarVisitantePorPorteiroCommand : VisitanteCommand
    {

        public AdicionarVisitantePorPorteiroCommand
            (string nome, TipoDeDocumento tipoDeDocumento, string documento, string email, 
             string nomeOriginalFoto, Guid condominioId, string nomeCondominio, Guid unidadeId,
             string numeroUnidade, string andarUnidade, string grupoUnidade, TipoDeVisitante tipoDeVisitante,
             string nomeEmpresa, bool temVeiculo, Guid funcionarioId, string nomeDoFuncionario)
        {
            Id = Guid.NewGuid();
            SetNome(nome);            
            SetCondominioId(condominioId);
            SetNomeCondominio(nomeCondominio);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarDaUnidade(andarUnidade);
            SetGrupoDaUnidade(grupoUnidade);            
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;
            CriadorId = funcionarioId;
            NomeDoCriador = nomeDoFuncionario;
            SetDocumento(documento, tipoDeDocumento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto);
            VisitantePermanente = false;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarVisitantePorPorteiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarVisitantePorPorteiroCommandValidation : VisitanteValidation<AdicionarVisitantePorPorteiroCommand>
        {
            public AdicionarVisitantePorPorteiroCommandValidation()
            {
                ValidateNome();
                ValidateCondominioId();
                ValidateNomeCondominio();
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoUnidade();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}