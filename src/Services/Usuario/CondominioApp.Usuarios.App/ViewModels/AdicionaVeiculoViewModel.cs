using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class AdicionaVeiculoViewModel
    {
        public string Placa { get; set; }
        
        public string Modelo { get; set; }

        public string Cor { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid UnidadeId { get; set; }

        public string Tag { get; set; }

        public string Observacao { get; set; }
    }
}