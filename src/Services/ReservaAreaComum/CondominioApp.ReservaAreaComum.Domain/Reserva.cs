using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain
{
   public class Reserva : Entity
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
        public string Justificativa { get; private set; }
        public string Origem { get; private set; }
        public bool ReservadoPelaAdministracao { get; private set; }

        public string Status
        {
            get
            {
                if (!Ativa && !Lixeira && DataDeRealizacao < DataHoraDeBrasilia.Get())
                    return "Expirada";

                if (Ativa && !Lixeira && !EstaNaFila)
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

        public Reserva() { }

        public Reserva(Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade, 
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, bool ativa, decimal preco,
            bool estaNaFila, string justificativa, string origem, bool reservadoPelaAdministracao)
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
            Ativa = ativa;
            Preco = preco;
            EstaNaFila = estaNaFila;
            Justificativa = justificativa;
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

        public void SetJustificativa(string justificativa) => Justificativa = justificativa;

        public void SetOrigem(string origem) => Origem = origem;

              

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



        //public void ReprovarReserva(string justificativa)
        //{
        //    if (!string.IsNullOrEmpty(justificativa))
        //    {
        //        if (justificativa.Length > 5)
        //        {
        //            this.justificativa = justificativa;
        //            this.lixeira = true;
        //            this.ativo = false;
        //            this.fila = false;
        //        }
        //        else
        //            throw new Exception("Digite no mínimo 5 letras para a justificativa.");
        //    }
        //    else
        //        throw new Exception("É necessário inserir uma justificativa para a reprovação da reserva.");
        //}

    }
}
