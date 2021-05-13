using System;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class AdicionaVisitaMoradorViewModel
    {
        public DateTime DataDeEntradaInicio { get; set; }
        public DateTime DataDeEntradaFim { get; set; }
        public string Observacao { get; set; }               

        public Guid VisitanteId { get; set; }      
        public Guid UnidadeId { get; set; }
        
        public bool TemVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string CorVeiculo { get; set; }

        public Guid MoradorId { get; set; }
    }
}
