using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class ReprovaReservaAdmViewModel
    {
        /// <summary>
        /// Id(Guid) da reserva a ser reprovada
        /// </summary>
        public Guid ReservaId { get; set; }

        /// <summary>
        /// Justificativa da reprovação (500 caracteres)
        /// </summary>
        public string Justificativa { get; set; }

        /// <summary>
        /// Id(Guid) do funcionário que esta realizando a reprovação
        /// </summary>
        public Guid FuncionarioId { get; set; }

        /// <summary>
        /// Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres)
        /// </summary>
        public string Origem { get; set; }        

    }
}
