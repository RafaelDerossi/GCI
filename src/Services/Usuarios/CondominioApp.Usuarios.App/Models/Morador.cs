using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.Models
{
   public class Morador : Entity
    {
        public Guid UsuarioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public Guid CondominioId { get; private set; }


        public Morador(Guid usuarioId, Guid unidadeId, Guid condominioId)
        {
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
        }


        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;


    }
}
