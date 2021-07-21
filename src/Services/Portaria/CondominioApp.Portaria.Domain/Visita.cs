using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.Portaria.Domain.ValueObjects;
using FluentValidation.Results;
using System;

namespace CondominioApp.Portaria.Domain
{
    public class Visita : Entity
    {
        public const int Max = 200;

        public DateTime DataDeEntrada { get; private set; }
        public DateTime DataDeSaida { get; private set; }
        public StatusVisita Status { get; private set; }
        public string Observacao { get; private set; }
        public Guid VisitanteId { get; private set; }
        public string NomeVisitante { get; private set; }
        public TipoDeDocumento TipoDeDocumentoVisitante { get; private set; }
        public string Documento { get; private set; }
        public Email EmailVisitante { get; private set; }
        public Foto FotoVisitante { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresaVisitante { get; private set; }
        public Guid CondominioId { get; private set; }
        public Guid UnidadeId { get; private set; }
        public bool TemVeiculo { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public Guid MoradorId { get; private set; }


        /// Construtores       
        protected Visita()
        {
        }

        public Visita(
            DateTime dataDeEntrada, string observacao, StatusVisita status, Guid visitanteId,
            string nomeVisitante, TipoDeDocumento tipoDeDocumentoVisitante, string documento,
            Email emailVisitante, Foto fotoVisitante, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid condominioId, Guid unidadeId, bool temVeiculo,
            Veiculo veiculo, Guid moradorId)
        {
            DataDeEntrada = dataDeEntrada;
            Observacao = observacao;
            Status = status;
            VisitanteId = visitanteId;
            NomeVisitante = nomeVisitante;
            EmailVisitante = emailVisitante;
            FotoVisitante = fotoVisitante;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresaVisitante = nomeEmpresaVisitante;
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            TemVeiculo = temVeiculo;
            Veiculo = veiculo;
            MoradorId = moradorId;            
            SetDocumentoVisitante(documento, tipoDeDocumentoVisitante);
        }


        /// Metodos Set      
        public ValidationResult AprovarVisita()
        {
            if (ObterStatus() == StatusVisita.APROVADA)
            {
                AdicionarErrosDaEntidade("Visita já esta aprovada.");
                return ValidationResult;
            }
            if (ObterStatus() != StatusVisita.PENDENTE)
            {
                AdicionarErrosDaEntidade("Visita não pode ser aprovada pois esta " + ObterStatus().ToString().ToLower());
                return ValidationResult;
            }

            Status = StatusVisita.APROVADA;

            return ValidationResult;
        }

        public ValidationResult ReprovarVisita()
        {

            if (ObterStatus() == StatusVisita.REPROVADA)
            {
                AdicionarErrosDaEntidade("Visita já esta reprovada.");
                return ValidationResult;
            }
            if (ObterStatus() != StatusVisita.PENDENTE && ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErrosDaEntidade("Visita não pode ser reprovada pois esta " + ObterStatus().ToString().ToLower());
                return ValidationResult;
            }


            Status = StatusVisita.REPROVADA;

            return ValidationResult;
        }


        public ValidationResult IniciarVisita()
        {
            if (ObterStatus() == StatusVisita.PENDENTE)
            {
                AdicionarErrosDaEntidade("Visita não pode ser iniciada pois ainda esta pendente de aprovação.");
                return ValidationResult;
            }
            if (ObterStatus() == StatusVisita.INICIADA)
            {
                AdicionarErrosDaEntidade("Visita já esta iniciada.");
                return ValidationResult;
            }
            if (ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErrosDaEntidade("Visita não pode ser iniciada pois esta " + ObterStatus().ToString().ToLower());
                return ValidationResult;
            }

            Status = StatusVisita.INICIADA;
            DataDeEntrada = DataHoraDeBrasilia.Get();

            return ValidationResult;
        }
        public ValidationResult TerminarVisita()
        {
            if (ObterStatus() == StatusVisita.TERMINADA)
            {
                AdicionarErrosDaEntidade("Visita já esta terminada.");
                return ValidationResult;
            }
            if (ObterStatus() != StatusVisita.INICIADA)
            {
                AdicionarErrosDaEntidade("Visita não pode ser terminada pois não esta iniciada.");
                return ValidationResult;
            }

            Status = StatusVisita.TERMINADA;
            DataDeSaida = DataHoraDeBrasilia.Get();

            return ValidationResult;
        }


        public void SetObservacao(string observacao) => Observacao = observacao;
        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;
        public void SetVisitanteId(Guid id) => VisitanteId = id;
        public void SetNomeVisitante(string nome) => NomeVisitante = nome;
        public void SetDocumentoVisitante(string documento, TipoDeDocumento tipoDeDocumento)
        {
            TipoDeDocumentoVisitante = tipoDeDocumento;
            Documento = documento;
        }
        public void SetEmailVisitante(Email email) => EmailVisitante = email;
        public void SetFotoVisitante(Foto foto) => FotoVisitante = foto;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresaVisitante(string nomeEmpresa) => NomeEmpresaVisitante = nomeEmpresa;

        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;
        public void SetVeiculo(Veiculo veiculo) => Veiculo = veiculo;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetMorador(Guid moradorId)
        {
            MoradorId = moradorId;
        }

        /// Outros Metodos



        public StatusVisita ObterStatus()
        {
            if (Status == StatusVisita.PENDENTE && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                return StatusVisita.EXPIRADA;

            if (Status == StatusVisita.APROVADA && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                return StatusVisita.EXPIRADA;

            return Status;
        }


        public ValidationResult Editar
            (string observacao, string nomeVisitante, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid unidadeId, bool temVeiculo, Veiculo veiculo)
        {
            if (ObterStatus() != StatusVisita.PENDENTE)
            {
                AdicionarErrosDaEntidade("Visita não pode ser editada pois esta " + ObterStatus().ToString());
                return ValidationResult;
            }

            SetObservacao(observacao);
            SetNomeVisitante(nomeVisitante);
            SetTipoDeVisitante(tipoDeVisitante);
            SetNomeEmpresaVisitante(nomeEmpresaVisitante);
            SetUnidadeId(unidadeId);

            MarcarNaoTemVeiculo();
            if (temVeiculo)
                MarcarTemVeiculo();

            SetVeiculo(veiculo);

            return ValidationResult;
        }


        public ValidationResult Remover()
        {
            if (ObterStatus() != StatusVisita.PENDENTE &&
               ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErrosDaEntidade("Visita não pode ser removida pois ja esta " + ObterStatus().ToString().ToLower());
                return ValidationResult;
            }

            return ValidationResult;
        }


        public void EnviarPushAvisoDeVisitaNaPortaria()
        {
            var titulo = "VISITA PARA VOCÊ";
            var descricao = ObterDescricaoParaAvisoDeVisitaNaPortaria();           

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, descricao));
        }
        private string ObterDescricaoParaAvisoDeVisitaNaPortaria()
        {
            if (TipoDeVisitante == TipoDeVisitante.SERVICO)
            {
                return $"Deseja liberar a entrada do(a) {NomeVisitante}, da empresa {NomeEmpresaVisitante}?";
            }

            return $"Deseja liberar a entrada do(a) {NomeVisitante}?";
        }

        public void EnviarPushAvisoDeVisitaIniciada()
        {
            var titulo = "VISITA INICIADA";
            var descricao = ObterDescricaoParaAvisoDeVisitaIniciada();

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, descricao));
        }
        private string ObterDescricaoParaAvisoDeVisitaIniciada()
        {
            if (TipoDeVisitante == TipoDeVisitante.SERVICO)
            {
                return $"{NomeVisitante}, da empresa {NomeEmpresaVisitante}, entrou no condomínio.";
            }

            return $"{NomeVisitante} entrou no condomínio.";
        }

        public void EnviarPushAvisoDeVisitaTerminada()
        {
            var titulo = "VISITA TERMINADA";
            var descricao = ObterDescricaoParaAvisoDeVisitaTerminada();

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, descricao));
        }
        private string ObterDescricaoParaAvisoDeVisitaTerminada()
        {
            if (TipoDeVisitante == TipoDeVisitante.SERVICO)
            {
                return $"{NomeVisitante}, da empresa {NomeEmpresaVisitante}, saiu no condomínio.";
            }

            return $"{NomeVisitante} saiu no condomínio.";
        }

                
    }
}
