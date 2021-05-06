using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ReservaSolicitadaComoAdministradorEvent : ReservaEvent
    {
        public ReservaSolicitadaComoAdministradorEvent
            (Guid id, Guid areaComumId, 
            string nomeAreaComum, Guid condominioId, string nomeCondominio,
            int capacidade, string observacao, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            string justificativa, string origem, bool reservadoPelaAdministracao,
            Guid funcionarioId, string nomeFuncionario)
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
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
        }    

    }
}
