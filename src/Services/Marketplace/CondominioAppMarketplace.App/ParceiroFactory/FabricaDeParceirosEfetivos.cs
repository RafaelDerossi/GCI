using CondominioApp.Core.DomainObjects;
using CondominioAppMarketplace.Domain.ValueObjects;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.ParceiroFactory
{
    public class FabricaDeParceirosEfetivos : FabricaDeParceiros
    {
        public override Parceiro CriarParceiro(ParceiroViewModel ViewModel)
        {
            try
            {
                var parceiro = new Parceiro(ViewModel.NomeCompleto, ViewModel.Descricao, new Cnpj(ViewModel.NumeroDoCnpj),
                    new Endereco(ViewModel.Logradouro, ViewModel.Complemento, ViewModel.Numero, ViewModel.Cep, ViewModel.Bairro, ViewModel.Cidade, ViewModel.Estado),
                    ViewModel.NomeDoResponsavel, new Email(ViewModel.EmailDoResponsavel),
                    new Telefone(ViewModel.TelefoneCelular),
                    new Telefone(ViewModel.TelefoneFixo), false,
                    new Contrato(ViewModel.ContratoDataDeInicio,ViewModel.ContratoDataDeRenovacao,ViewModel.Descricao),
                    ViewModel.LogoMarca,
                    ViewModel.Cor);

                ValidationResult = parceiro.Validar();

                return parceiro;
            }
            catch (DomainException e)
            {
                AdicionarErrosDeConstrucao(e.Message);
                return null;
            }
        }
    }
}