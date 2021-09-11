using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public abstract class OcorrenciaCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public Foto Foto { get; protected set; }
        public bool Publica { get; protected set; }


        public StatusDaOcorrencia Status { get; private set; }
        public DateTime? DataResposta { get; protected set; }        
        public string Parecer { get; protected set; }
        public DateTime? DataResolucao { get; protected set; }


        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }


        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }


        public Guid MoradorId { get; protected set; }
        public string NomeMorador { get; protected set; }

        public bool Panico { get; protected set; }

      

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(string nomeOriginalfoto)
        {
            try
            {
                Foto = new Foto(nomeOriginalfoto);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetMoradorId(Guid id) => MoradorId = id;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;



        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;


        public void MarcarComoOcorrenciaDePanico() => Panico = true;

        public void DesmarcarComoOcorrenciaDePanico() => Panico = false;


        public void ColocarEmAndamento(string parecer)
        {
            Status = StatusDaOcorrencia.EM_ANDAMENTO;
            Parecer = parecer;            
            DataResposta = DataHoraDeBrasilia.Get();
        }

        public void MarcarComoResolvida(string parecer)
        {
            Status = StatusDaOcorrencia.RESOLVIDA;            
            Parecer = parecer;
            DataResolucao = DataHoraDeBrasilia.Get();
        }

    }
}
