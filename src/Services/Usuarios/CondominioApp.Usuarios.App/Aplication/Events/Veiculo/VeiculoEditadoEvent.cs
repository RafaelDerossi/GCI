using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoEditadoEvent : VeiculoEvent
    {        
        public VeiculoEditadoEvent(
            Guid veiculoId, string placa, string modelo, string cor)
        {            
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;         
        }
    }
}