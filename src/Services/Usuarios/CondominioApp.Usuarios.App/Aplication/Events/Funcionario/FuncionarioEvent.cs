using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioEvent : Core.Messages.Event
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }        

        public Permissao Permissao { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public bool SindicoProfissional { get; protected set; }        
        
        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }        

    }
}