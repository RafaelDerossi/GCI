using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;

namespace CondominioApp.Principal.Aplication
{
    public class ContratoViewModel
    {
        public Guid Id { get; set; }

        public Guid CondominioId { get; set; }

        public DateTime DataAssinatura { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public int QuantidadeDeUnidadesContratadas { get; set; }

        public string NomeArquivoContrato { get; set; }

        public string NomeOriginalArquivoContrato { get; set; }

        public string UrlArquivoContrato
        {
            get
            {
                if (NomeArquivoContrato == null || NomeArquivoContrato == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), NomeArquivoContrato);
            }
        }


        /// <summary>
        /// Construtores
        /// </summary>
        protected ContratoViewModel()
        {
        }

        public ContratoViewModel
            (Guid id, Guid condominioId, DateTime dataAssinatura, TipoDePlano tipo, 
             string descricao, bool ativo, int quantidadeDeUnidadesContratadas,
             string nomeArquivoContrato, string nomeOriginalArquivoContrato)
        {
            Id = id;
            CondominioId = condominioId;
            DataAssinatura = dataAssinatura;
            Tipo = tipo.ToString();
            Descricao = descricao;
            Ativo = ativo;
            QuantidadeDeUnidadesContratadas = quantidadeDeUnidadesContratadas;
            NomeArquivoContrato = nomeArquivoContrato;
            NomeOriginalArquivoContrato = nomeOriginalArquivoContrato;
        }
    }
}
