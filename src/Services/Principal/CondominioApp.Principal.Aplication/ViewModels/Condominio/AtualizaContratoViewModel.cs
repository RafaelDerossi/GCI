using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AtualizaContratoViewModel
    {
        public Guid Id { get; set; }
      
        public DateTime DataDaAssinatura { get; set; }

        public TipoDePlano TipoPlano { get; set; }        

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public string LinkContrato { get; set; }
    }
}
