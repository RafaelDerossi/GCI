using System.Collections.Generic;
using System.IO;
using System.Linq;
using CondominioApp.BS.App.Services.Interfaces;
using Newtonsoft.Json;

namespace CondominioApp.BS.App.Services
{
    public class BoletoService : IBoletoService
    {
        string CaminhoDoIndiceDeBoleto = "./wwwroot/boletos";
        string NomeDoArquivoDeIndices = "indiceDeBoletos.txt";

        public Boleto ObterBoletosDoCpf(string cpf, string NomeDaPasta)
        {
            CaminhoDoIndiceDeBoleto = $"{CaminhoDoIndiceDeBoleto}/{NomeDaPasta}/{NomeDoArquivoDeIndices}";

            if (!File.Exists(CaminhoDoIndiceDeBoleto)) return new Boleto();

            var ConteudoDoIndiceDeBoletos = File.ReadAllText(CaminhoDoIndiceDeBoleto);

            var ListaDeItensDeBoleto = JsonConvert.DeserializeObject<IEnumerable<ItemBoleto>>(ConteudoDoIndiceDeBoletos);

            var ItemDeCpfEncontrado = ListaDeItensDeBoleto.FirstOrDefault(x => x.cpf == cpf);

            if (ItemDeCpfEncontrado == null) return new Boleto();

            return new Boleto(ItemDeCpfEncontrado.listaDeBoletos.FirstOrDefault());
        }
    }
}