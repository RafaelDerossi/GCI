using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoEvent : Event
    {
        public Guid Id { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public DateTime DataAssinatura { get; set; }

        public TipoDePlano TipoPlano { get; set; }

        public string DescricaoContrato { get; set; }

        public bool Ativo { get; set; }

        public string LinkContrato { get; set; }

      

    }
}