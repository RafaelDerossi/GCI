﻿using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.App.Aplication.Query
{
    public interface IReservaAreaComumQuery : IDisposable
    {
        Task<AreaComumFlat> ObterPorId(Guid id);
      
        Task<IEnumerable<AreaComumFlat>> ObterPorCondominio(Guid condominioId);

        Task<IEnumerable<AreaComumFlat>> ObterPorCondominioEAtiva(Guid condominioId, bool ativa);


        Task<ReservaFlat> ObterReservaPorId(Guid id);
      
        Task<IEnumerable<ReservaFlat>> ObterReservasPorCondominio(Guid condominioId);

        Task<IEnumerable<ReservaFlat>> ObterReservasPorUnidade(Guid unidadeId);

        Task<IEnumerable<ReservaFlat>> ObterReservasPorMorador(Guid usuarioId);

        Task<IEnumerable<ReservaFlat>> ObterReservasPorAreaComum(Guid areaComumId);

        Task<int> ObterQtdDeReservasProcessando();

        Task<ReservaFlat> ObterPrimeiraNaFilaParaSerProcessada();

        Task<IEnumerable<HistoricoReservaFlat>> ObterHistoricoDaReserva(Guid reservaId);


        Task<IEnumerable<FotoDaAreaComum>> ObterFotosDaAreaComum(Guid areaComumId);
    }
}