using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.ViewModel
{
    public class AtualizaCondominioCredencialViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }        
        public TipoApiAutomacao TipoApiAutomacao { get; set; }
    }
}
