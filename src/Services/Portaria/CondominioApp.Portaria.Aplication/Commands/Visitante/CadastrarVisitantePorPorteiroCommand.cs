using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitantePorPorteiroCommand : VisitanteCommand
    {

        public CadastrarVisitantePorPorteiroCommand
            (Guid id, string nome, string documento, string email, string foto, string nomeOriginalFoto, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade,
            TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            Id = id;
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

            SetDocumento(documento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto, foto);           

            QrCode = "";
            VisitantePermanente = false;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarVisitantePorPorteiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVisitantePorPorteiroCommandValidation : VisitanteValidation<CadastrarVisitantePorPorteiroCommand>
        {
            public CadastrarVisitantePorPorteiroCommandValidation()
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
