using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumEventHandler : EventHandler,
         INotificationHandler<AreaComumCadastradaEvent>,
         System.IDisposable
    {

        private IReservaAreaComumQueryRepository _reservaAreaComumQueryRepository;


        public AreaComumEventHandler(IReservaAreaComumQueryRepository reservaAreaComumQueryRepository)
        {
            _reservaAreaComumQueryRepository = reservaAreaComumQueryRepository;
        }


        public async Task Handle(AreaComumCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var areaComumFlat = new AreaComumFlat
                (notification.Id,
                notification.Nome, notification.Descricao, notification.TermoDeUso,
                notification.CondominioId, notification.NomeCondominio, notification.Capacidade,
                notification.DiasPermitidos, notification.AntecedenciaMaximaEmMeses,
                notification.AntecedenciaMaximaEmDias, notification.AntecedenciaMinimaEmDias,
                notification.AntecedenciaMinimaParaCancelamentoEmDias, notification.RequerAprovacaoDeReserva,
                notification.TemHorariosEspecificos, notification.TempoDeIntervaloEntreReservas,
                notification.Ativa, notification.TempoDeDuracaoDeReserva,
                notification.NumeroLimiteDeReservaPorUnidade, notification.PermiteReservaSobreposta,
                notification.NumeroLimiteDeReservaSobreposta, notification.NumeroLimiteDeReservaSobrepostaPorUnidade,
                notification.TemIntervaloFixoEntreReservas);
            

            _reservaAreaComumQueryRepository.Adicionar(areaComumFlat);

            foreach (Periodo periodo in notification.Periodos)
            {
                var periodoFlat = new PeriodoFlat
                    (periodo.Id,areaComumFlat.Id, periodo.HoraInicio, periodo.HoraFim, periodo.Valor, periodo.Ativo);

                _reservaAreaComumQueryRepository.AdicionarPeriodo(periodoFlat);
            }

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }




        public void Dispose()
        {
            _reservaAreaComumQueryRepository?.Dispose();
        }

    }
}
