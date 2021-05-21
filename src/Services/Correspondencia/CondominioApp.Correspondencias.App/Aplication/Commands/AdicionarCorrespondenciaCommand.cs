using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class AdicionarCorrespondenciaCommand : CorrespondenciaCommand
    {
        public AdicionarCorrespondenciaCommand(
            Guid condominioId, Guid unidadeId, string numeroUnidade, string bloco, string observacao,
            Guid funcionarioId, string nomeFuncionario, string nomeOriginalFotoCorrespondencia,
            string numeroRastreamentoCorreio, DateTime dataDeChegada, string tipoDeCorrespondencia,
            StatusCorrespondencia status, string nomeRetirante, DateTime? dataDaRetirada)
        {
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Grupo = bloco;            
            Observacao = observacao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;           
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            NomeRetirante = nomeRetirante;         
            QuantidadeDeAlertasFeitos = 1;

            SetFotoCorrespondencia(nomeOriginalFotoCorrespondencia);
            SetNaoVisto();
            SetStatus(status);
            SetDataDeChegada(dataDeChegada);
            SetDataDeRetirada(dataDaRetirada);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarCorrespondenciaCommandValidation : CorrespondenciaValidation<AdicionarCorrespondenciaCommand>
        {
            public AdicionarCorrespondenciaCommandValidation()
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
