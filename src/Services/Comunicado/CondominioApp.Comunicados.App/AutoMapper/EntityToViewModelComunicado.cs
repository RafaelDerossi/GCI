using AutoMapper;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Comunicados.App.ViewModels;

namespace CondominioApp.Correspondencias.App.AutoMapper
{  
    public class EntityToViewModelComunicado : Profile
    {
        public EntityToViewModelComunicado()
        {
            CreateMap<Comunicado, ComunicadoViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(m => m.DataDeAlteracao, cfg => cfg.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(c => c.Titulo, p  => p.MapFrom(x => x.Titulo))
                .ForMember(c => c.Descricao, p => p.MapFrom(x => x.Descricao))
                .ForMember(c => c.DataDeRealizacao, p => p.MapFrom(x => x.DataDeRealizacao))
                .ForMember(c => c.CondominioId, p => p.MapFrom(x => x.CondominioId))
                .ForMember(c => c.NomeCondominio, p => p.MapFrom(x => x.NomeCondominio))
                .ForMember(c => c.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
                .ForMember(c => c.NomeUsuario, p => p.MapFrom(x => x.NomeUsuario))
                .ForMember(c => c.Visibilidade, p => p.MapFrom(x => x.Visibilidade))
                .ForMember(c => c.Categoria, p => p.MapFrom(x => x.Categoria))
                .ForMember(c => c.CriadoPelaAdministradora, p => p.MapFrom(x => x.CriadoPelaAdministradora));


            CreateMap<Unidade, UnidadeViewModel>()
                .ForMember(m => m.UnidadeId, cfg => cfg.MapFrom(x => x.UnidadeId))
                .ForMember(c => c.Numero, p => p.MapFrom(x => x.Numero))
                .ForMember(c => c.Andar, p => p.MapFrom(x => x.Andar))
                .ForMember(c => c.GrupoId, p => p.MapFrom(x => x.GrupoId))
                .ForMember(c => c.DescricaoGrupo, p => p.MapFrom(x => x.DescricaoGrupo));
        }
    }
}
