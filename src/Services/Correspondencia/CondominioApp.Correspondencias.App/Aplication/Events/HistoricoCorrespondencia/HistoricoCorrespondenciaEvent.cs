using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Correspondencias.Aplication.Events
{
    public abstract class HistoricoCorrespondenciaEvent : Event
    {
        public Guid CorrespondenciaId { get; protected set; }

        public AcoesCorrespondencia Acao { get; protected set; }

        public Guid FuncionarioId { get; protected set; }

        public string NomeFuncionario { get; protected set; }

        public bool Visto { get; protected set; }       

        

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

        public void SetAcao(AcoesCorrespondencia acao)
        {
            Acao = acao;
        }                

        public void SetFuncionario(Guid id, string nomeFuncionario)
        {
            FuncionarioId = id;
            NomeFuncionario = nomeFuncionario;
        }
       
    }
}
