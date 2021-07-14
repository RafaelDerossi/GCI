using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class AprovaReservaAdmViewModel
    {      
        /// <summary>
        /// Id(Guid) da reserva a ser aprovada
        /// </summary>
        public Guid ReservaId { get; set; }

        /// <summary>
        /// Id(Guid) do funcionário que esta realizando a aprovação
        /// </summary>
        public Guid FuncionarioId { get; set; }

        /// <summary>
        /// Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres)
        /// </summary>
        public string Origem { get; set; }        

    }
}
