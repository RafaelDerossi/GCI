

using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaSolicitadaComoUsuarioEvent : ReservaEvent
    {
        public ReservaSolicitadaComoUsuarioEvent
            (Guid id, Guid areaComumId, 
            string nomeAreaComum, Guid condominioId, string nomeCondominio,
            int capacidade, string observacao, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            string justificativa, string origem, bool reservadoPelaAdministracao)
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
            MoradorId = usuarioId;
            NomeMorador = nomeUsuario;
            DataDeRealizacao = dataDeRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;            
            Preco = preco;            
            Justificativa = justificativa;
            Origem = origem;            
            ReservadoPelaAdministracao = reservadoPelaAdministracao;            
        }    

    }
}
