using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.ViewModel
{
    public class AdicionaCondominioCredencialViewModel
    {                  
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid CondominioId { get; set; }
        public TipoApiAutomacao TipoApiAutomacao { get; set; }
    }
}
