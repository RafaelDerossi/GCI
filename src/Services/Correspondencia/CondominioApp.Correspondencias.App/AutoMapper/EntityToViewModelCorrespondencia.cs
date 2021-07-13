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
                .ForMember(c => c.Observacao, p => p.MapFrom(x => x.Observacao))                
                .ForMember(c => c.FuncionarioId, p => p.MapFrom(x => x.FuncionarioId))
                .ForMember(c => c.NomeFuncionario, p => p.MapFrom(x => x.NomeFuncionario))
                .ForMember(c => c.NomeArquivoFoto, p => p.MapFrom(x => x.FotoCorrespondencia.NomeDoArquivo))
                .ForMember(c => c.NomeOriginalFoto, p => p.MapFrom(x => x.FotoCorrespondencia.NomeOriginal))
                .ForMember(c => c.NumeroRastreamentoCorreio, p => p.MapFrom(x => x.NumeroRastreamentoCorreio))
                .ForMember(c => c.DataDeChegada, p => p.MapFrom(x => x.DataDeChegada))
                .ForMember(c => c.QuantidadeDeAlertasFeitos, p => p.MapFrom(x => x.QuantidadeDeAlertasFeitos))
                .ForMember(c => c.TipoDeCorrespondencia, p => p.MapFrom(x => x.TipoDeCorrespondencia))                
                .ForMember(c => c.Status, p => p.MapFrom(x => x.Status.ToString()))
                .ForMember(c => c.NomeRetirante, p => p.MapFrom(x => x.NomeRetirante))
                .ForMember(c => c.DataDaRetirada, p => p.MapFrom(x => x.DataDaRetirada))
                .ForMember(c => c.NomeArquivoFotoRetirante, p => p.MapFrom(x => x.FotoRetirante.NomeDoArquivo))
                .ForMember(c => c.NomeOriginalFotoRetirante, p => p.MapFrom(x => x.FotoRetirante.NomeOriginal))
                .ForMember(c => c.Localizacao, p => p.MapFrom(x => x.Localizacao))
                .ForMember(c => c.EnviarNotificacao, p => p.MapFrom(x => x.EnviarNotificacao))
                .ForMember(c => c.UrlArquivoFoto, p => p.MapFrom(x => x.FotoCorrespondenciaUrl))
                .ForMember(c => c.UrlFotoRetirante, p => p.MapFrom(x => x.FotoRetiranteUrl))
                .ForMember(c => c.ObservacaoDaRetirada, p => p.MapFrom(x => x.ObservacaoDaRetirada))
                .ForMember(c => c.Lixeira, p => p.MapFrom(x => x.Lixeira));


            CreateMap<HistoricoCorrespondencia, HistoricoCorrespondenciaViewModel>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
               .ForMember(c => c.DataDeCadastro, p => p.MapFrom(x => x.DataDeCadastroFormatada))
               .ForMember(c => c.DataDeAlteracao, p => p.MapFrom(x => x.DataDeAlteracaoFormatada))
               .ForMember(c => c.CorrespondenciaId, cfg => cfg.MapFrom(x => x.CorrespondenciaId))
               .ForMember(c => c.Acao, p => p.MapFrom(x => x.Acao))
               .ForMember(c => c.FuncionarioId, p => p.MapFrom(x => x.FuncionarioId))
               .ForMember(c => c.NomeFuncionario, p => p.MapFrom(x => x.NomeFuncionario))
               .ForMember(c => c.Visto, p => p.MapFrom(x => x.Visto));               
        }
    }
}
