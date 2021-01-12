using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class CadastrarVisitanteCommand : VisitanteCommand
    {

        public CadastrarVisitanteCommand
            (string nome, string documento, string email, string foto, string nomeOriginalFoto, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade,
            bool visitantePermanente, string qrCode, TipoDeVisitante tipoDeVisitante, string nomeEmpresa,
            bool temVeiculo, string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            SetNome(nome);            
            SetCondominioId(condominioId);
            SetNomeCondominio(nomeCondominio);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarDaUnidade(andarUnidade);
            SetGrupoDaUnidade(grupoUnidade);
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;

            SetDocumento(documento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto, foto);
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarVisitanteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVisitanteCommandValidation : VisitanteValidation<CadastrarVisitanteCommand>
        {
            public CadastrarVisitanteCommandValidation()
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
