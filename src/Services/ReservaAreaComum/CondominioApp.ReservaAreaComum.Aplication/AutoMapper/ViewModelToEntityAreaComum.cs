using AutoMapper;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.ReservaAreaComum.Aplication.AutoMapper
{  
    public class ViewModelToEntityAreaComum : Profile
    {
        public ViewModelToEntityAreaComum()
        {
            CreateMap<PeriodoViewModel, Periodo>()
                .ForMember(m => m.HoraInicio, cfg => cfg.MapFrom(x => x.HoraInicio))
                .ForMember(c => c.HoraFim, p  => p.MapFrom(x => x.HoraFim))
                .ForMember(c => c.Valor, p => p.MapFrom(x => x.Valor))
                .ForMember(c => c.Ativo, p => p.MapFrom(x => x.Ativo));           
        }
    }
}
