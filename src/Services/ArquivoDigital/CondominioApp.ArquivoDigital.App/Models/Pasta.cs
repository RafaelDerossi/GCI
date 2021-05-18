using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
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

        public bool PastaDoSistema { get; private set; }

        public bool PastaRaiz { get; private set; }

        /// <summary>
        /// Id da Pasta Mãe
        /// </summary>
        public Guid? PastaMaeId { get; private set; }
        public Pasta PastaMae { get; private set; }

        public CategoriaDaPastaDeSistema CategoriaDaPastaDeSistema { get; private set; }



        private readonly List<Arquivo> _Arquivos;
        public IReadOnlyCollection<Arquivo> Arquivos => _Arquivos;


        private readonly List<Pasta> _Pastas;
        public IReadOnlyCollection<Pasta> Pastas => _Pastas;

        public Pasta()
        {
            _Arquivos = new List<Arquivo>();
            _Pastas = new List<Pasta>();
        }

        public Pasta(string titulo, string descricao, Guid condominioId, bool publica,
                     bool pastaDoSistema, CategoriaDaPastaDeSistema categoriaDaPastaDeSistema,
                     bool pastaRaiz, Guid? pastaMaeId)
        {            
            _Arquivos = new List<Arquivo>();
            _Pastas = new List<Pasta>();
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;
            Publica = publica;
            PastaDoSistema = pastaDoSistema;
            CategoriaDaPastaDeSistema = categoriaDaPastaDeSistema;
            PastaRaiz = pastaRaiz;
            PastaMaeId = pastaMaeId;
        }


        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;

        public void MarcarComoPastaDoSistema() => PastaDoSistema = true;
    }
}
