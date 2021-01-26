using AutoMapper;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using System.Linq;

namespace CondominioApp.Enquetes.App.AutoMapper
{
    public class EntityToViewModelEnquete : Profile
    {
        public EntityToViewModelEnquete()
        {
            CreateMap<Enquete, EnqueteViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(c => c.DataDeCadastro, p => p.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(c => c.DataDeAlteracao, p => p.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(c => c.Descricao, cfg => cfg.MapFrom(x => x.Descricao))
                .ForMember(c => c.DataInicio, p => p.MapFrom(x => x.DataInicio))
                .ForMember(c => c.DataFim, p => p.MapFrom(x => x.DataFim))
                .ForMember(c => c.CondominioId, p => p.MapFrom(x => x.CondominioId))
                .ForMember(c => c.CondominioNome, p => p.MapFrom(x => x.CondominioNome))
                .ForMember(c => c.ApenasProprietarios, p => p.MapFrom(x => x.ApenasProprietarios))
                .ForMember(c => c.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
                .ForMember(c => c.UsuarioNome, p => p.MapFrom(x => x.UsuarioNome))
                .ForMember(c => c.Alternativas, p => p.MapFrom(x => x.Alternativas.Where(a=>!a.Lixeira)))
                .ForMember(c => c.QuantidadeDeVotos, p => p.MapFrom(x => x.ObterQuantidadeDeVotos))
                .ForMember(c => c.EnqueteAtiva, p => p.MapFrom(x => x.EnqueteAtiva));


            CreateMap<AlternativaEnquete, AlternativaEnqueteViewModel>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
               .ForMember(c => c.DataDeCadastro, p => p.MapFrom(x => x.DataDeCadastroFormatada))
               .ForMember(c => c.DataDeAlteracao, p => p.MapFrom(x => x.DataDeAlteracaoFormatada))
               .ForMember(c => c.Descricao, cfg => cfg.MapFrom(x => x.Descricao))               
               .ForMember(c => c.Respostas, p => p.MapFrom(x => x.Respostas));


            CreateMap<RespostaEnquete, RespostaEnqueteViewModel>()
              .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
              .ForMember(c => c.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeCadastroFormatada))
              .ForMember(c => c.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeAlteracaoFormatada))
              .ForMember(c => c.UnidadeId, p => p.MapFrom(x => x.UnidadeId))
              .ForMember(c => c.Unidade, p => p.MapFrom(x => x.Unidade))
              .ForMember(c => c.Bloco, p => p.MapFrom(x => x.Bloco))
              .ForMember(c => c.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
              .ForMember(c => c.UsuarioNome, p => p.MapFrom(x => x.UsuarioNome))
              .ForMember(c => c.TipoDeUsuario, p => p.MapFrom(x => x.TipoDeUsuario))
              .ForMember(c => c.AlternativaId, p => p.MapFrom(x => x.AlternativaEnqueteId));
        }
    }
}
