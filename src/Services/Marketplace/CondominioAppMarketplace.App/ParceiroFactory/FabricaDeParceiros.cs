using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.ParceiroFactory
{
    public abstract class FabricaDeParceiros
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract Parceiro CriarParceiro(ParceiroViewModel ViewModel);

        protected void AdicionarErrosDeConstrucao(string MensagemDeErro)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, MensagemDeErro));
        }
    }
}
