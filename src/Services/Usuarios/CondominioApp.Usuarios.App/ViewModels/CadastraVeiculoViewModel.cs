using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class CadastraVeiculoViewModel
    {
        public string Placa { get; set; }
        
        public string Modelo { get; set; }

        public string Cor { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid UnidadeId { get; set; }        
    }
}