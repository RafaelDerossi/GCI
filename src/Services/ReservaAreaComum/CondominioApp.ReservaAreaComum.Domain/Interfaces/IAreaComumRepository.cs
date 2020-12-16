using CondominioApp.Core.Data;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface IAreaComumRepository : IRepository<AreaComum>
    {
        void AdicionarPeriodo(Periodo entity);

        void RemoverPeriodo(Periodo entity);

        void AdicionarReserva(Reserva entity);
    }
}
