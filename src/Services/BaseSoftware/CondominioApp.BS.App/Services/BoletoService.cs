using System.Collections.Generic;
using System.IO;
using System.Linq;
using CondominioApp.BS.App.Services.Interfaces;
using Newtonsoft.Json;

namespace CondominioApp.BS.App.Services
{
    public class BoletoService : IBoletoService
    {
        string CaminhoDoIndiceDeBoleto = "\\Basesoftware\\boletos";

        string NomeDoArquivoDeIndices = "indiceDeBoletos.txt";

        public Boleto ObterBoletosDoCpf(string CaminhoBase, string cpf, string NomeDaPasta)
        {
            CaminhoBase = CaminhoBase.Replace("\\backend","");

            CaminhoDoIndiceDeBoleto = $"{CaminhoBase}{CaminhoDoIndiceDeBoleto}\\{NomeDaPasta}\\{NomeDoArquivoDeIndices}";

            if (!File.Exists(CaminhoDoIndiceDeBoleto)) return new Boleto();

            var ConteudoDoIndiceDeBoletos = File.ReadAllText(CaminhoDoIndiceDeBoleto);

            var ListaDeItensDeBoleto = JsonConvert.DeserializeObject<IEnumerable<ItemBoleto>>(ConteudoDoIndiceDeBoletos);

            var ItemDeCpfEncontrado = ListaDeItensDeBoleto.FirstOrDefault(x => x.cpf == cpf);

            if (ItemDeCpfEncontrado == null) return new Boleto();

            if (ItemDeCpfEncontrado.listaDeBoletos.FirstOrDefault() == "") return new Boleto();

            return new Boleto(ItemDeCpfEncontrado.listaDeBoletos.FirstOrDefault());
        }
    }
}