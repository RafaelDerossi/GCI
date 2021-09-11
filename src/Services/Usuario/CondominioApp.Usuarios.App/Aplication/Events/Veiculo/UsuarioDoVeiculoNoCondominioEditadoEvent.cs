using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioDoVeiculoNoCondominioEditadoEvent : VeiculoEvent
    {        
        public UsuarioDoVeiculoNoCondominioEditadoEvent(
            Guid id, Guid veiculoId, string placa, string modelo, string cor,
            Guid usuarioId,string nomeUsuario, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string grupoDaUnidade, Guid condominioId, string nomeCondominio,
            string tag, string observacao)
        {
            VeiculoCondominioId = id;
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoDaUnidade;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Tag = tag;
            Observacao = observacao;
        }
    }
}