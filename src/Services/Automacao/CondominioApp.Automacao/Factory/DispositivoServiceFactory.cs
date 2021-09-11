using CondominioApp.Automacao.App.Aplication.Query;
using CondominioApp.Automacao.App.Services.Interfaces;
using CondominioApp.Automacao.Services;
using CondominioApp.Core.Enumeradores;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Factory
{
   public class DispositivoServiceFactory : IDispositivosServiceFactory
    {
        private readonly IAutomacaoQuery _automacaoQuery;

        public DispositivoServiceFactory(IAutomacaoQuery condominioCredencialQuery)
        {
            _automacaoQuery = condominioCredencialQuery;            
        }
        
        public async Task<IDispositivosService> Fabricar(TipoApiAutomacao tipoApiAutomacao, Guid condominioId)
        {
            if (tipoApiAutomacao == TipoApiAutomacao.EWELINK)
            {
                var credencial = await _automacaoQuery.ObterPorCondominioETipoApi(condominioId, tipoApiAutomacao);
                return new DispositivosEwelinkService(credencial);               
            }                       

            return new DispositivosWebhookService(condominioId, _automacaoQuery);       
        }
    }
}
