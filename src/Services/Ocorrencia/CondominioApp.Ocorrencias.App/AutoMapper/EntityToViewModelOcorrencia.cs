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
                  .ForMember(c => c.FotoUrl, p => p.MapFrom(x => x.Foto.NomeDoArquivo));

            CreateMap<RespostaOcorrencia, RespostaOcorrenciaViewModel>()
                  .ForMember(c => c.FotoUrl, p => p.MapFrom(x => x.Foto.NomeDoArquivo))
                  .ForMember(c => c.TipoAutor, p => p.MapFrom(x => x.TipoAutor.ToString()));
        }
    }
}
