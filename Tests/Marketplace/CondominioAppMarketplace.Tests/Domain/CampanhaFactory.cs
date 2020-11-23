using System;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.Tests.Domain
{
    public static class CampanhaFactory
    {
        public static Campanha CriarCampanhaValida()
        {
            return new Campanha("Nova Campanha","Descrição da Campanha","BannerDaCampanha.jpg",
                new DateTime(2020,01,01),new DateTime(2020,12,31));
        }

        public static Campanha CriarCampanhaInValida()
        {
            return new Campanha("Nova Campanha", "Descrição da Campanha", "BannerDaCampanha.jpg",
                new DateTime(2020, 03, 01), new DateTime(2020, 02, 20));
        }
    }
}