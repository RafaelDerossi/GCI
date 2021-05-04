using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class EditaVeiculoViewModel
    {
        public Guid Id { get; set; }

        public string Placa { get; set; }
        
        public string Modelo { get; set; }

        public string Cor { get; set; }        
    }
}