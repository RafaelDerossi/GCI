

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaCadastradaEvent : ReservaEvent
    {
        public ReservaCadastradaEvent
            (Guid id, Guid areaComumId, 
            string nomeAreaComum, Guid condominioId, string nomeCondominio,
            int capacidade, string observacao, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, bool ativa, decimal preco,
            bool estaNaFila, string origem, bool reservadoPelaAdministracao)
        {
            Id = id;
            AreaComumId = areaComumId;
            NomeAreaComum = nomeAreaComum;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Capacidade = capacidade;
            Observacao = observacao;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            DataDeRealizacao = dataDeRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Ativa = ativa;
            Preco = preco;
            EstaNaFila = estaNaFila;
            Origem = origem;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;

        }    

    }
}
