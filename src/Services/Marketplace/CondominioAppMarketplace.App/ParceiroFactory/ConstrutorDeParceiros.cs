using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.ParceiroFactory
{
    public class ConstrutorDeParceiros
    {
        public FabricaDeParceiros Fabrica { get; }

        public ConstrutorDeParceiros(FabricaDeParceiros fabrica)
        {
            Fabrica = fabrica;
        }

        public Parceiro Construir(ParceiroViewModel ViewModel)
        {
            return Fabrica.CriarParceiro(ViewModel);
        }
    }
}