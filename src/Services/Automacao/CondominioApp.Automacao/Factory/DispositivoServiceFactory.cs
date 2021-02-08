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
        private readonly ICondominioCredencialQuery _condominioCredencialQuery;

        public DispositivoServiceFactory(ICondominioCredencialQuery condominioCredencialQuery)
        {
            _condominioCredencialQuery = condominioCredencialQuery;            
        }
        
        public async Task<IDispositivosService> Fabricar(TipoApiAutomacao tipoApiAutomacao, Guid condominioId)
        {
            var credencial = await _condominioCredencialQuery.ObterPorCondominioETipoApi(condominioId, tipoApiAutomacao);
            if (tipoApiAutomacao == TipoApiAutomacao.EWELINK)
                return new DispositivosEwelinkService(credencial);

            return new DispositivosEwelinkService();
        }
    }
}
