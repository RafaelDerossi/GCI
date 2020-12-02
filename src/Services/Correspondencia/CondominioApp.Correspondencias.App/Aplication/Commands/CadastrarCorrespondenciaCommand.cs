using CondominioApp.Core.Enumeradores;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class CadastrarCorrespondenciaCommand : CorrespondenciaCommand
    {
        public CadastrarCorrespondenciaCommand(
            Guid correspondenciaId, Guid unidadeId, string numeroUnidade, string bloco,
            bool visto, string nomeRetirante, string observacao, DateTime dataDaRetirada,
            Guid usuarioId, string nomeUsuario, string foto, string nomeOriginal, string numeroRastreamentoCorreio,
            DateTime dataDeChegada, int quantidadeDeAlertasFeitos, string tipoDeCorrespondencia,
            StatusCorrespondencia status)
        {
            CorrespondenciaId = correspondenciaId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Bloco = bloco;
            Visto = visto;
            NomeRetirante = nomeRetirante;
            Observacao = observacao;
            DataDaRetirada = dataDaRetirada;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;
            DataDeChegada = dataDeChegada;
            QuantidadeDeAlertasFeitos = quantidadeDeAlertasFeitos;
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            Status = status;

            SetFoto(foto, nomeOriginal);
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
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateBloco();
                ValidateVisto();
                ValidateQuantidadeDeAlertasFeitos();
                ValidateStatus();
                ValidateUsuarioId();
                ValidateNomeUsuario();
            }
        }
    }
}
