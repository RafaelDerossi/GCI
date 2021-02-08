using CondominioApp.Automacao.App.Services.Interfaces;
using CondominioApp.Core.Enumeradores;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Factory
{
    public interface IDispositivosServiceFactory
    {
        Task<IDispositivosService> Fabricar(TipoApiAutomacao tipoApiAutomacao, Guid condominioId);
    }
}