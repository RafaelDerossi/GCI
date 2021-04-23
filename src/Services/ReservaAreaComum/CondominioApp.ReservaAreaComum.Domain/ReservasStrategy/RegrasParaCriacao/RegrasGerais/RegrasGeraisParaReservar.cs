using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasGerais
{
    public class RegrasGeraisParaReservar : IRegrasGeraisParaReservar
    {
        private readonly IRegraIntervalosFixos _regraIntervalosFixos;
        private readonly IRegraDuracaoLimite _regraDuracaoLimite;
        private readonly IRegraHorarioDisponivelSemSobreposicao _regraSemSobreposicao;
        private readonly IRegraHorarioDisponivelComSobreposicao _regraComSobreposicao;

        public RegrasGeraisParaReservar
            (IRegraIntervalosFixos regraIntervalosFixos,
             IRegraDuracaoLimite regraDuracaoLimite,
             IRegraHorarioDisponivelSemSobreposicao regraSemSobreposicao,
             IRegraHorarioDisponivelComSobreposicao regraComSobreposicao)
        {
            _regraIntervalosFixos = regraIntervalosFixos;
            _regraDuracaoLimite = regraDuracaoLimite;
            _regraSemSobreposicao = regraSemSobreposicao;
            _regraComSobreposicao = regraComSobreposicao;
        }

        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            var result = _regraIntervalosFixos.Validar(_reserva, _areaComum);
            if (!result.IsValid)
                return result;

            result = _regraDuracaoLimite.Validar(_reserva, _areaComum);
            if (!result.IsValid)
                return result;


            if (_areaComum.PermiteReservaSobreposta && _areaComum.TemHorariosEspecificos)
                return _regraComSobreposicao.Validar(_reserva, _areaComum);
           

            return _regraSemSobreposicao.Validar(_reserva, _areaComum);
            
        }

        public ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum)
        {
            return _regraSemSobreposicao.Validar(_reserva, _areaComum);
        }

    }
}
