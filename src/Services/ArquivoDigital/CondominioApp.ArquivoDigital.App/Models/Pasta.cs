using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
   public class Pasta : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public bool Publica { get; private set; }

        private readonly List<Arquivo> _Arquivo;

        public IReadOnlyCollection<Arquivo> Arquivos => _Arquivo;

        public Pasta()
        {
            _Arquivo = new List<Arquivo>();
        }

        public Pasta(string titulo, string descricao, Guid condominioId, bool publica)
        {            
            _Arquivo = new List<Arquivo>();
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;
            Publica = publica;        
        }

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;

    }
}
