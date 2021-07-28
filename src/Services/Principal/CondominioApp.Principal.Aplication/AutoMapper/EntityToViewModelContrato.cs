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
                .ForMember(c => c.DataDeAssinatura, p => p.MapFrom(x => x.DataAssinatura))
                .ForMember(c => c.Descricao, cfg => cfg.MapFrom(x => x.Descricao))
                .ForMember(c => c.Plano, p => p.MapFrom(x => x.Tipo))
                .ForMember(c => c.Ativo, p => p.MapFrom(x => x.Ativo))
                .ForMember(c => c.QuantidadeDeUnidadesContratadas, p => p.MapFrom(x => x.QuantidadeDeUnidadesContratada))
                .ForMember(c => c.NomeArquivoContrato, p => p.MapFrom(x => x.ArquivoContrato.NomeDoArquivo))
                .ForMember(c => c.NomeOriginalArquivoContrato, p => p.MapFrom(x => x.ArquivoContrato.NomeOriginal))
                .ForMember(c => c.ExtencaoArquivoContrato, p => p.MapFrom(x => x.ArquivoContrato.ExtensaoDoArquivo));            
        }
    }
}
