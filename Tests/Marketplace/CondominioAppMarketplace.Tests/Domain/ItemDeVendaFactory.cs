using System;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.Tests.Domain
{
    public class ItemDeVendaFactory
    {
        public static ItemDeVenda CriarItemDeVendaValido()
        {
            return new ItemDeVenda(10,10,new DateTime(2020,05,01),
                new DateTime(2020,08,30),Guid.NewGuid(),Guid.NewGuid(), 
                Guid.NewGuid());
        }

        public static ItemDeVenda CriarItemDeVendaInValido()
        {
            return new ItemDeVenda(10, 10, new DateTime(2020, 08, 30),
                new DateTime(2020, 05, 01), Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid());
        }
    }
}