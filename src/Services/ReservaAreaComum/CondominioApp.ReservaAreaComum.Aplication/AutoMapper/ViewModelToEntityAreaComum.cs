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
                .ForMember(e => e.HoraInicio, cfg => cfg.MapFrom(x => x.HoraInicio))
                .ForMember(e => e.HoraFim, cfg => cfg.MapFrom(x => x.HoraFim))
                .ForMember(e => e.Valor, cfg => cfg.MapFrom(x => x.Valor))
                .ForMember(e => e.Ativo, cfg => cfg.MapFrom(x => x.Ativo));           
        }
    }
}
