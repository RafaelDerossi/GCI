using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Principal.Domain;
using System;

namespace CondominioApp.Principal.Aplication
{
    public class ContratoViewModel
    {
        public Guid Id { get; set; }

        public Guid CondominioId { get; set; }

        public DateTime DataAssinatura { get; set; }

        public TipoDePlano Plano { get; set; }

        public string TipoDescricao
        {
            get
            {
                return Plano switch
                {
                    TipoDePlano.SEM_CONTRATO => "Sem Contrato",
                    TipoDePlano.FREE => "Free",
                    TipoDePlano.STANDARD => "Standard",
                    TipoDePlano.PREMIUM => "Premium",
                    _ => "Não Informado",
                };
            }
        }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public int QuantidadeDeUnidadesContratadas { get; set; }

        public string NomeArquivoContrato { get; set; }

        public string NomeOriginalArquivoContrato { get; set; }

        public string ExtencaoArquivoContrato { get; set; }        

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

        public ContratoViewModel(Contrato contrato )
        {
            Id = contrato.Id;
            CondominioId = contrato.CondominioId;
            DataAssinatura = contrato.DataAssinatura;
            Plano = contrato.Tipo;
            Descricao = contrato.Descricao;
            Ativo = contrato.Ativo;
            QuantidadeDeUnidadesContratadas = contrato.QuantidadeDeUnidadesContratada;
            NomeArquivoContrato = contrato.ArquivoContrato.NomeDoArquivo;
            NomeOriginalArquivoContrato = contrato.ArquivoContrato.NomeOriginal;
            ExtencaoArquivoContrato = contrato.ArquivoContrato.ExtensaoDoArquivo;
        }
    }
}
