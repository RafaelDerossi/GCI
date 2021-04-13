using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public abstract class ReservaEvent : Event
    {
        public Guid Id { get; protected set; }
        public Guid AreaComumId { get; protected set; }
        public string NomeAreaComum { get; protected set; }
        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }
        public int Capacidade { get; protected set; }
        public string Observacao { get; protected set; }
        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string DescricaoGrupoUnidade { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public string NomeUsuario { get; protected set; }
        public DateTime DataDeRealizacao { get; protected set; }
        public string HoraInicio { get; protected set; }
        public string HoraFim { get; protected set; }        
        public decimal Preco { get; protected set; }
        public StatusReserva Status { get; protected set; }        
        public string Justificativa { get; protected set; }
        public string Origem { get; protected set; }
        public bool ReservadoPelaAdministracao { get; protected set; }
       
    }
}
