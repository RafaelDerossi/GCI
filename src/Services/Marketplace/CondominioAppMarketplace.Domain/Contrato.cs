using System;

namespace CondominioAppMarketplace.Domain
{
    public class Contrato
    {
        public const int DescricaoMaximo = 1000;

        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeRenovacao { get; set; }
        public string Descricao { get; set; }

        protected Contrato() { }

        public Contrato(DateTime dataDeInicio, DateTime dataDeRenovacao, string descricao)
        {
            DataDeInicio = dataDeInicio;
            DataDeRenovacao = dataDeRenovacao;
            Descricao = descricao;
        }

        public bool Expirando()
        {
            if (DateTime.Compare(DateTime.Now, DataDeRenovacao) <= 7)
                return true;
            else
                return false;
        }
        public bool Expirado()
        {
            if (DateTime.Compare(DateTime.Now, DataDeRenovacao) < 0)
                return true;
            else
                return false;
        }
    }
}
