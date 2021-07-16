using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class AreaComumFlat : IAggregateRoot
    {
        public const int Max = 200;

        public Guid Id { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeAlteracao { get; private set; }
        public bool Lixeira { get; private set; }

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
        public string TempoDeIntervaloEntreReservas { get; private set; }
        public bool Ativa { get; private set; }
        public string TempoDeDuracaoDeReserva { get; private set; }
        public int NumeroLimiteDeReservaPorUnidade { get; private set; }
        public DateTime? DataInicioBloqueio { get; private set; }
        public DateTime? DataFimBloqueio { get; private set; }
        public bool PermiteReservaSobreposta { get; private set; }
        public int NumeroLimiteDeReservaSobreposta { get; private set; }
        public int NumeroLimiteDeReservaSobrepostaPorUnidade { get; private set; }
        public bool TemIntervaloFixoEntreReservas { get; private set; }
        public string TempoDeIntervaloEntreReservasPorUnidade { get; private set; }
        public string NomeArquivoAnexo { get; private set; }
        public string NomeOriginalArquivoAnexo { get; private set; }
        public string UrlArquivoAnexo
        {
            get
            {
                if (NomeArquivoAnexo == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), NomeArquivoAnexo);
            }
        }

        private readonly List<PeriodoFlat> _Periodos;
        public IReadOnlyCollection<PeriodoFlat> Periodos => _Periodos;



        /// Construtores       
        protected AreaComumFlat()
        {
            _Periodos = new List<PeriodoFlat>();
        }

        public AreaComumFlat
            (Guid id, string nome, string descricao, string termoDeUso, Guid condominioId, string nomeCondominio,
            int capacidade, string diasPermitidos, int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias,
            int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva,
            bool horariosEspecificos, string tempoDeIntervaloEntreReservas, bool ativo, string tempoDeDuracaoDaReserva,
            int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta,
            int numeroLimiteDeReservaSobrepostaPorUnidade, bool temIntervaloFixoEntreReservas,
            string tempoDeIntervaloEntreReservasPorUnidade,  string nomeOriginalArquivoAnexo, string nomeArquivoAnexo)
        {
            _Periodos = new List<PeriodoFlat>();
            Id = id;
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
            TemIntervaloFixoEntreReservas = temIntervaloFixoEntreReservas;
            TempoDeIntervaloEntreReservasPorUnidade = tempoDeIntervaloEntreReservasPorUnidade;
            NomeOriginalArquivoAnexo = nomeOriginalArquivoAnexo;
            NomeArquivoAnexo = nomeArquivoAnexo;
        }


        /// Metodos Set 
        public void SetEntidadeId(Guid NovoId) => Id = NovoId;
        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;
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

        public void SetTemIntervaloFixoEntreReservas(bool temIntervaloFixoEntreReservas) =>
          TemIntervaloFixoEntreReservas = temIntervaloFixoEntreReservas;

        public void SetTempoDeIntervaloEntreReservasPorUnidade(string intervalo) => TempoDeIntervaloEntreReservasPorUnidade = intervalo;

        public void SetNomeArquivoAnexo(string nomeOriginalArquivo, string nomeArquivo)
        {
            NomeOriginalArquivoAnexo = nomeOriginalArquivo;
            NomeArquivoAnexo = nomeArquivo;
        }

        ///Outros Metodos
        ///
        public void AdicionarPeriodo(PeriodoFlat periodoNovo)
        {
            _Periodos.Add(periodoNovo);
        }

        public void RemoverTodosOsPeriodos()
        {
            _Periodos.Clear();
        }

        public IEnumerable<string> ListaDiasPermitidos
        {
            get
            {
                List<string> listaDias = new List<string>();
                string[] dias = DiasPermitidos.Split("|");
                for (int i = 0; i < dias.Length; i++)
                {
                    listaDias.Add(dias[i]);
                }

                return listaDias;
            }
        }


    }
}
