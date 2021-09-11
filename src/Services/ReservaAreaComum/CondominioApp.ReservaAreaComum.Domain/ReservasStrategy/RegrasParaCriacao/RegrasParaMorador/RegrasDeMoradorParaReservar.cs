using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador
{
    public class RegrasDeMoradorParaReservar : IRegrasDeMoradorParaReservar
    {
        private readonly IRegraIntervaloParaMesmaUnidade _regraIntervaloParaMesmaUnidade;
        private readonly IRegraDataRetroativaNaoPermitida _regraDataRetroativaNaoPermitida;
        private readonly IRegraBloqueioDaAreaComum _regraBloqueioDaAreaComum;
        private readonly IRegraAntecedenciaMaxima _regraAntecedenciaMaxima;
        private readonly IRegraAntecedenciaMinima _regraAntecedenciaMinima;
        private readonly IRegraDiasPermitidos _regraDiasPermitidos;
        private readonly IRegraLimitePorUnidadePorDia _regraLimitePorUnidadePorDia;
        private readonly IRegraHorarioDentroDosLimites _regraHorarioDentroDosLimites;

        public RegrasDeMoradorParaReservar
            (IRegraIntervaloParaMesmaUnidade regraIntervaloParaMesmaUnidade,
             IRegraDataRetroativaNaoPermitida regraDataRetroativaNaoPermitida,
             IRegraBloqueioDaAreaComum regraBloqueioDaAreaComum,
             IRegraAntecedenciaMaxima regraAntecedenciaMaxima,
             IRegraAntecedenciaMinima regraAntecedenciaMinima,
             IRegraDiasPermitidos regraDiasPermitidos,
             IRegraLimitePorUnidadePorDia regraLimitePorUnidadePorDia,
             IRegraHorarioDentroDosLimites regraHorarioDentroDosLimites)
        {
            _regraIntervaloParaMesmaUnidade = regraIntervaloParaMesmaUnidade;
            _regraDataRetroativaNaoPermitida = regraDataRetroativaNaoPermitida;
            _regraBloqueioDaAreaComum = regraBloqueioDaAreaComum;
            _regraAntecedenciaMaxima = regraAntecedenciaMaxima;
            _regraAntecedenciaMinima = regraAntecedenciaMinima;
            _regraDiasPermitidos = regraDiasPermitidos;
            _regraLimitePorUnidadePorDia = regraLimitePorUnidadePorDia;
            _regraHorarioDentroDosLimites = regraHorarioDentroDosLimites;
        }


        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            //Regra de Intervalo Entre Reservas para a mesma unidade
            var retorno = _regraIntervaloParaMesmaUnidade.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;

            //Regra para não permitir Reserva Retroativa
            retorno = _regraDataRetroativaNaoPermitida.Validar(_reserva);
            if (!retorno.IsValid)
                return retorno;

            //Regra de bloqueio
            retorno = _regraBloqueioDaAreaComum.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;

            //Regra para antecedencia máxima
            retorno = _regraAntecedenciaMaxima.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;

            //Regra para antecedencia Minima
            retorno = _regraAntecedenciaMinima.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;


            //Regra de Dias Possíveis de reservas
            retorno = _regraDiasPermitidos.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;

            //Regra limite de reservas por Unidade
            retorno = _regraLimitePorUnidadePorDia.Validar(_reserva, _areaComum);
            if (!retorno.IsValid)
                return retorno;
           

            //Regra verifica se o horário da reserva esta dentro dos limites permitidos
            if (!_areaComum.TemHorariosEspecificos)
            {
                retorno = _regraHorarioDentroDosLimites.Validar(_reserva, _areaComum);
                if (!retorno.IsValid)
                    return retorno;
            }

            return retorno;
        }
        
    }
}
