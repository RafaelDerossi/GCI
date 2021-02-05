using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoCadastradoEvent : VeiculoEvent
    {        
        public VeiculoCadastradoEvent(
            Guid id, Guid veiculoId, string placa, string modelo, string cor, Guid usuarioId,
            string nomeUsuario, Guid unidadeId, Guid condominioId)
        {
            Id = id;
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
        }
    }
}