using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaHorariosConflitantes;
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

        public string TempoDeIntervaloEntreReservasPorUnidade { get; private set; }


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
            int numeroLimiteDeReservaSobrepostaPorUnidade, string tempoDeIntervaloEntreReservasPorUnidade,
            List<Periodo> periodos , List<Reserva> reservas)
        {
            _Periodos = periodos;
            _Reservas = reservas;
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
            TempoDeIntervaloEntreReservasPorUnidade = tempoDeIntervaloEntreReservasPorUnidade;
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

        public void AtivarAreaComum() => Ativa = true;
        public void DesativarAreaComum() => Ativa = false;

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

        public void SetTempoDeIntervaloEntreReservasPorUnidade(string intervalo) => 
            TempoDeIntervaloEntreReservasPorUnidade = intervalo;


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

        public ValidationResult AdicionarPeriodo(Periodo periodoNovo)
        {
            foreach (Periodo periodo in _Periodos)
            {               
                if (VerificadorDeHorariosConflitantes.Verificar(periodo, periodoNovo))
                {
                    AdicionarErrosDaEntidade("Período incompatível com outro período ja existente!");
                    return ValidationResult;
                }
            }  

            _Periodos.Add(periodoNovo);

            return ValidationResult;
        }
       
        public void RemoverTodosOsPeriodos()
        {
            _Periodos.Clear();
        }



        public void AdicionarReserva(Reserva reserva)
        {            
            _Reservas.Add(reserva);            
        }



        public ValidationResult ValidarReserva(Reserva reserva, IRegrasDeReserva regras)
        {   
            var resultado = regras.ValidarRegrasParaCriacao(reserva, this);
            return resultado;
        }
       



        public Reserva RetirarProximaReservaDaFila(Reserva reservaCancelada, IRegrasDeReserva regras)
        {
            var reservas = _Reservas
                .Where(x => x.Status == StatusReserva.NA_FILA &&
                       x.DataDeRealizacao == reservaCancelada.DataDeRealizacao &&
                       !x.Lixeira)
                .OrderBy(x => x.DataDeCadastro).ToList();

            if (reservas == null) return null;

            
            foreach (Reserva reserva in reservas)
            {
                var result = regras.ValidarRegrasParaCriacao(reserva, this);                 
                if (result.IsValid)
                {
                    _Reservas.Remove(reserva);
                    reserva.SetObservacao(reserva.Observacao + " (Reserva restaurada da fila)");
                    
                    if (RequerAprovacaoDeReserva)
                        reserva.AguardarAprovacao("Reserva restaurada da fila");

                    if (!RequerAprovacaoDeReserva)
                        reserva.Aprovar("Reserva restaurada da fila");

                    AdicionarReserva(reserva);

                    return reserva;
                }
                
            }
            return null;
        }
       

        public ValidationResult AprovarReservaPelaAdministracao(Guid reservaId, IRegrasDeReserva regras)
        {
            var reserva = _Reservas.FirstOrDefault(x => x.Id == reservaId);            

            var result = regras.VerificaReservasAprovadas(reserva, this);

            if (result.IsValid) reserva.Aprovar("");

            return result;
        }


        public ValidationResult CancelarReservaComoUsuario(Reserva reservaACancelar, string justificativa, IRegrasDeReserva regras)
        {
            var result = regras.ValidarRegrasParaCancelamentoPeloMorador(reservaACancelar, this);
            if (!result.IsValid)
                return result;

            reservaACancelar.Cancelar(justificativa + " (Cancelada pelo usuário)");

            return ValidationResult;
        }

        public ValidationResult CancelarReservaComoAdministrador(Reserva reservaACancelar, string justificativa, IRegrasDeReserva regras)
        {
            var result = regras.ValidarRegrasParaCancelamentoPelaAdministracao(reservaACancelar);
            if (!result.IsValid)
                return result;

            reservaACancelar.Cancelar(justificativa + " (Cancelada pela Administração)");           

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


        public int ObterMinutosDeIntervaloDeReservaPorUnidade
        {
            get
            {
                if (string.IsNullOrEmpty(TempoDeIntervaloEntreReservasPorUnidade))
                    return 0;

                string[] array = TempoDeIntervaloEntreReservasPorUnidade.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[1]);

                return 0;
            }
        }
        public int ObterHorasDeIntervaloDeReservaPorUnidade
        {
            get
            {
                if (string.IsNullOrEmpty(TempoDeIntervaloEntreReservasPorUnidade))
                    return 0;

                string[] array = TempoDeIntervaloEntreReservasPorUnidade.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[0]);

                return 0;
            }
        }
                
    }
}
