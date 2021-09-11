﻿using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
    public class CancelaReservaMoradorViewModel
    {
        /// <summary>
        /// Id(Guid) da reserva a ser cancelada; 
        /// </summary>
        public Guid ReservaId { get; set; }

        /// <summary>
        /// Justificativa do cancelamento (500 caracteres)
        /// </summary>
        public string Justificativa { get; set; }

        /// <summary>
        /// Id(Guid) do morador que esta realizando a ação
        /// </summary>
        public Guid MoradorId { get; set; }

        /// <summary>
        /// Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres)
        /// </summary>
        public string Origem { get; set; }
    }
}