using System;

namespace CondominioApp.Usuarios.App.ViewModels
{
    public class VincularMoradorUnidadeViewModel
    {
        public Guid UsuarioId { get; set; }

        public Guid UnidadeId { get; set; }

        public bool Proprietario { get; set; }

        public bool Principal { get; set; }

        public bool CriadoPelaAdministracao { get; set; }

    }
}