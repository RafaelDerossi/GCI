using CondominioApp.Core.DomainObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain
{
    public class AreaComum : Entity
    {
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
        public bool TemIntervaloFixoEntreReservas { get; private set; }
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
        public AreaComum()
        {
            _Periodos = new List<Periodo>();
            _Reservas = new List<Reserva>();           
        }

        public AreaComum
            (string nome, string descricao, string termoDeUso, Guid condominioId, string nomeCondominio,
            int capacidade, string diasPossiveis, int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias,
            int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva,
            bool horariosEspecificos, bool intervaloFixo, string intervalo, bool ativo, string duracaoDaReserva,
            int numeroLimiteDeReservaPorUnidade, DateTime? dataBloqueioInicio, DateTime? dataBloqueioFim,
            bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta,
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
            DiasPermitidos = diasPossiveis;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = horariosEspecificos;
            TemIntervaloFixoEntreReservas = intervaloFixo;
            TempoDeIntervaloEntreReservas = intervalo;
            Ativa = ativo;
            TempoDeDuracaoDeReserva = duracaoDaReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            DataInicioBloqueio = dataBloqueioInicio;
            DataFimBloqueio = dataBloqueioFim;
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

        public void HabilitarIntervaloFixoEntreReservas() => TemIntervaloFixoEntreReservas = true;
        public void DesabilitarIntervaloFixoEntreReservas() => TemIntervaloFixoEntreReservas = false;
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


        //public ValidationResult AdicionarReserva(Reserva reserva)
        //{
        //    GerenciadorDeReserva Gerenciador;

        //    if (reserva.origem != "Sistema Web")
        //    {
        //        Gerenciador = new GerenciadorDeReserva(new RegrasDeClienteParaReservar(reserva, this));

        //        var validacaoDeCliente = Gerenciador.Validar();

        //        if (validacaoDeCliente.Key != 0) return validacaoDeCliente;
        //    }

        //    if (PermiteReservaSobreposta.Value && !aprovacaoAdministracao)
        //        Gerenciador = new GerenciadorDeReserva(new RegrasGlobaisParaReservar(reserva, this, new RegrasDeReservaLimiteDeVagasPorHorario(this, reserva)));
        //    else
        //        Gerenciador = new GerenciadorDeReserva(new RegrasGlobaisParaReservar(reserva, this, new RegraDeReservaSobreposta(reserva, this)));

        //    var RegrasGlobaisValidation = Gerenciador.Validar();

        //    if (RegrasGlobaisValidation.Key != 0) return RegrasGlobaisValidation;

        //    if (!aprovacaoAdministracao) reserva.Aprovar();

        //    reservas.Add(reserva);

        //    if (!aprovacaoAdministracao) return new KeyValuePair<int, string>(0, "Reserva adicionada com sucesso!");



        //    return ValidationResult;
        //}
      

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

        //public string getMaxMinHora()
        //{
        //    var horarioInicio = string.Empty;
        //    var horarioFinal = string.Empty;

        //    if (_Periodos == null) return horarioInicio + "|" + horarioFinal;

        //    horarioInicio = _Periodos.OrderBy(p => p.HoraInicio).FirstOrDefault().horaInicio;
        //    horarioFinal = _Periodos.OrderByDescending(p => p.HoraFim).FirstOrDefault().horaFim;

        //    return horarioInicio + "|" + horarioFinal;
        //}

        //public int HorarioDeInicioParaReservar()
        //{
        //    if (periodos == null) return 0;

        //    return periodos.OrderBy(p => p.HoraInicio).FirstOrDefault().HoraInicio;
        //}

        //public int HorarioDeFimParaReservar()
        //{
        //    if (periodos == null) return 0;

        //    return periodos.OrderByDescending(p => p.HoraFim).FirstOrDefault().HoraFim;
        //}

        //public KeyValuePair<int, string> AprovarReservaPendente(Reserva reserva)
        //{
        //    var ValidacaoGlobal = new RegrasGlobaisParaReservar(reserva, this, new RegraDeReservaSobreposta(reserva, this));

        //    var ret = ValidacaoGlobal.VerificaReservasAprovadas();

        //    if (ret.Key == 0) reserva.Aprovar();

        //    return ret;
        //}

        //public void AdicionarReservaParaFila(Reserva reserva)
        //{
        //    reserva.EnviarParaFila();

        //    if (!aprovacaoAdministracao) reserva.Aprovar();

        //    if (reserva.id == 0) reservas.Add(reserva);
        //}

        //public Reserva RemoverReserva(int reservaId, string justificativa)
        //{
        //    var reserva = reservas.FirstOrDefault(x => x.id == reservaId);

        //    if (reserva.fila)
        //        reserva.justificativa = justificativa;
        //    else
        //    {
        //        if (ValidarRemocaoDeReserva(reserva))
        //            reserva.justificativa = "Removida pelo usuário";
        //        else
        //            return null;
        //    }

        //    reserva.EnviarParaLixeira();

        //    return reserva;
        //}

        //public Reserva RemoverReservaComoAdministrador(int reservaId, string justificativa)
        //{
        //    var reserva = this.reservas.Where(x => x.id == reservaId).FirstOrDefault();

        //    reserva.justificativa = justificativa;

        //    reserva.EnviarParaLixeira();

        //    return reserva;
        //}

        //public Reserva RetornaProximaReservaDaFila()
        //{
        //    if (!reservas.Any(x => x.fila)) return null;

        //    if (aprovacaoAdministracao) return RetornaReservaNaoAprovadaDaFila();

        //    return RetornaReservaAprovadaDaFila();

        //}

        //private Reserva RetornaReservaAprovadaDaFila()
        //{
        //    var reserva = reservas.OrderBy(x => x.dataDeCadastro).FirstOrDefault(x => x.fila && x.ativo);
        //    if (reserva == null) return reserva;

        //    reserva.RemoverDaFila();
        //    reserva.observacao += " (Reserva restaurada da fila)";

        //    return reserva;
        //}

        //private Reserva RetornaReservaNaoAprovadaDaFila()
        //{
        //    var reserva = reservas.OrderBy(x => x.dataDeCadastro).FirstOrDefault(x => x.fila && !x.ativo);
        //    if (reserva == null) return reserva;

        //    reserva.RemoverDaFila();
        //    reserva.observacao += " (Reserva restaurada da fila)";

        //    return reserva;
        //}

        //private bool ValidarRemocaoDeReserva(Reserva reserva)
        //{
        //    var dataAtual = DataHoraBrasilia.Get();

        //    if (reserva.ativo)
        //    {
        //        int qtdDias = Convert.ToInt32((reserva.dataDeRealizacao.Date - dataAtual.Date).TotalDays);
        //        if (qtdDias <= cancelamentoDias && cancelamentoDias > 0)
        //        {
        //            return false;
        //        }
        //        else if (qtdDias == 0 && cancelamentoDias == 0)
        //        {
        //            var horaAtual = dataAtual.ToString("HH:mm");
        //            var horaAtualInt = Convert.ToInt32(horaAtual.Replace(":", ""));

        //            if (horaAtualInt >= reserva.HoraInicio)
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    return true;
        //}
    }
}
