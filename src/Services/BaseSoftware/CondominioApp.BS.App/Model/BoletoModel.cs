namespace CondominioApp.BS.App.Model
{
    public class BoletoModel
    {
        public string ID { get; set; }
        public string ID_UNIDADE { get; set; }
        public string VENCIMENTO { get; set; }
        public string DATA_LIMITE { get; set; }
        public string VALOR { get; set; }
        public string MULTA { get; set; }
        public string JUROS { get; set; }
        public string CORRECAO { get; set; }
        public string VALOR_TOTAL { get; set; }
        public string LINHA_DIGITAVEL { get; set; }
        public string BENEFICIARIO { get; set; }
        public string BENEFICIARIOCNPJ { get; set; }
        public string PAGADOR { get; set; }
        public string DATADODOCUMENTO { get; set; }
        public string MENSAGEM { get; set; }
        public string URLBOLETO { get; set; }

        public BoletoModel(string id, string vencimento, string valor, string linhaDigitavel,
            string beneficiario, string beneficiariocnpj, string pagador, string datadodocumento, string mensagem, string urlboleto)
        {
            ID = id;
            VENCIMENTO = vencimento;
            VALOR = valor;
            LINHA_DIGITAVEL = linhaDigitavel;
            BENEFICIARIO = beneficiario;
            BENEFICIARIOCNPJ = beneficiariocnpj;
            PAGADOR = pagador;
            DATADODOCUMENTO = datadodocumento;
            MENSAGEM = mensagem;
            URLBOLETO = urlboleto;
        }
    }
}
