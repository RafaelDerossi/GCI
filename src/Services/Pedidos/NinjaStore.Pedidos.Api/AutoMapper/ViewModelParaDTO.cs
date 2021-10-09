using AutoMapper;
using NinjaStore.Core.Messages.DTO;
using NinjaStore.Pedidos.Aplication.ViewModels;
using System.Linq;

namespace NinjaStore.Pedidos.Api
{
    public class ViewModelParaDTO : Profile
    {
        public ViewModelParaDTO()
        {
            CreateMap<ProdutoViewModel, ProdutoDTO>()                
                .ForMember(m => m.ProdutoId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.Descricao, cfg => cfg.MapFrom(x => x.Descricao))
                .ForMember(m => m.Foto, cfg => cfg.MapFrom(x => x.Foto))                
                .ForMember(m => m.Valor, cfg => cfg.MapFrom(x => x.Valor))
                .ForMember(m => m.Desconto, cfg => cfg.MapFrom(x => x.Desconto))
                .ForMember(m => m.ValorTotal, cfg => cfg.MapFrom(x => x.ValorTotal));
            
        }
    }
}
