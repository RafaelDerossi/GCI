using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class EditaVeiculoViewModel
    {
        public Guid veiculoCondominioId { get; set; }

        public string Placa { get; set; }
        
        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string Tag { get; set; }

        public string Observacao { get; set; }
    }
}