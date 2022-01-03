using GCI.Acoes.Domain.FlatModel;
using System.Threading.Tasks;
using Rebus.Handlers;
using GCI.Core.Messages.CommonHandlers;
using GCI.Core.Data;

namespace GCI.Acoes.Aplication.Events
{
    public class AcaoEventHandler : EventHandler,
         IHandleMessages<AcaoAdicionadaEvent>,
         System.IDisposable
    {        
        private readonly IMongoRepository<AcaoFlat> _acaoFlatRepository;

        public AcaoEventHandler(IMongoRepository<AcaoFlat> acaoFlatRepository)
        {
            _acaoFlatRepository = acaoFlatRepository;
        }

        public async Task Handle(AcaoAdicionadaEvent message)
        {
            var acaoFlat = new AcaoFlat
                (message.AcaoId, message.DataDeCadastro, message.Codigo, message.RazaoSocial);

            await _acaoFlatRepository.AdicionarAsync(acaoFlat);            
        }
               

        public void Dispose()
        {            
        }

    }
}
