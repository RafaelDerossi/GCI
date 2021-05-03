using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public abstract class UsuarioEvent : Core.Messages.Event
    {
        public Guid UsuarioId { get; protected set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public Cpf Cpf { get; protected set; }

        public Telefone Cel { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }       

        public Permissao Permissao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }


        public Endereco Endereco { get; protected set; }
    
        public bool SindicoProfissional { get; protected set; }


        public DateTime? DataUltimoLogin { get; protected set; }

        public TipoDeUsuario TipoDeUsuario { get; protected set; }

       
    }
}
