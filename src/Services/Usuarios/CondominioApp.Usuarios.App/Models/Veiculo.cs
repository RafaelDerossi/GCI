using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class Veiculo : Entity
    {
        public string Placa { get; private set; }
        
        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public Guid UsuarioId { get; private set; }

        //EF
        public Usuario Usuario { get; set; }

        protected Veiculo() { }

        public Veiculo(string placa, string modelo, string cor, Guid usuarioId)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;            
        }

        public void SetVeiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;


    }
}