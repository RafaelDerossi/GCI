using System;

namespace CondominioApp.BS.App.Services
{
    public class Boleto
    {
        public Guid Id { get; private set; }

        public string Beneficiario { get; private set; }

        public string BeneficiarioCnpj { get; private set; }

        public string Vencimento { get; private set; }

        public string Pagador { get; private set; }

        public string DataDoc { get; private set; }

        public string ValorDoc { get; private set; }

        public string Mensagem { get; private set; }

        public string CodeBarra { get; private set; }

        public string UrlBoleto { get; private set; }

        public Boleto(string LinkDoBoleto)
        {
            string[] arrCodigo = LinkDoBoleto.Split('?');

            string[] arrItensLink = arrCodigo[1].Split('&');

            foreach (var item in arrItensLink)
            {
                if (item.Contains("codbar="))
                    CodeBarra = item.Replace("codbar=", "");

                if (item.Contains("datadoc="))
                    DataDoc = item.Replace("datadoc=", "");

                if (item.Contains("vencto="))
                    Vencimento = item.Replace("vencto=", "");

                if (item.Contains("cgccpfced="))
                    BeneficiarioCnpj = item.Replace("cgccpfced=", "");

                if (item.Contains("cedente="))
                   Beneficiario = item.Replace("cedente=", "");

                if (item.Contains("sacado="))
                    Pagador = item.Replace("sacado=", "");

                if (item.Contains("valor="))
                    ValorDoc = item.Replace("valor=", "");
            }

            SetUrlBoleto(LinkDoBoleto);
        }

        public Boleto() { }
        

        public void SetUrlBoleto(string urlBoleto) => UrlBoleto = Uri.UnescapeDataString(urlBoleto);
    }
}
