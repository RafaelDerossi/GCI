using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.ViewModels
{
   public class Pasta : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        private readonly List<Arquivo> _Arquivo;

        public IReadOnlyCollection<Arquivo> Arquivos => _Arquivo;

        public Pasta()
        {
        }

        public Pasta(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;            
        }
    }
}
