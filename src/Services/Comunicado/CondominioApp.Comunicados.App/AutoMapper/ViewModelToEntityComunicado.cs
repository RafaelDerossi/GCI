using AutoMapper;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Comunicados.App.ViewModels;

namespace CondominioApp.Correspondencias.App.AutoMapper
{  
    public class ViewModelToEntityComunicado : Profile
    {
        public ViewModelToEntityComunicado()
        {
            CreateMap<UnidadeComunicadoViewModel, UnidadeComunicado>()
                .ForMember(m => m.UnidadeId, cfg => cfg.MapFrom(x => x.UnidadeId))
                .ForMember(c => c.Numero, p  => p.MapFrom(x => x.Numero))
                .ForMember(c => c.Andar, p => p.MapFrom(x => x.Andar))
                .ForMember(c => c.GrupoId, p => p.MapFrom(x => x.GrupoId))
                .ForMember(c => c.DescricaoGrupo, p => p.MapFrom(x => x.DescricaoGrupo));           
        }
    }
}
