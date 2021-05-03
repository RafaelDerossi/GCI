using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public abstract class MoradorCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }

        public bool CriadoPelaAdministracao { get; protected set; }


        public void DesmarcarComoCriadoPelaAdministracao() => CriadoPelaAdministracao = false;

    }
}
