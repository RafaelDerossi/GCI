using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class CadastraVisitaMoradorViewModel
    {
        public DateTime DataDeEntradaInicio { get; set; }
        public DateTime DataDeEntradaFim { get; set; }
        public string Observacao { get; set; }               

        public Guid VisitanteId { get; set; }        

        public Guid CondominioId { get; set; }
        public string NomeCondominio { get; set; }

        public Guid UnidadeId { get; set; }
        public string NumeroUnidade { get; set; }
        public string AndarUnidade { get; set; }
        public string GrupoUnidade { get; set; }

        public bool TemVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string CorVeiculo { get; set; }

        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }

    }
}
