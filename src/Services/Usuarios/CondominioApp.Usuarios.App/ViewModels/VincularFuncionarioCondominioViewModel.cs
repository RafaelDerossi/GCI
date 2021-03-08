using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Usuarios.App.ViewModels
{
    public class VincularFuncionarioCondominioViewModel
    {
        public Guid UsuarioId { get; set; }

        public Guid CondominioId { get; set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public Permissao Permissao { get; private set; }

    }
}