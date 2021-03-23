using AutoMapper;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ViewModels;

namespace CondominioApp.Ocorrencias.App.AutoMapper
{  
    public class EntityToViewModelOcorrencia : Profile
    {
        public EntityToViewModelOcorrencia()
        {
            CreateMap<Ocorrencia, OcorrenciaViewModel>()
                  .ForMember(c => c.Foto, p => p.MapFrom(x => x.Foto.NomeDoArquivo));
        }
    }
}
