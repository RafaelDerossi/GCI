using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class FotoDoProdutoViewModel
    {
        public Guid FotoDoProdutoId { get; set; }

        public string NomeOriginal { get; set; }
        
        public string NomeDoArquivo { get; set; }
        
        public bool Principal { get;  set; }
    }
}
