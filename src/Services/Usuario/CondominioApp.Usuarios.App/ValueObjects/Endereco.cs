namespace CondominioApp.Usuarios.App.ValueObjects
{
    public class Endereco
    {
        public const int LogradouroMaximo = 200, ComplementoMaximo = 200, NumeroMaximo = 50, CepNumero = 10, BairroMaximo = 200, CidadeMaximo = 200, EstadoMaximo = 100, MunicipioMaximo = 200;

        public string logradouro { get; private set; }

        public string complemento { get; private set; }

        public string numero { get; private set; }

        public string cep { get; private set; }

        public string bairro { get; private set; }

        public string cidade { get; private set; }

        public string estado { get; private set; }    

        public string ObterCepFormatado
        {
            get
            {
                int Contador = 0;
                string CepComMascara = "";

                if (string.IsNullOrEmpty(cep)) return cep;

                foreach (var digito in cep)
                {
                    if (Contador == 5)
                        CepComMascara += "-";

                    CepComMascara += digito;

                    Contador++;
                }

                return CepComMascara;
            }
        }

        protected Endereco() { }

        public Endereco(string Logradouro, string Complemento, string Numero, string CepDoEndereco,
            string Bairro, string Cidade, string Estado)
        {
            setLogradouro(Logradouro);
            setComplemento(Complemento);
            setNumero(Numero);
            setBairro(Bairro);
            setCidade(Cidade);
            setEstado(Estado);
            setCep(CepDoEndereco);            
        }

        public void setLogradouro(string logradouroStr)
        {
            if (!string.IsNullOrEmpty(logradouroStr))
                logradouro = logradouroStr.Trim().ToUpper();
        }       

        public void setComplemento(string complementoStr)
        {
            if (!string.IsNullOrEmpty(complementoStr))
                complemento = complementoStr.Trim().ToUpper();
            else
                complemento = "-";
        }

        public void setNumero(string numeroStr)
        {
            if (!string.IsNullOrEmpty(numeroStr))
                numero = numeroStr.Trim().ToUpper();
            else
                numero = "S/N";
        }

        public void setCep(string cepStr)
        {
            if (!string.IsNullOrEmpty(cepStr))
                cep = new Cep(cepStr).Numero;
        }

        public void setBairro(string bairroStr)
        {
            if (!string.IsNullOrEmpty(bairroStr))
                bairro = bairroStr.Trim().ToUpper();
            else
                bairro = "-";
        }

        public void setCidade(string cidadeStr)
        {
            if (!string.IsNullOrEmpty(cidadeStr))
                cidade = cidadeStr.Trim().ToUpper();
        }

        public void setEstado(string estadoStr)
        {
            if (!string.IsNullOrEmpty(estadoStr))
                estado = estadoStr.Trim().ToUpper();
        }

        public override string ToString()
        {
            return logradouro + " " + complemento + ", " + numero + ", " + bairro + " " + cidade + " " + estado;
        }
    }
}