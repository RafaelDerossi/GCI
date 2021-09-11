using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoEditadoEvent : VeiculoEvent
    {        
        public VeiculoEditadoEvent(
            Guid veiculoCondominioId, Guid veiculoId, string placa, string modelo, string cor, string tag, string observacao)
        {
            VeiculoId = veiculoId;
            VeiculoCondominioId = veiculoCondominioId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Tag = tag;
            Observacao = observacao;
        }
    }
}