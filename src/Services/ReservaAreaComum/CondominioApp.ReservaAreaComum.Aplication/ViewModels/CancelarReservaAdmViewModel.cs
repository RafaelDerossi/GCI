using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class CancelarReservaAdmViewModel
    {      
        public Guid ReservaId { get; set; }

        public string Justificativa { get; set; }

        public Guid FuncionarioId { get; set; }

        public string Origem { get; set; }
    }
}
