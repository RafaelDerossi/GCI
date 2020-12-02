using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Correspondencias.App.ValueObjects;
using System;

namespace CondominioApp.Correspondencias.App.Models
{
   public class Correspondencia : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string Bloco { get; private set; }
        
        public bool Visto { get; private set; }
        
        public string NomeRetirante { get; private set; }
        
        public string Observacao { get; private set; }

        public DateTime DataDaRetirada { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public Foto Foto { get; private set; }

        public string NumeroRastreamentoCorreio { get; private set; }

        public DateTime DataDeChegada { get; private set; }

        public int QuantidadeDeAlertasFeitos { get; private set; }

        public string TipoDeCorrespondencia { get; private set; }

        public StatusCorrespondencia Status { get; private set; }



        /// <summary>
        /// Construtores
        /// </summary>
        public Correspondencia()
        {
        }
        public Correspondencia(Guid unidadeId, string numeroUnidade, string bloco, bool visto, 
            string nomeRetirante, string observacao, DateTime dataDaRetirada, Guid usuarioId, 
            string nomeUsuario, Foto foto, string numeroRastreamentoCorreio, DateTime dataDeChegada, 
            int quantidadeDeAlertasFeitos, string tipoDeCorrespondencia, StatusCorrespondencia status)
        {
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Bloco = bloco;
            Visto = visto;
            NomeRetirante = nomeRetirante;
            Observacao = observacao;
            DataDaRetirada = dataDaRetirada;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Foto = foto;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;
            DataDeChegada = dataDeChegada;
            QuantidadeDeAlertasFeitos = quantidadeDeAlertasFeitos;
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            Status = status;
        }


        ///Metodos Set
        ///

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetNumeroUnidade(string numeroUnidade) => NumeroUnidade = numeroUnidade;

        public void SetBloco(string bloco) => Bloco = bloco;

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

        public void SetNomeRetirante(string nomeRetirante) => NomeRetirante = nomeRetirante;

        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataRetirada(DateTime dataRetirada) => DataDaRetirada = dataRetirada;

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public void SetNomeUsuario(string nomeUsuario) => NomeUsuario = nomeUsuario;

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetNumeroRastreamentoCorreio(string numeroRastreamento) => NumeroRastreamentoCorreio = numeroRastreamento;

        public void SetDataDeChegada(DateTime dataDeChegada) => DataDeChegada = dataDeChegada;

        public void SomarAlerta() => QuantidadeDeAlertasFeitos = QuantidadeDeAlertasFeitos++;

        public void SetTipoDeCorrespondencia(string tipoDeCorrespondencia) => TipoDeCorrespondencia = tipoDeCorrespondencia;

        public void SetStatus(StatusCorrespondencia status) => Status = status;

    }
}
