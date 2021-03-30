using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class CadastrarCorrespondenciaCommand : CorrespondenciaCommand
    {
        public CadastrarCorrespondenciaCommand(
            Guid condominioId, Guid unidadeId, string numeroUnidade, string bloco, string observacao, Guid funcionarioId, 
            string nomeFuncionario, string foto, string nomeOriginal, string numeroRastreamentoCorreio,
            DateTime dataDeChegada, string tipoDeCorrespondencia, StatusCorrespondencia status)
        {
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Bloco = bloco;            
            Observacao = observacao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;
            DataDeChegada = dataDeChegada;
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            
            DataDaRetirada = DataHoraDeBrasilia.Get();         
            QuantidadeDeAlertasFeitos = 1;

            SetFoto(foto, nomeOriginal);
            SetNaoVisto();
            SetStatus(status);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarCorrespondenciaCommandValidation : CorrespondenciaValidation<CadastrarCorrespondenciaCommand>
        {
            public CadastrarCorrespondenciaCommandValidation()
            {
                ValidateCondominioId();
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateBloco();               
                ValidateStatus();
                ValidateUsuarioId();
                ValidateNomeUsuario();
            }
        }
    }
}
