using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public abstract class AreaComumCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public string TermoDeUso { get; protected set; }
        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }
        public int Capacidade { get; protected set; }
        public string DiasPermitidos { get; protected set; }
        public int AntecedenciaMaximaEmMeses { get; protected set; }
        public int AntecedenciaMaximaEmDias { get; protected set; }
        public int AntecedenciaMinimaEmDias { get; protected set; }
        public int AntecedenciaMinimaParaCancelamentoEmDias { get; protected set; }
        public bool RequerAprovacaoDeReserva { get; protected set; }
        public bool TemHorariosEspecificos { get; protected set; }     
        public string TempoDeIntervaloEntreReservas { get; protected set; }
        public bool Ativa { get; protected set; }
        public string TempoDeDuracaoDeReserva { get; protected set; }
        public int NumeroLimiteDeReservaPorUnidade { get; protected set; }
        public DateTime? DataInicioBloqueio { get; protected set; }
        public DateTime? DataFimBloqueio { get; protected set; }
        public bool PermiteReservaSobreposta { get; protected set; }
        public int NumeroLimiteDeReservaSobreposta { get; protected set; }
        public int NumeroLimiteDeReservaSobrepostaPorUnidade { get; protected set; }

        public ICollection<Periodo> Periodos;


        public void SetNome(string nome) => Nome = nome;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetNomeCondominio(string nome) => NomeCondominio = nome;

        public void SetDiasPermitidos(string dias) => DiasPermitidos = dias;

        public void SetAntecedenciaMaximaEmMeses(int meses) => AntecedenciaMaximaEmMeses = meses;

        public void SetAntecedenciaMaximaEmDias(int dias) => AntecedenciaMaximaEmDias = dias;

        public void SetAntecedenciaMinimaEmDias(int dias) => AntecedenciaMinimaEmDias = dias;

        public void SetAntecedenciaMinimaParaCancelamentoEmDias(int dias) => AntecedenciaMinimaParaCancelamentoEmDias = dias;

        public void RequerAprovacao() => RequerAprovacaoDeReserva = true;

        public void NaoRequerAprovacao() => RequerAprovacaoDeReserva = false;

        public void MarcarTemHorariosEspecificos() => TemHorariosEspecificos = true;

        public void MarcarNaoTemHorariosEspecificos() => TemHorariosEspecificos = false;

        public void SetTempoDeIntervaloEntreReservas(string dias) => TempoDeIntervaloEntreReservas = dias;

        public void SetTempoDeDuracaoDeReserva(string tempo) => TempoDeDuracaoDeReserva = tempo;

        public void SetNumeroLimiteDeReservaPorUnidade(int limite) => NumeroLimiteDeReservaPorUnidade = limite;

        public void MarcarPermiteReservaSobreposta() => PermiteReservaSobreposta = true;

        public void MarcarNaoPermiteReservaSobreposta() => PermiteReservaSobreposta = false;

        public void SetNumeroLimiteDeReservaSobreposta(int limite) => NumeroLimiteDeReservaSobreposta = limite;

        public void SetNumeroLimiteDeReservaSobrepostaPorUnidade(int limite) => NumeroLimiteDeReservaSobrepostaPorUnidade = limite;

        public void LimparPeriodos()
        {
            Periodos.Clear();
        }

        public void SetPeriodos(ICollection<Periodo> periodos)
        {
            Periodos = periodos;
        }

    }
}
