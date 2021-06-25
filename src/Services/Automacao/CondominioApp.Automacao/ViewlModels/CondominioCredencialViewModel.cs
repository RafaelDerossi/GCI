using CondominioApp.Automacao.Models;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.ViewModel
{
    public class CondominioCredencialViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }        
        public TipoApiAutomacao TipoApiAutomacao { get; set; }
        public Guid CondominioId { get; set; }

        public CondominioCredencialViewModel()
        {
        }

        public CondominioCredencialViewModel(CondominioCredencial credencial)
        {
            Id = credencial.Id;
            Email = credencial.Email.Endereco;
            Senha = credencial.SenhaDescriptografa;
            TipoApiAutomacao = credencial.TipoApiAutomacao;
            CondominioId = credencial.CondominioId;
        }
    }
}
