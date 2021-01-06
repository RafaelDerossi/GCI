using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public abstract class AreaComumEvent : Event
    {
        public Guid Id { get; protected set; }      
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public string TermoDeUso { get; protected set; }
        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }
        public int Capacidade { get; protected set; }
        public string DiasPermitidos { get; protected set; }
        public int AntecedenciaMaximaEmMeses { get; protected set; }
        public int AntecedenciaMaximaEmDias { get; protected set; }
        public int AntecedenciaMinimaEmDias { get; protected set; }
        public int AntecedenciaMinimaParaCancelamentoEmDias { get; protected set; }
        public bool RequerAprovacaoDeReserva { get; protected set; }
        public bool TemHorariosEspecificos { get; protected set; }     
        public string TempoDeIntervaloEntreReservas { get; protected set; }
        public bool Ativa { get; protected set; }
        public string TempoDeDuracaoDeReserva { get; protected set; }
        public int NumeroLimiteDeReservaPorUnidade { get; protected set; }
        public DateTime? DataInicioBloqueio { get; protected set; }
        public DateTime? DataFimBloqueio { get; protected set; }
        public bool PermiteReservaSobreposta { get; protected set; }
        public int NumeroLimiteDeReservaSobreposta { get; protected set; }
        public int NumeroLimiteDeReservaSobrepostaPorUnidade { get; protected set; }

        public bool TemIntervaloFixoEntreReservas { get; protected set; }

        public ICollection<Periodo> Periodos;
        
    }
}
