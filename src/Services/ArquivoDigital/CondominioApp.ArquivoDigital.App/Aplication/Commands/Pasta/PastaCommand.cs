using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
   public class PastaCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Titulo { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public bool Publica { get; protected set; }

        public bool PastaDoSistema { get; protected set; }

        public CategoriaDaPastaDeSistema CategoriaDaPastaDeSistema { get; protected set; }

        public bool PastaRaiz { get; protected set; }

        public Guid? PastaMaeId { get; protected set; }




        public void SetId(Guid id) => Id = id;

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominioId(Guid condominioid) => CondominioId = condominioid;

        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;

        public void MarcarComoPastaDoSistema() => PastaDoSistema = true;

        public void SetPastaMaeId(Guid? id) => PastaMaeId = id;

    }
}
