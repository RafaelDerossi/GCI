using AutoMapper;
using CondominioApp.ArquivoDigital.App.Models;
using System.Linq;

namespace CondominioApp.ArquivoDigital.App.AutoMapper
{
    public class EntityToViewModelArquivoDigital : Profile
    {
        public EntityToViewModelArquivoDigital()
        {
            CreateMap<Pasta, PastaViewModel>();

            CreateMap<Arquivo, ArquivoViewModel>();
            
        }
    }
}
