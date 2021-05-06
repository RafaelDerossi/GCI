using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class ReprovarReservaAdmViewModel
    {      
        public Guid ReservaId { get; set; }

        public string Justificativa { get; set; }

        public Guid FuncionarioId { get; set; }

        public string Origem { get; set; }        

    }
}
