using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class CadastraContratoViewModel
    {
        public Guid CondominioId { get; set; }

        public DateTime DataDaAssinatura { get; set; }

        public TipoDePlano TipoPlano { get; set; }        

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public string LinkContrato { get; set; }
    }
}
