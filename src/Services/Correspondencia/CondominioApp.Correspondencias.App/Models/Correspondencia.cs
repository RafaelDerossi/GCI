using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.ValueObjects;
using FluentValidation.Results;
using System;

namespace CondominioApp.Correspondencias.App.Models
{
   public class Correspondencia : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public DateTime DataDeChegada { get; private set; }

        public Guid CondominioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string Bloco { get; private set; }
        

        public Guid CadastradaPorId { get; private set; }

        public string CadastradaPorNome { get; private set; }

        public string Observacao { get; private set; }

        public string CodigoDeVerificacao { get; private set; }


        public Foto FotoCorrespondencia { get; private set; }

        public string FotoCorrespondenciaUrl
        {
            get
            {
                if (FotoCorrespondencia == null)
                    return "";

                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), FotoCorrespondencia.NomeDoArquivo);
            }
        }

        public string NumeroRastreamentoCorreio { get; private set; }

        public string TipoDeCorrespondencia { get; private set; }

        public string Localizacao { get; private set; }

        public bool EnviarNotificacao { get; private set; }

        public bool Visto { get; private set; }

        public int QuantidadeDeAlertasFeitos { get; private set; }        

        public StatusCorrespondencia Status { get; private set; }
        

        public DateTime? DataDaRetirada { get; private set; }

        public string NomeRetirante { get; private set; }

        public Foto FotoRetirante { get; private set; }

        public string FotoRetiranteUrl
        {
            get
            {
                if (FotoRetirante == null)
                    return "";
                
                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), FotoRetirante.NomeDoArquivo);
            }
        }        

        public string ObservacaoDaRetirada { get; private set; }

        public Guid EntreguePorId { get; private set; }

        public string EntreguePorNome { get; private set; }


        /// <summary>
        /// Construtores
        /// </summary>
        protected Correspondencia()
        {
        }       

        public Correspondencia
            (DateTime dataDeChegada, Guid condominioId, Guid unidadeId, string numeroUnidade, string bloco,
             Guid cadastradaPorId, string cadastradaPorNome, string observacao, Foto fotoCorrespondencia,
             string numeroRastreamentoCorreio, string tipoDeCorrespondencia, string localizacao,
             bool enviarNotificacao)
        {
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Bloco = bloco;
            DataDeChegada = dataDeChegada;
            CadastradaPorId = cadastradaPorId;
            CadastradaPorNome = cadastradaPorNome;
            Observacao = observacao;
            FotoCorrespondencia = fotoCorrespondencia;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            Localizacao = localizacao;
            EnviarNotificacao = enviarNotificacao;
            SetPendente();
            SetCodigo();
        }





        ///Metodos Set
        ///
        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetNumeroUnidade(string numeroUnidade) => NumeroUnidade = numeroUnidade;

        public void SetBloco(string bloco) => Bloco = bloco;

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

        public void SetNomeRetirante(string nomeRetirante) => NomeRetirante = nomeRetirante;

        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetObservacaoDaRetirada(string observacao) => ObservacaoDaRetirada = observacao;

        public void SetDataRetirada(DateTime dataRetirada) => DataDaRetirada = dataRetirada;

        public void SetCadastradoPor(Guid id, string nome)
        {
            CadastradaPorId = id;
            CadastradaPorNome = nome;
        }

        public void SetEntrequePor(Guid id, string nome)
        {
            EntreguePorId = id;
            EntreguePorNome = nome;
        }        

        public void SetFotoCorrespondencia(Foto foto) => FotoCorrespondencia = foto;

        public void SetFotoRetirante(Foto foto) => FotoRetirante = foto;

        public void SetNumeroRastreamentoCorreio(string numeroRastreamento) => NumeroRastreamentoCorreio = numeroRastreamento;

        public void SetDataDeChegada(DateTime dataDeChegada) => DataDeChegada = dataDeChegada;

   

        

        public void SetTipoDeCorrespondencia(string tipoDeCorrespondencia) => TipoDeCorrespondencia = tipoDeCorrespondencia;

        public void SetPendente() => Status = StatusCorrespondencia.PENDENTE;

        public void SetRetirado() => Status = StatusCorrespondencia.RETIRADO;

        public void SetDevolvido() => Status = StatusCorrespondencia.DEVOLVIDO;
       


        public ValidationResult MarcarComRetirada
            (string nomeRetirante, string observacao, Guid entreguePorId,
             string entreguePorNome, Foto fotoRetirante)
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência ja consta como RETIRADA.");
                return ValidationResult;
            }

            SetNomeRetirante(nomeRetirante);
            SetObservacaoDaRetirada(observacao);
            SetEntrequePor(entreguePorId, entreguePorNome);            
            SetFotoRetirante(fotoRetirante);
            SetRetirado();
            SetDataRetirada(DataHoraDeBrasilia.Get());
            SetVisto();

            return ValidationResult;
        }


        public ValidationResult MarcarComDevolvida
          (string observacao, Guid funcionarioId, string nomeFuncionario)
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência ja consta como RETIRADA.");
                return ValidationResult;
            }

            SetDevolvido();
            SetObservacao(observacao);
            SetCadastradoPor(funcionarioId, nomeFuncionario);            

            return ValidationResult;
        }


        public ValidationResult SomarAlerta()
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como RETIRADA.");
                return ValidationResult;
            }

            QuantidadeDeAlertasFeitos += 1;

            return ValidationResult;
        }

        public void SetCodigo()
        {
            CodigoDeVerificacao = $"{Id.ToString().Substring(0, 4)}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}";
        }


        public void EnviarPush()
        {
            if (EnviarNotificacao)
            {
                switch (Status)
                {
                    case StatusCorrespondencia.PENDENTE:
                        EnviarPushNovaCorrespondencia();
                        break;
                    case StatusCorrespondencia.RETIRADO:
                        EnviarPushCorrespondenciaRetirada();
                        break;
                    case StatusCorrespondencia.DEVOLVIDO:
                        EnviarPushCorrespondenciaDevolvida();
                        break;
                    default:
                        break;
                }
            }            
        }


        private void EnviarPushNovaCorrespondencia()
        {
            var titulo = "Nova Correspondência";
            var descricao = ObterDescricaoDoPushParaNovaCorrespondencia();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        
        private string ObterDescricaoDoPushParaNovaCorrespondencia()
        {
            var descricao = @$"Chegou uma correspondência para você!     Recebido por {CadastradaPorNome}. ";

            if (CodigoDeVerificacao != null && CodigoDeVerificacao != "")
                descricao = @$"{descricao}    Código: {CodigoDeVerificacao}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = @$"{descricao}     Tipo: {TipoDeCorrespondencia}.";

            if (Localizacao != null && Localizacao != "")
                descricao = @$"{descricao}     Localização: {Localizacao}.";

            if (Observacao != null && Observacao != "")
                descricao = @$"{descricao}     {Observacao}.";            

            return descricao;
        }


        private void EnviarPushCorrespondenciaRetirada()
        {
            var titulo = "Correspondência Retirada";
            var descricao = ObterDescricaoDoPushParaCorrespondenciaRetirada();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushParaCorrespondenciaRetirada()
        {
            var descricao = $"Correspondência retirada por {NomeRetirante} em {DataDaRetirada.Value.ToLongDateString()} as {DataDaRetirada.Value.ToLongTimeString()}.";

            if (CodigoDeVerificacao != null && CodigoDeVerificacao != "")
                descricao = $"{descricao}     Código: {CodigoDeVerificacao}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}     Tipo da Corrêspondencia: {TipoDeCorrespondencia}.";

            if (ObservacaoDaRetirada != null && ObservacaoDaRetirada != "")
                descricao = $"{descricao}     {ObservacaoDaRetirada}.";

            return descricao;
        }


        private void EnviarPushCorrespondenciaDevolvida()
        {
            var titulo = "Correspondência Devolvida";
            var descricao = ObterDescricaoDoPushParaCorrespondenciaDevolvida();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushParaCorrespondenciaDevolvida()
        {
            var descricao = $"Correspondência devolvida por {CadastradaPorNome}.";

            if (CodigoDeVerificacao != null && CodigoDeVerificacao != "")
                descricao = $"{descricao}     Código: {CodigoDeVerificacao}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}     Tipo da Corrêspondencia: {TipoDeCorrespondencia}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}     {Observacao}.";

            return descricao;
        }


        public void EnviarPushDeAlerta()
        {
            var titulo = "Correspondência";
            var descricao = ObterDescricaoDoPushDeAlerta();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushDeAlerta()
        {
            var descricao = $"Existe uma correspondência para você esperando ser retirada.";

            if (CodigoDeVerificacao != null && CodigoDeVerificacao != "")
                descricao = $"{descricao}     Código: {CodigoDeVerificacao}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}     Tipo: {TipoDeCorrespondencia}.";

            if (Localizacao != null && Localizacao != "")
                descricao = $"{descricao}     Localização: {Localizacao}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}     {Observacao}.";            

            return descricao;
        }


        public void EnviarEmail()
        {
            if (EnviarNotificacao)
            {
                switch (Status)
                {
                    case StatusCorrespondencia.PENDENTE:
                        EnviarEmailNovaCorrespondencia();
                        break;
                    case StatusCorrespondencia.RETIRADO:
                        EnviarEmailCorrespondenciaRetirada();
                        break;
                    case StatusCorrespondencia.DEVOLVIDO:
                        EnviarEmailCorrespondenciaDevolvida();
                        break;
                    default:
                        break;
                }
            }           
        }

        private void EnviarEmailNovaCorrespondencia()
        {
            var assunto = "Correspondência";
            var titulo = "Nova Correspondência";
            var descricao = @$"Chegou uma correspondência para você!";

            var nomeArquivo = "";
            if (FotoCorrespondencia != null)
                nomeArquivo = FotoCorrespondencia.NomeDoArquivo;

            EnviarEmail(assunto, titulo, descricao, nomeArquivo);

            return;
        }

        private void EnviarEmailCorrespondenciaRetirada()
        {
            var assunto = "Correspondência";
            var titulo = "Correspondência Retirada";            
            var descricao = $"Correspondência retirada por {NomeRetirante} em {DataDaRetirada.Value.ToLongDateString()} as {DataDaRetirada.Value.ToLongTimeString()}.";

            var nomeArquivo = "";
            if (FotoCorrespondencia != null)
                nomeArquivo = FotoCorrespondencia.NomeDoArquivo;

            EnviarEmail(assunto, titulo, descricao, nomeArquivo);

            return;
        }

        private void EnviarEmailCorrespondenciaDevolvida()
        {
            var assunto = "Correspondência";
            var titulo = "Correspondência Devolvida";
            var descricao = $"Correspondência devolvida por {CadastradaPorNome}.";

            var nomeArquivo = "";
            if (FotoCorrespondencia != null)
                nomeArquivo = FotoCorrespondencia.NomeDoArquivo;

            EnviarEmail(assunto, titulo, descricao, nomeArquivo);

            return;
        }

        private void EnviarEmail(string assunto, string titulo, string descricao, string nomeArquivo)
        {
            AdicionarEvento
                 (new EnviarEmailCorrespondenciaIntegrationEvent
                  (assunto, titulo, descricao, UnidadeId, nomeArquivo,
                   CadastradaPorNome, CodigoDeVerificacao, TipoDeCorrespondencia,
                   Localizacao, Observacao));
        }

    }
}
