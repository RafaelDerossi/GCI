using CondominioApp.Core.DomainObjects;
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

        public bool Publica { get; protected set; }



        public void SetId(Guid id) => Id = id;

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;
    }
}
