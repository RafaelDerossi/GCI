using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AdicionaContratoViewModel
    {
        public Guid CondominioId { get; set; }

        public DateTime DataDeAssinatura { get; set; }

        public TipoDePlano Plano { get; set; }        

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public int QuantidadeDeUnidadesContratadas { get; set; }

        public IFormFile ArquivoContrato { get; set; }
    }
}
