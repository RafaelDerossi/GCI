using AutoMapper;
using CondominioApp.Principal.Domain;

namespace CondominioApp.Principal.Aplication.AutoMapper
{
    public class EntityToViewModelContrato : Profile
    {
        public EntityToViewModelContrato()
        {
            CreateMap<Contrato, ContratoViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(c => c.CondominioId, p => p.MapFrom(x => x.CondominioId))
                .ForMember(c => c.DataAssinatura, p => p.MapFrom(x => x.DataAssinatura))
                .ForMember(c => c.Descricao, cfg => cfg.MapFrom(x => x.Descricao))
                .ForMember(c => c.Tipo, p => p.MapFrom(x => x.Tipo))
                .ForMember(c => c.Ativo, p => p.MapFrom(x => x.Ativo))
                .ForMember(c => c.Arquivo, p => p.MapFrom(x => x.ArquivoContrato));            
        }
    }
}
