using AutoMapper;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.FlatModel;

namespace CondominioApp.Principal.Aplication.AutoMapper
{
    public class EntityFlatToViewModelUnidade : Profile
    {
        public EntityFlatToViewModelUnidade()
        {
            CreateMap<UnidadeFlat, UnidadeFlatViewModel>();
            CreateMap<MoradorFlat, MoradorFlatViewModel>();
            CreateMap<VeiculoFlat, VeiculoFlatViewModel>();
        }
    }
}
