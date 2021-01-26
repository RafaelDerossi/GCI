using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Portaria.ValueObjects
{
    public class Veiculo
    {
        public const int ModeloMaxlength = 200;
        public const int CorMaxlength = 30;
        public const int PlacaMaxlength = 7;

        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Cor { get; private set; }


        protected Veiculo() { }

        public Veiculo(string placa, string modelo, string cor)
        {
            SetPlaca(placa);
            SetModelo(modelo);
            SetCor(cor);
        }

        public void SetPlaca(string placa)
        {
            if (!string.IsNullOrEmpty(placa))
            {
                Guarda.ValidarTamanhoMaximo(placa, PlacaMaxlength);
                Regex regex = new Regex(@"^([A-Z]{3}[0-9][0-9A-Z][0-9]{2})*$");
                Match match = regex.Match(placa);
                if (!match.Success)                
                    throw new DomainException("Placa inválida!");
            }

            Placa = placa;
        }
               

        public void SetModelo(string modelo)
        {
            if (!string.IsNullOrEmpty(modelo))
            {
                Guarda.ValidarTamanhoMaximo(modelo, ModeloMaxlength);

                if (modelo.Length < 3)
                    throw new DomainException("Informe um modelo de veículo com no mínimo 3 caracteres.");
            }           

            Modelo = modelo;               
        }

        public void SetCor(string cor)
        {
            if (!string.IsNullOrEmpty(cor))
            {
                Guarda.ValidarTamanhoMaximo(cor, CorMaxlength);

                if (cor.Length < 3)
                    throw new DomainException("Informe uma cor com no mínimo 3 caracteres.");
            }

            Cor = cor;
        }
    }
}