using System;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class PeriodoFlat
    {
        public Guid Id { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeAlteracao { get; private set; }
        public bool Lixeira { get; private set; }
        public string HoraInicio { get; private set; }
        public string HoraFim { get; private set; }     
        public Guid AreaComumFlatId { get; private set; }        
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }

        protected PeriodoFlat() { }

        public PeriodoFlat(Guid id, Guid areaComumId, string horaInicio, string horaFim, decimal valor, bool ativo)
        {
            Id = id;
            AreaComumFlatId = areaComumId;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Valor = valor;
            Ativo = ativo;
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;
        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;
    }
}
