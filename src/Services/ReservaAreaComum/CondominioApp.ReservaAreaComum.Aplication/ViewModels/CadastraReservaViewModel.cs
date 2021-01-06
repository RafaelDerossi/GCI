using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
   public class CadastraReservaViewModel
    {      
        public Guid AreaComumId { get; set; }
        public string Observacao { get; set; }
        public Guid UnidadeId { get; set; }
        public string NumeroUnidade { get; set; }
        public string AndarUnidade { get; set; }
        public string DescricaoGrupoUnidade { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataDeRealizacao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public decimal Preco { get; set; }
        public bool EstaNaFila { get; set; }
        public string Origem { get; set; }
        public bool ReservadoPelaAdministracao { get; set; }
    }
}
