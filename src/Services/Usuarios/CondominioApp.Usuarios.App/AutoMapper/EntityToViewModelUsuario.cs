using AutoMapper;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ViewModels;

namespace CondominioApp.Correspondencias.App.AutoMapper
{  
    public class EntityToViewModelUsuario : Profile
    {
        public EntityToViewModelUsuario()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(m => m.DataDeAlteracao, cfg => cfg.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(c => c.Nome, p  => p.MapFrom(x => x.Nome))
                .ForMember(c => c.Sobrenome, p => p.MapFrom(x => x.Sobrenome))
                .ForMember(c => c.Rg, p => p.MapFrom(x => x.Rg))
                .ForMember(c => c.Cpf, p => p.MapFrom(x => x.Cpf.Numero))
                .ForMember(c => c.Cel, p => p.MapFrom(x => x.Cel.Numero))
                .ForMember(c => c.Telefone, p => p.MapFrom(x => x.Telefone.Numero))
                .ForMember(c => c.Email, p => p.MapFrom(x => x.Email.Endereco))
                .ForMember(c => c.Foto, p => p.MapFrom(x => x.Foto.NomeDoArquivo))                
                .ForMember(c => c.Ativo, p => p.MapFrom(x => x.Ativo))                
                .ForMember(c => c.DataNascimento, p => p.MapFrom(x => x.DataNascimento))
                .ForMember(c => c.UltimoLogin, p => p.MapFrom(x => x.UltimoLogin))
                .ForMember(c => c.Logradouro, p => p.MapFrom(x => x.Endereco.logradouro))
                .ForMember(c => c.Complemento, p => p.MapFrom(x => x.Endereco.complemento))
                .ForMember(c => c.Numero, p => p.MapFrom(x => x.Endereco.numero))
                .ForMember(c => c.Cep, p => p.MapFrom(x => x.Endereco.cep))
                .ForMember(c => c.Bairro, p => p.MapFrom(x => x.Endereco.bairro))
                .ForMember(c => c.Cidade, p => p.MapFrom(x => x.Endereco.cidade))
                .ForMember(c => c.Estado, p => p.MapFrom(x => x.Endereco.estado))
                .ForMember(c => c.SindicoProfissional, p => p.MapFrom(x => x.SindicoProfissional));


            CreateMap<Mobile, MobileViewModel>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.DataDeCadastro, cfg => cfg.MapFrom(x => x.DataDeCadastroFormatada))
                .ForMember(m => m.DataDeAlteracao, cfg => cfg.MapFrom(x => x.DataDeAlteracaoFormatada))
                .ForMember(c => c.DeviceKey, p => p.MapFrom(x => x.DeviceKey))
                .ForMember(c => c.MobileId, p => p.MapFrom(x => x.MobileId))
                .ForMember(c => c.Modelo, p => p.MapFrom(x => x.Modelo))
                .ForMember(c => c.Plataforma, p => p.MapFrom(x => x.Plataforma))
                .ForMember(c => c.Versao, p => p.MapFrom(x => x.Versao))
                .ForMember(c => c.UsuarioId, p => p.MapFrom(x => x.MoradorIdFuncionadioId));

        }
    }
}
