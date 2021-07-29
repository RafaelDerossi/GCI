using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AtualizaContratoViewModel
    {
        public Guid Id { get; set; }
      
        public DateTime DataDeAssinatura { get; set; }

        public TipoDePlano Plano { get; set; }        

        public string Descricao { get; set; }        

        public int QuantidadeDeUnidadesContratadas { get; set; }
    }
}
