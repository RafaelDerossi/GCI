using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class CancelarReservaMoradorViewModel
    {      
        public Guid ReservaId { get; set; }

        public string Justificativa { get; set; }

        public Guid MoradorId { get; set; }

        public string Origem { get; set; }
    }
}
