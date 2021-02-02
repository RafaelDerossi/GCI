using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain
{
   public class Reserva : Entity, IHorario
    {
        public Guid AreaComumId { get; private set; }
        public string Observacao { get; private set; }
        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string DescricaoGrupoUnidade { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string NomeUsuario { get; private set; }
        public DateTime DataDeRealizacao { get; private set; }
        public string HoraInicio { get; private set; }
        public string HoraFim { get; private set; }
        public bool Ativa { get; private set; }        
        public decimal Preco { get; private set; }
        public bool EstaNaFila { get; private set; }
        public bool Cancelada { get; private set; }
        public string Justificativa { get; private set; }
        public string Origem { get; private set; }
        public bool ReservadoPelaAdministracao { get; private set; }

        public string Status
        {
            get
            {
                if (Cancelada && !Lixeira)
                    return "Cancelada";

                if (!Ativa && DataDeRealizacao < DataHoraDeBrasilia.Get() && !Lixeira)
                    return "Expirada";

                if (Ativa && !EstaNaFila && !Lixeira)
                    return "Aprovada";

                if (!Ativa && !EstaNaFila && !Lixeira)
                    return "Pendente";

                if (EstaNaFila && !Lixeira)
                    return "Fila de espera";

                if (Lixeira)
                    return "Removida";

                return "Nova";
            }
        }

        protected Reserva() { }

        public Reserva(Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade, 
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            bool estaNaFila, string origem, bool reservadoPelaAdministracao)
        {
            AreaComumId = areaComumId;
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
            Preco = preco;
            EstaNaFila = estaNaFila;
            Origem = origem;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;
        }


        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataDeRealizacao(DateTime dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;
        
        public void SetHoraInicioEHoraFim(string horaInicio, string horaFim)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        public void Aprovar() => Ativa = true;

        public void Reprovar() => Ativa = false;

        public void SetPreco(decimal preco) => Preco = preco;

        public void EnviarParaFila() => EstaNaFila = true;

        public void RemoverDaFila() => EstaNaFila = false;

        public void Cancelar(string justificativa)
        {
            Justificativa = justificativa;
            Cancelada = true;
        }
        

        public void SetOrigem(string origem) => Origem = origem;

        public void SetUnidade(Guid unidadeId,string numeroUnidade,string andarUnidade, string descricaoGrupoUnidade)
        {
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
        }

        public void SetUsuario(Guid usuarioId, string nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;            
        }


        public int ObterHoraInicio
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraInicio))
                    return Convert.ToInt32(HoraInicio.Replace(":", ""));

                return 0;
            }
        }

        public int ObterHoraFim
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraFim))
                    return Convert.ToInt32(HoraFim.Replace(":", ""));

                return 0;
            }
        }

                

        public DateTime ObterDataHoraInicioDaRealizacao()
        {
            return DataDeRealizacao
                   .AddHours(ObterAHoraDeInicioDaReserva)
                   .AddMinutes(ObterOMinutoDeInicioDaReserva);
        }

        public DateTime ObterDataHoraFimDaRealizacao()
        {
            return DataDeRealizacao
                   .AddHours(ObterAHoraDeFimDaReserva)
                   .AddMinutes(ObterOMinutoDeFimDaReserva);
        }

        private int ObterAHoraDeInicioDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraInicio))
                    return 0;

                string[] array = HoraInicio.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[0]);

                return 0;
            }
        }
        private int ObterOMinutoDeInicioDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraInicio))
                    return 0;

                string[] array = HoraInicio.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[1]);

                return 0;
            }
        }
        private int ObterAHoraDeFimDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraFim))
                    return 0;

                string[] array = HoraFim.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[0]);

                return 0;
            }
        }
        private int ObterOMinutoDeFimDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraFim))
                    return 0;

                string[] array = HoraFim.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[1]);

                return 0;
            }
        }
    }
}
