using System.Threading.Tasks;
using CondominioApp.Core.DomainObjects;

namespace CondominioAppMarketplace.Infra.EmailServices
{
    public interface IServicoDeEmail
    {
        string SubstituirValores(IAggregateRoot Aggregate);

        void ConstruirEmail(string Assunto, string ConteudoDoEmail);

        Task EnviarEmail();
    }
}
