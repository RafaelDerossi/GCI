using AutoMapper;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.ReservaAreaComum.Aplication.AutoMapper
{  
    public class EntityToViewModelAreaComum : Profile
    {
        public EntityToViewModelAreaComum()
        {
            CreateMap<Periodo, PeriodoViewModel>();
        }
    }
}
