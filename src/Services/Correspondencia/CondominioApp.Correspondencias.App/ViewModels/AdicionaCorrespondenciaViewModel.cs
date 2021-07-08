using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class AdicionaCorrespondenciaViewModel
    {
        public Guid UnidadeId { get; set; }        

        public string Observacao { get; set; }

        public Guid FuncionarioId { get; set; }

        public IFormFile ArquivoFotoCorrespondencia { get;  set; }        

        public string NumeroRastreamentoCorreio { get; set; }

        public DateTime DataDeChegada { get; set; }

        public string TipoDeCorrespondencia { get; set; }       

        public string Localizacao { get; set; }

        public bool EnviarNotificacao { get; set; }

    }
}