using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain
{
    public class AreaComum : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string TermoDeUso { get; private set; }
        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }
        public int Capacidade { get; private set; }
        public string DiasPermitidos { get; private set; }
        public int AntecedenciaMaximaEmMeses { get; private set; }
        public int AntecedenciaMaximaEmDias { get; private set; }
        public int AntecedenciaMinimaEmDias { get; private set; }
        public int AntecedenciaMinimaParaCancelamentoEmDias { get; private set; }
        public bool RequerAprovacaoDeReserva { get; private set; }
        public bool TemHorariosEspecificos { get; private set; }
        public string TempoDeIntervaloEntreReservas {  get; private set; }
        public bool Ativa { get; private set; }
        public string TempoDeDuracaoDeReserva { get; private set; }
        public int NumeroLimiteDeReservaPorUnidade { get; private set; }
        public DateTime? DataInicioBloqueio { get; private set; }
        public DateTime? DataFimBloqueio { get; private set; }
        public bool PermiteReservaSobreposta { get; private set; }
        public int NumeroLimiteDeReservaSobreposta { get; private set; }
        public int NumeroLimiteDeReservaSobrepostaPorUnidade { get; private set; }


        private readonly List<Periodo> _Periodos;
        public IReadOnlyCollection<Periodo> Periodos => _Periodos;


        private readonly List<Reserva> _Reservas;
        public IReadOnlyCollection<Reserva> Reservas => _Reservas;
        

        
        /// Construtores       
        protected AreaComum()
        {
            _Periodos = new List<Periodo>();
            _Reservas = new List<Reserva>();           
        }

        public AreaComum
            (string nome, string descricao, string termoDeUso, Guid condominioId, string nomeCondominio,
            int capacidade, string diasPermitidos, int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias,
            int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva,
            bool horariosEspecificos, string tempoDeIntervaloEntreReservas, bool ativo, string tempoDeDuracaoDaReserva,
            int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta,
            int numeroLimiteDeReservaSobrepostaPorUnidade)
        {
            _Periodos = new List<Periodo>();
            _Reservas = new List<Reserva>();
            Nome = nome;
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Capacidade = capacidade;
            DiasPermitidos = diasPermitidos;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = horariosEspecificos;           
            TempoDeIntervaloEntreReservas = tempoDeIntervaloEntreReservas;
            Ativa = ativo;
            TempoDeDuracaoDeReserva = tempoDeDuracaoDaReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            PermiteReservaSobreposta = permiteReservaSobreposta;
            NumeroLimiteDeReservaSobreposta = numeroLimiteDeReservaSobreposta;
            NumeroLimiteDeReservaSobrepostaPorUnidade = numeroLimiteDeReservaSobrepostaPorUnidade;
        }


        /// Metodos Set
        public void SetNome(string nome) => Nome = nome;
        public void SetDescricao(string descricao) => Descricao = descricao;
        public void SetTermoDeUso(string termo) => TermoDeUso = termo;
        public void SetCapacidade(int capacidade) => Capacidade = capacidade;
        public void SetDiasPermitidos(string diasPermitidos) => DiasPermitidos = diasPermitidos;
        public void SetAntecedenciaMaximaEmMeses(int antecedenciaMaximaEmMeses) => 
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
        public void SetAntecedenciaMaximaEmDias(int antecedenciaMaximaEmDias) =>
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
        public void SetAntecedenciaMinimaEmDias(int antecedenciaMinimaEmDias) =>
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
        public void SetAntecedenciaMinimaParaCancelamentoEmDias(int antecedenciaMinimaParaCancelamento) =>
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamento;

        public void HabilitarAprovacaoDeReserva() => RequerAprovacaoDeReserva = true;
        public void DesabilitarAprovacaoDeReserva() => RequerAprovacaoDeReserva = false;

        public void HabilitarHorariosEspecifcos() => TemHorariosEspecificos = true;
        public void DesabilitarHorariosEspecifcos() => TemHorariosEspecificos = false;
       
        public void SetTempoDeIntervaloEntreReservas(string intervalo) => TempoDeIntervaloEntreReservas = intervalo;

        public void SetTempoDeDuracaoDeReserva(string tempo) => TempoDeDuracaoDeReserva = tempo;

        public void AtivarAreaComun() => Ativa = true;
        public void DesativarAreaComun() => Ativa = false;

        public void SetNumeroLimiteDeReservaPorUnidade(int numeroLimite) => 
            NumeroLimiteDeReservaPorUnidade = numeroLimite;

        public void SetDataInicioBloqueio(DateTime dataInicioBoqueio) => DataInicioBloqueio = dataInicioBoqueio;

        public void SetDataFimBloqueio(DateTime dataFimBoqueio) => DataFimBloqueio = dataFimBoqueio;


        public void HabilitarReservaSobreposta() => PermiteReservaSobreposta = true;
        public void DesabilitarReservaSobreposta() => PermiteReservaSobreposta = false;

        public void SetNumeroLimiteDeReservaSobreposta(int numero) =>
            NumeroLimiteDeReservaSobreposta = numero;

        public void SetNumeroLimiteDeReservaSobrepostaPorUnidade(int numero) =>
            NumeroLimiteDeReservaSobrepostaPorUnidade = numero;




        /// Outros Metodos 
        public bool TemTermoDeUso
        {
            get
            {
                return !string.IsNullOrEmpty(TermoDeUso);
            }
        }      
        
        public override string ToString()
        {
            return Nome + "|" + Descricao;
        }

        public string EstadoAtual
        {
            get
            {
                if (Ativa)
                    return "Ativa";
                else
                    return "Inativa";
            }
        }

        public int ObterTempoDeIntervaloEntreReservas
        {
            get
            {
                if (!string.IsNullOrEmpty(TempoDeIntervaloEntreReservas))
                    return Convert.ToInt32(TempoDeIntervaloEntreReservas.Replace(":", ""));

                return 0;
            }
        }

        public int ObterTempoDeDuracaoDeReserva
        {
            get
            {
                if (!string.IsNullOrEmpty(TempoDeDuracaoDeReserva))
                    return Convert.ToInt32(TempoDeDuracaoDeReserva.Replace(":", ""));

                return 0;
            }
        }

        public bool TemIntervaloFixoEntreReservas
        {
            get
            {
                return ObterTempoDeIntervaloEntreReservas > 0;
            }
        }

        public ValidationResult AdicionarPeriodo(Periodo periodo)
        {          

            if (_Periodos.Any(u => u.HoraInicio == periodo.HoraInicio || u.HoraFim == periodo.HoraFim))
            {
                AdicionarErrosDaEntidade("Período repetido!");
                return ValidationResult;
            }

            if (
                _Periodos.Any(p => p.ObterHoraInicio < periodo.ObterHoraInicio && p.ObterHoraFim > periodo.ObterHoraInicio) ||
                _Periodos.Any(p => p.ObterHoraInicio > periodo.ObterHoraInicio && p.ObterHoraInicio < periodo.ObterHoraFim) ||
                _Periodos.Any(p => p.ObterHoraInicio > periodo.ObterHoraFim && p.ObterHoraFim > periodo.ObterHoraInicio)
                )
            {
                AdicionarErrosDaEntidade("Período incompatível com outro período ja existente!");
                return ValidationResult;
            }
          
            _Periodos.Add(periodo);

            return ValidationResult;
        }

        public void RemoverTodosOsPeriodos()
        {
            _Periodos.Clear();
        }



        public ValidationResult AdicionarReserva(Reserva reserva)
        {
            var result = ValidarReserva(reserva);
            if (!result.IsValid) return result;

            if (!RequerAprovacaoDeReserva) reserva.Aprovar();
            
            _Reservas.Add(reserva);
           
            return ValidationResult;
        }
        private ValidationResult ValidarReserva(Reserva reserva)
        {
            GerenciadorDeReserva Gerenciador;

            if (reserva.Origem != "Sistema Web")
            {
                Gerenciador = new GerenciadorDeReserva(new RegrasDeClienteParaReservar(reserva, this));

                var resultado = Gerenciador.Validar();

                if (!resultado.IsValid) return resultado;
            }
            else
            {
                Gerenciador = new GerenciadorDeReserva(new RegrasDeAdministradorParaReservar(reserva, this));

                var resultado = Gerenciador.Validar();

                if (!resultado.IsValid) return resultado;
            }

            if (PermiteReservaSobreposta)
                Gerenciador = new GerenciadorDeReserva(
                    new RegrasGlobaisParaReservar(reserva, this, new RegraDeReservaSobreposta(this, reserva)));
            else
                Gerenciador = new GerenciadorDeReserva(
                    new RegrasGlobaisParaReservar(reserva, this, new RegrasDeReservaLimiteDeVagasPorHorario(reserva, this)));


            return Gerenciador.Validar();
        }
      

        public Reserva RetirarProximaReservaDaFila(Reserva reservaCancelada)
        {
            var reservas = _Reservas
                .Where(x => x.EstaNaFila &&
                       x.DataDeRealizacao == reservaCancelada.DataDeRealizacao &&
                       !x.Cancelada && 
                       !x.Lixeira)
                .OrderBy(x => x.DataDeCadastro).ToList();

            if (reservas == null) return null;

            
            foreach (Reserva reserva in reservas)
            {
                _Reservas.Remove(reserva);
                reserva.RemoverDaFila();               

                var result = AdicionarReserva(reserva);                 
                if (result.IsValid)
                {
                    reserva.SetObservacao(reserva.Observacao + " (Reserva restaurada da fila)");
                    return reserva;
                }                    
                else
                {
                    reserva.EnviarParaFila();
                    AdicionarReserva(reserva);
                }                
            }
            return null;
        }
       

        public ValidationResult AprovarReservaPendente(Guid reservaId)
        {
            var reserva = _Reservas.FirstOrDefault(x => x.Id == reservaId);

            var ValidacaoGlobal = new RegrasGlobaisParaReservar(reserva, this, new RegrasDeReservaLimiteDeVagasPorHorario(reserva, this));

            var result = ValidacaoGlobal.VerificaReservasAprovadas();

            if (result.IsValid) reserva.Aprovar();

            return result;
        }


        public ValidationResult CancelarReservaComoUsuario(Reserva reservaACancelar, string justificativa)
        {
            if (reservaACancelar.EstaNaFila)
                reservaACancelar.Cancelar(justificativa);
            else
            {
                var result = ValidarRemocaoDeReserva(reservaACancelar);
                if (!result.IsValid) return result;

                reservaACancelar.Cancelar(justificativa + " (Cancelada pelo usuário)");               
            }          

            return ValidationResult;
        }
        public ValidationResult CancelarReservaComoAdministrador(Reserva reservaACancelar, string justificativa)
        {
            reservaACancelar.Cancelar(justificativa + " (Cancelada pela Administração)");           

            return ValidationResult;
        }
        private ValidationResult ValidarRemocaoDeReserva(Reserva reserva)
        {
            var dataAtual = DataHoraDeBrasilia.Get();

            if (reserva.Ativa)
            {
                int qtdDias = Convert.ToInt32((reserva.DataDeRealizacao.Date - dataAtual.Date).TotalDays);
                if (qtdDias <= AntecedenciaMinimaParaCancelamentoEmDias && AntecedenciaMinimaParaCancelamentoEmDias > 0)
                {
                    AdicionarErrosDaEntidade("Prazo para cancelamento expirado!");
                    return ValidationResult;
                }
                else if (qtdDias == 0 && AntecedenciaMinimaParaCancelamentoEmDias == 0)
                {
                    var horaAtual = dataAtual.ToString("HH:mm");
                    var horaAtualInt = Convert.ToInt32(horaAtual.Replace(":", ""));

                    if (horaAtualInt >= reserva.ObterHoraInicio)
                    {
                        AdicionarErrosDaEntidade("Prazo para cancelamento expirado!");
                        return ValidationResult;
                    }
                }
                else if (qtdDias < 0 && AntecedenciaMinimaParaCancelamentoEmDias == 0)
                {
                    AdicionarErrosDaEntidade("Prazo para cancelamento expirado!");
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }

        public Reserva ObterReserva(Guid reservaId)
        {
            return _Reservas.FirstOrDefault(x => x.Id == reservaId);           
        }

        public override bool Equals(object obj)
        {
            var comum = obj as AreaComum;
            return comum != null &&
                   Nome.ToUpper() == comum.Nome.ToUpper();
        }

        public override int GetHashCode()
        {
            return 109702896 + EqualityComparer<string>.Default.GetHashCode(Nome);
        }

        public string HorariosDeInicioEFimParaReservar()
        {
            var horarioInicio = string.Empty;
            var horarioFinal = string.Empty;

            if (_Periodos == null) return horarioInicio + "|" + horarioFinal;

            horarioInicio = _Periodos.OrderBy(p => p.ObterHoraInicio).FirstOrDefault().HoraInicio;
            horarioFinal = _Periodos.OrderByDescending(p => p.ObterHoraFim).FirstOrDefault().HoraFim;

            return horarioInicio + "|" + horarioFinal;
        }

        public int HorarioDeInicioParaReservar()
        {
            if (_Periodos == null) return 0;

            return _Periodos.OrderBy(p => p.ObterHoraInicio).FirstOrDefault().ObterHoraInicio;
        }

        public int HorarioDeFimParaReservar()
        {
            if (_Periodos == null) return 0;

            return _Periodos.OrderByDescending(p => p.ObterHoraFim).FirstOrDefault().ObterHoraFim;
        }      
        
    }
}
