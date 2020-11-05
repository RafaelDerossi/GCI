using System;

namespace CondominioApp.Core.Helpers
{
    public static class DataHoraDeBrasilia
    {
        public static DateTime Get()
        {
           return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ZonaDeTempo.ObterZonaDeTempo());
        }
        
        public static DateTime Set(DateTime data)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(data.ToUniversalTime(), ZonaDeTempo.ObterZonaDeTempo());
        }
    }
}