using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador
{
    public class RegrasDeMoradorParaReservar : IRegrasDeMoradorParaReservar
    {
        private IRegraIntervaloParaMesmaUnidade _regraIntervaloParaMesmaUnidade;
        private IRegraDataRetroativaNaoPermitida _regraDataRetroativaNaoPermitida;
        private IRegraBloqueioDaAreaComum _regraBloqueioDaAreaComum;
        private IRegraAntecedenciaMaxima _regraAntecedenciaMaxima;
        private IRegraAntecedenciaMinima _regraAntecedenciaMinima;
        private IRegraDiasPermitidos _regraDiasPermitidos;
        private IRegraLimitePorUnidadePorDia _regraLimitePorUnidadePorDia;
        private IRegraHorarioDentroDosLimites _regraHorarioDentroDosLimites;

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
