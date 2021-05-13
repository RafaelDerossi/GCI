using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class AdicionaReservaMoradorViewModel
    {      
        public Guid AreaComumId { get; set; }

        public string Observacao { get; set; }        

        public Guid MoradorId { get; set; }        

        public DateTime DataDeRealizacao { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }

        public decimal Preco { get; set; }

        public string Origem { get; set; }
        
    }
}
