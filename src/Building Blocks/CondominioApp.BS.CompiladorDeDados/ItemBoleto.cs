using System.Collections.Generic;

namespace CondominioApp.BS.CompiladorDeDados
{
    public class ItemBoleto
    {
        public string cpf { get; private set; }
        public List<string> listaDeBoletos { get; private set; }

        public ItemBoleto(string cpf)
        {
            listaDeBoletos = new List<string>();
            this.cpf = cpf;
        }

        public void AdicionarLinkDoBoleto(string linkDoBoleto) => listaDeBoletos.Add(linkDoBoleto);

        public void LimparListaDeBoletos() => listaDeBoletos = new List<string>();
    }
}
