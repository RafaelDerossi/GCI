using AutoMapper;
using CondominioApp.ArquivoDigital.App.Models;
using System.Linq;

namespace CondominioApp.ArquivoDigital.App.AutoMapper
{
    public class EntityToViewModelArquivoDigital : Profile
    {
        public EntityToViewModelArquivoDigital()
        {
            CreateMap<Pasta, ConteudoPastaViewModel>();            

            CreateMap<Pasta, SubPastaViewModel>(); 

            CreateMap<Arquivo, ArquivoViewModel>()
                .ForMember(m => m.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(m => m.DataDeAlteracao, cfg => cfg.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(m => m.NomeOriginal, cfg => cfg.MapFrom(x => x.Nome.NomeOriginal))
                .ForMember(m => m.NomeArquivo, cfg => cfg.MapFrom(x => x.Nome.NomeDoArquivo))
                .ForMember(m => m.Extensao, cfg => cfg.MapFrom(x => x.Nome.ExtensaoDoArquivo))
                .ForMember(m => m.Publico, cfg => cfg.MapFrom(x => x.Publico))
                .ForMember(m => m.Url, cfg => cfg.MapFrom(x => x.Url.Endereco));
            
        }
    }
}
