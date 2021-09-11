using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AdicionarVisitantePorMoradorCommand : VisitanteCommand
    {

        public AdicionarVisitantePorMoradorCommand
            (string nome,TipoDeDocumento tipoDoDocumento, string documento, string email, string nomeOriginalFoto,
            Guid condominioId, string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, bool visitantePermanente, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresa, bool temVeiculo, Guid criadorId, string nomeDoCriador)
        {
            SetNome(nome);            
            SetCondominioId(condominioId);
            SetNomeCondominio(nomeCondominio);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarDaUnidade(andarUnidade);
            SetGrupoDaUnidade(grupoUnidade);
            VisitantePermanente = visitantePermanente;            
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;
            CriadorId = criadorId;
            NomeDoCriador = nomeDoCriador;

            SetDocumento(documento, tipoDoDocumento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarVisitantePorMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarVisitantePorMoradorCommandValidation : VisitanteValidation<AdicionarVisitantePorMoradorCommand>
        {
            public AdicionarVisitantePorMoradorCommandValidation()
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
