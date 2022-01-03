using GCI.Core.Messages.CommonMessages;

namespace GCI.Acoes.Aplication.Events
{
    public abstract class AcaoEvent : Event
    {
        public System.Guid AcaoId { get; protected set; }

        public System.DateTime DataDeCadastro { get; protected set; }

        public System.DateTime DataDeAlteracao { get; protected set; }

        public string Codigo { get; protected set; }                

        public string RazaoSocial { get; protected set; }

    }
}
