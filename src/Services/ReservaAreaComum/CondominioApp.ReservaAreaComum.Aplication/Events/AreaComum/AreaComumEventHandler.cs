using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumEventHandler : EventHandler,
         INotificationHandler<AreaComumAdicionadaEvent>,
         INotificationHandler<AreaComumAtualizadaEvent>,
         INotificationHandler<AreaComumAtivadaEvent>,
         INotificationHandler<AreaComumDesativadaEvent>,
        INotificationHandler<AreaComumApagadaEvent>,
         System.IDisposable
    {

        private readonly IReservaAreaComumQueryRepository _reservaAreaComumQueryRepository;


        public AreaComumEventHandler(IReservaAreaComumQueryRepository reservaAreaComumQueryRepository)
        {
            _reservaAreaComumQueryRepository = reservaAreaComumQueryRepository;
        }


        public async Task Handle(AreaComumAdicionadaEvent notification, CancellationToken cancellationToken)
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
                notification.TemIntervaloFixoEntreReservas, notification.TempoDeIntervaloEntreReservasPorUnidade);
            

            _reservaAreaComumQueryRepository.Adicionar(areaComumFlat);

            foreach (Periodo periodo in notification.Periodos)
            {
                var periodoFlat = new PeriodoFlat
                    (periodo.Id,areaComumFlat.Id, periodo.HoraInicio, periodo.HoraFim, periodo.Valor, periodo.Ativo);

                _reservaAreaComumQueryRepository.AdicionarPeriodo(periodoFlat);
            }

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(AreaComumAtualizadaEvent notification, CancellationToken cancellationToken)
        {
            var areaComumFlat = await _reservaAreaComumQueryRepository.ObterPorId(notification.Id);
            if (areaComumFlat == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return;
            }

            areaComumFlat.SetNome(notification.Nome);
            areaComumFlat.SetDescricao(notification.Descricao);
            areaComumFlat.SetTermoDeUso(notification.TermoDeUso);
            areaComumFlat.SetCapacidade(notification.Capacidade);
            areaComumFlat.SetDiasPermitidos(notification.DiasPermitidos);
            areaComumFlat.SetAntecedenciaMaximaEmMeses(notification.AntecedenciaMaximaEmMeses);
            areaComumFlat.SetAntecedenciaMaximaEmDias(notification.AntecedenciaMaximaEmDias);
            areaComumFlat.SetAntecedenciaMinimaEmDias(notification.AntecedenciaMinimaEmDias);
            areaComumFlat.SetAntecedenciaMinimaParaCancelamentoEmDias(notification.AntecedenciaMinimaParaCancelamentoEmDias);
            areaComumFlat.SetTempoDeIntervaloEntreReservas(notification.TempoDeIntervaloEntreReservas);
            areaComumFlat.SetTempoDeDuracaoDeReserva(notification.TempoDeDuracaoDeReserva);
            areaComumFlat.SetNumeroLimiteDeReservaPorUnidade(notification.NumeroLimiteDeReservaPorUnidade);
            areaComumFlat.SetNumeroLimiteDeReservaSobreposta(notification.NumeroLimiteDeReservaSobreposta);
            areaComumFlat.SetNumeroLimiteDeReservaSobrepostaPorUnidade(notification.NumeroLimiteDeReservaSobrepostaPorUnidade);
            areaComumFlat.SetTempoDeIntervaloEntreReservasPorUnidade(notification.TempoDeIntervaloEntreReservasPorUnidade);

            areaComumFlat.DesabilitarAprovacaoDeReserva();
            if (notification.RequerAprovacaoDeReserva) areaComumFlat.HabilitarAprovacaoDeReserva();

            areaComumFlat.DesabilitarHorariosEspecifcos();
            if (notification.TemHorariosEspecificos) areaComumFlat.HabilitarHorariosEspecifcos();            

            areaComumFlat.DesabilitarReservaSobreposta();
            if (notification.PermiteReservaSobreposta) areaComumFlat.HabilitarReservaSobreposta();



            if (areaComumFlat.Periodos != null)
            {
                foreach (PeriodoFlat periodo in areaComumFlat.Periodos)
                {
                    _reservaAreaComumQueryRepository.RemoverPeriodo(periodo);
                }
            }
            areaComumFlat.RemoverTodosOsPeriodos();

            if (notification.Periodos != null && notification.Periodos.Count() > 0)
            {
                foreach (Periodo periodo in notification.Periodos)
                {
                    var periodoFlat = new PeriodoFlat
                        (periodo.Id, areaComumFlat.Id, periodo.HoraInicio, periodo.HoraFim, periodo.Valor,
                        periodo.Ativo);

                    _reservaAreaComumQueryRepository.AdicionarPeriodo(periodoFlat);
                }
            }          


            _reservaAreaComumQueryRepository.Atualizar(areaComumFlat);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(AreaComumAtivadaEvent notification, CancellationToken cancellationToken)
        {
            var areaComumFlat = await _reservaAreaComumQueryRepository.ObterPorId(notification.Id);
            if (areaComumFlat == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return;
            }

            areaComumFlat.AtivarAreaComun();

            _reservaAreaComumQueryRepository.Atualizar(areaComumFlat);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(AreaComumDesativadaEvent notification, CancellationToken cancellationToken)
        {
            var areaComumFlat = await _reservaAreaComumQueryRepository.ObterPorId(notification.Id);
            if (areaComumFlat == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return;
            }

            areaComumFlat.DesativarAreaComun();

            _reservaAreaComumQueryRepository.Atualizar(areaComumFlat);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(AreaComumApagadaEvent notification, CancellationToken cancellationToken)
        {
            var areaComumFlat = await _reservaAreaComumQueryRepository.ObterPorId(notification.Id);
            if (areaComumFlat == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return;
            }            

            _reservaAreaComumQueryRepository.Apagar(x=>x.Id == areaComumFlat.Id);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }


        public void Dispose()
        {
            _reservaAreaComumQueryRepository?.Dispose();
        }

    }
}
