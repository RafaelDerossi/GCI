using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
   public class AreaComumViewModel
    {
        public Guid Id { get; set; }
        public string DataDeCadastro { get; set; }
        public string DataDeAlteracao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TermoDeUso { get; set; }
        public Guid CondominioId { get; set; }
        public string NomeCondominio { get; set; }
        public int Capacidade { get; set; }
        public string DiasPermitidos { get; set; }
        public int AntecedenciaMaximaEmMeses { get; set; }
        public int AntecedenciaMaximaEmDias { get; set; }
        public int AntecedenciaMinimaEmDias { get; set; }
        public int AntecedenciaMinimaParaCancelamentoEmDias { get; set; }
        public bool RequerAprovacaoDeReserva { get; set; }
        public bool TemHorariosEspecificos { get; set; }
        public string TempoDeIntervaloEntreReservas { get; set; }
        public bool Ativa { get; set; }
        public string TempoDeDuracaoDeReserva { get; set; }
        public int NumeroLimiteDeReservaPorUnidade { get; set; }
        public string DataInicioBloqueio { get; set; }
        public string DataFimBloqueio { get; set; }
        public bool PermiteReservaSobreposta { get; set; }
        public int NumeroLimiteDeReservaSobreposta { get; set; }
        public int NumeroLimiteDeReservaSobrepostaPorUnidade { get; set; }
       
        public ICollection<PeriodoViewModel> Periodos { get; set; }
    }
}
