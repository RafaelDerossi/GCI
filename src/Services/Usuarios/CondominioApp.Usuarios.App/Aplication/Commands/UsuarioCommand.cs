using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using FluentValidation;


namespace CondominioApp.Usuarios.App.Aplication.Commands
{   
    public abstract class UsuarioCommand : Command
    {
        public Guid UsuarioId { get; set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public Cpf Cpf { get; protected set; }

        public Telefone Cel { get; protected set; }

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }

        public TipoDeUsuario TpUsuario { get; protected set; }

        public Permissao Permissao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }
    }
}
