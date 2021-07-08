using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Automacao.ViewModel
{
   public class DispositivoViewModel
    {
        public string DispositivoId { get; set; }        
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Chave { get; set; }
        public string Apikey { get; set; }        
        public string Grupo { get; set; }
        public bool Online { get; set; }
        public string Localizacao { get; set; }
        public string OnlineHora { get; set; }
        public string DataDeCriacao { get; set; }
        public string Ip { get; set; }
        public string OfflineHora { get; set; }
        public string State { get; set; }
        public string UrlDoDispositivo { get; set; }
        public string NomeDaMarca { get; set; }
        public bool MostraMarca { get; set; }
        public string UrlDaLogoDaMarca { get; set; }
        public string ModeloDoProduto { get; set; }
        public TipoApiAutomacao TipoAutomacao { get; set; }
    }
}
