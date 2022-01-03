using GCI.Acoes.Domain.FlatModel;
using System.Threading.Tasks;
using Rebus.Handlers;
using GCI.Core.Messages.CommonHandlers;
using GCI.Core.Data;

namespace GCI.Acoes.Aplication.Events
{
    public class AcaoEventHandler : EventHandler,
         IHandleMessages<AcaoAdicionadaEvent>,
         IHandleMessages<OperacaoAdicionadaEvent>,
         System.IDisposable
    {        
        private readonly IMongoRepository<AcaoFlat> _acaoFlatRepository;
        private readonly IMongoRepository<OperacaoFlat> _operacaoFlatRepository;
        
        public AcaoEventHandler(IMongoRepository<AcaoFlat> acaoFlatRepository, IMongoRepository<OperacaoFlat> operacaoFlatRepository)
        {
            _acaoFlatRepository = acaoFlatRepository;
            _operacaoFlatRepository = operacaoFlatRepository;
        }

        public async Task Handle(AcaoAdicionadaEvent message)
        {
            var acaoFlat = new AcaoFlat
                (message.AcaoId, message.DataDeCadastro, message.Codigo, message.RazaoSocial);

            await _acaoFlatRepository.AdicionarAsync(acaoFlat);            
        }

        public async Task Handle(OperacaoAdicionadaEvent message)
        {
            var operacaoFlat = new OperacaoFlat
                (message.OperacaoId, message.DataDeCadastro, message.CodigoDaAcao,
                 message.Preco, message.Quantidade, message.DataDaOperacao,
                 message.CustoDaOperacao, message.ValorTotal, message.Tipo);

            await _operacaoFlatRepository.AdicionarAsync(operacaoFlat);
        }

        public void Dispose()
        {            
        }

    }
}
