using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
   public class AdicionaReservaAdmViewModel
    {
        /// <summary>
        /// Id(Guid) da área comum para qual a reserva esta sendo solicitada
        /// </summary>
        public Guid AreaComumId { get; set; }

        /// <summary>
        /// Observação da reserva (240 caracteres)
        /// </summary>
        public string Observacao { get; set; }

        /// <summary>
        /// Id(Guid) do morador para o qual a solicitação esta sendo feita
        /// </summary>
        public Guid MoradorId { get; set; }

        /// <summary>
        /// Data para a qual a reserva esta sendo solicitada
        /// </summary>
        public DateTime DataDeRealizacao { get; set; }

        /// <summary>
        /// Horário de inicio para o qual a reserva esta sendo solicitada
        /// </summary>
        public string HoraInicio { get; set; }

        /// <summary>
        /// Horário de término para o qual a reserva esta sendo solicitada
        /// </summary>
        public string HoraFim { get; set; }

        /// <summary>
        /// Valor de custo para o solicitante da reserva
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Se a reserva é para a administração
        /// </summary>
        public bool ReservadoPelaAdministracao { get; set; }

        /// <summary>
        /// Origem da solicitação da reserva (Modelo do dispositivo/ Sistema Web)
        /// </summary>
        public string Origem { get; set; }

        /// <summary>
        /// Id(Guid) do funcionário que esta realizando a solicitação (200 caracteres)
        /// </summary>
        public Guid FuncionarioId { get; set; }

    }
}
