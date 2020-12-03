using AutoMapper;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ViewModels;


namespace CondominioApp.Correspondencias.App.AutoMapper
{  
    public class EntityToViewModelCorrespondencia : Profile
    {
        public EntityToViewModelCorrespondencia()
        {
            CreateMap<Correspondencia, CorrespondenciaViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(c => c.DataDeCadastro, p => p.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(c => c.DataDeAlteracao, p => p.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(c => c.CondominioId, cfg => cfg.MapFrom(x => x.CondominioId))
                .ForMember(c => c.UnidadeId, p => p.MapFrom(x => x.UnidadeId))
                .ForMember(c => c.NumeroUnidade, p => p.MapFrom(x => x.NumeroUnidade))
                .ForMember(c => c.Bloco, p => p.MapFrom(x => x.Bloco))
                .ForMember(c => c.Visto, p => p.MapFrom(x => x.Visto))
                .ForMember(c => c.NomeRetirante, p => p.MapFrom(x => x.NomeRetirante))
                .ForMember(c => c.Observacao, p => p.MapFrom(x => x.Observacao))
                .ForMember(c => c.DataDaRetirada, p => p.MapFrom(x => x.DataDaRetirada))
                .ForMember(c => c.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
                .ForMember(c => c.NomeUsuario, p => p.MapFrom(x => x.NomeUsuario))
                .ForMember(c => c.Foto, p => p.MapFrom(x => x.Foto.NomeDoArquivo))
                .ForMember(c => c.NumeroRastreamentoCorreio, p => p.MapFrom(x => x.NumeroRastreamentoCorreio))
                .ForMember(c => c.DataDeChegada, p => p.MapFrom(x => x.DataDeChegada))
                .ForMember(c => c.QuantidadeDeAlertasFeitos, p => p.MapFrom(x => x.QuantidadeDeAlertasFeitos))
                .ForMember(c => c.NomeUsuario, p => p.MapFrom(x => x.TipoDeCorrespondencia))                
                .ForMember(c => c.NomeUsuario, p => p.MapFrom(x => x.Status.ToString()));           
        }
    }
}
