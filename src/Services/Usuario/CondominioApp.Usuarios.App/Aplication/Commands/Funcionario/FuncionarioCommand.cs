using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public abstract class FuncionarioCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public Permissao Permissao { get; protected set; }        

    }
}
