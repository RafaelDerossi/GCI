using AutoMapper;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.AutoMapper
{
    public class EntityToViewModelLoja : Profile
    {
        public EntityToViewModelLoja()
        {
            CreateMap<Parceiro, ParceiroViewModel>()
                .ForMember(m => m.ParceiroId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(c => c.NumeroDoCnpj, p => p.MapFrom(x => x.Cnpj.numero))
                .ForMember(c => c.Logradouro, p => p.MapFrom(x => x.Endereco.logradouro))
                .ForMember(c => c.Cep, cfg => cfg.MapFrom(x => x.Endereco.ObterCepFormatado))
                .ForMember(c => c.Bairro, p => p.MapFrom(x => x.Endereco.bairro))
                .ForMember(c => c.Cidade, p => p.MapFrom(x => x.Endereco.cidade))
                .ForMember(c => c.Estado, p => p.MapFrom(x => x.Endereco.estado))
                .ForMember(c => c.EmailDoResponsavel, p => p.MapFrom(x => x.Email.Endereco))
                .ForMember(c => c.TelefoneCelular, p => p.MapFrom(x => x.TelefoneCelular.ObterNumeroFormatado))
                .ForMember(c => c.Whatsapp, p => p.MapFrom(x => x.TelefoneCelular.WhatsApp))
                .ForMember(c => c.TelefoneFixo, p => p.MapFrom(x => x.TelefoneFixo.ObterNumeroFormatado));


            CreateMap<ItemDeVenda, ItemDaVitrineViewModel>()
                 .ForMember(m => m.ItemDeVendaId, cfg => cfg.MapFrom(x => x.Id))
                 .ForMember(m => m.Nome, cfg => cfg.MapFrom(x => x.Produto.Nome))
                 .ForMember(m => m.Descricao, cfg => cfg.MapFrom(x => x.Produto.Descricao))
                 .ForMember(m => m.Chamada, cfg => cfg.MapFrom(x => x.Produto.Chamada))
                 .ForMember(m => m.Ativo, cfg => cfg.MapFrom(x => x.Produto.Ativo))
                 .ForMember(m => m.Url, cfg => cfg.MapFrom(x => x.Produto.Url.Endereco))
                 .ForMember(m => m.FotosDoProduto, cfg => cfg.MapFrom(x => x.Produto.Fotos))
                 .ForMember(m => m.PrecoDoProduto, cfg => cfg.MapFrom(x => x.PrecoDoProduto))
                 .ForMember(m => m.PrecoComDesconto, cfg => cfg.MapFrom(x => x.PrecoComDescontoFormatado))
                 .ForMember(m => m.ValorDoDesconto, cfg => cfg.MapFrom(x => x.PorcentagemDeDesconto))
                 .ForMember(m => m.PorcentagemDeDesconto, cfg => cfg.MapFrom(x => x.PorcentagemDeDescontoFormatado))
                 .ForMember(m => m.EspecificacaoTecnica, cfg => cfg.MapFrom(x => x.Produto.EspecificacaoTecnica))
                 .ForMember(m => m.TelefoneDoVendedor, cfg => cfg.MapFrom(x => x.Vendedor.Telefone.ObterNumeroFormatado))
                 .ForMember(m => m.Whatsapp, cfg => cfg.MapFrom(x => x.Vendedor.Telefone.WhatsApp))
                 .ForMember(m => m.EVisualizacaoDaWeb, cfg => cfg.MapFrom(x => x.Produto.EVisualizacaoDaWeb));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(m => m.ProdutoId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.LinkDoProduto, cfg => cfg.MapFrom(x => x.Url.Endereco))
                .ForMember(m => m.FotosDoProduto, cfg => cfg.MapFrom(x => x.Fotos));

            CreateMap<FotoDoProduto, FotoDoProdutoViewModel>()
                .ForMember(m => m.FotoDoProdutoId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.NomeDoArquivo, cfg => cfg.MapFrom(x => x.NomeArquivo));

            CreateMap<Vendedor, VendedorViewModel>()
                .ForMember(m => m.VendedorId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.EmailDoVendedor, cfg => cfg.MapFrom(x => x.Email.Endereco))
                .ForMember(m => m.CpfDoVendedor, cfg => cfg.MapFrom(x => x.Cpf.ObterNumeroFormatado()))
                .ForMember(m => m.TelefoneDoVendedor, cfg => cfg.MapFrom(x => x.Telefone.ObterNumeroFormatado))
                .ForMember(m => m.Whatsapp, cfg => cfg.MapFrom(x => x.Telefone.WhatsApp))
                .ForMember(m => m.logradouro, cfg => cfg.MapFrom(x => x.Endereco.logradouro))
                .ForMember(m => m.numero, cfg => cfg.MapFrom(x => x.Endereco.numero))
                .ForMember(m => m.bairro, cfg => cfg.MapFrom(x => x.Endereco.bairro))
                .ForMember(m => m.complemento, cfg => cfg.MapFrom(x => x.Endereco.complemento))
                .ForMember(m => m.cidade, cfg => cfg.MapFrom(x => x.Endereco.cidade))
                .ForMember(m => m.estado, cfg => cfg.MapFrom(x => x.Endereco.estado));

            CreateMap<Campanha, CampanhaViewModel>()
                .ForMember(m => m.CampanhaId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.ProdutoId, cfg => cfg.MapFrom(x => x.ItemDeVenda.ProdutoId))
                .ForMember(m => m.NomeDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Nome))
                .ForMember(m => m.DescricaoDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Descricao))
                .ForMember(m => m.ChamadaDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Chamada))
                .ForMember(m => m.EspecificacaoTecnica,
                    cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.EspecificacaoTecnica))
                .ForMember(m => m.LinkDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Url.Endereco))
                .ForMember(m => m.ParceiroId, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.ParceiroId))
                .ForMember(m => m.EVisualizacaoDaWeb,cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.EVisualizacaoDaWeb));

            CreateMap<Lead, LeadViewModel>()
                .ForMember(m => m.LeadId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(m => m.TelefoneDoCliente, cfg => cfg.MapFrom(x => x.Telefone.ObterNumeroFormatado))
                .ForMember(m => m.EmailDoMorador, cfg => cfg.MapFrom(x => x.EmailDoCliente.Endereco))
                .ForMember(m => m.PrecoDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.PrecoDoProduto))
                .ForMember(m => m.PrecoComDescontoFormatado, cfg => cfg.MapFrom(x => x.ItemDeVenda.PrecoComDescontoFormatado))
                .ForMember(m => m.PorcentagemDeDescontoFormatado, cfg => cfg.MapFrom(x => x.ItemDeVenda.PorcentagemDeDescontoFormatado))
                .ForMember(m => m.ProdutoId, cfg => cfg.MapFrom(x => x.ItemDeVenda.ProdutoId))
                .ForMember(m => m.Nome, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Nome))
                .ForMember(m => m.Descricao, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Descricao))
                .ForMember(m => m.Chamada, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Chamada))
                .ForMember(m => m.Descricao, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Descricao))
                .ForMember(m => m.EspecificacaoTecnica, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.EspecificacaoTecnica))
                .ForMember(m => m.linkDoProduto, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.Url.Endereco))
                .ForMember(m => m.EVisualizacaoDaWeb, cfg => cfg.MapFrom(x => x.ItemDeVenda.Produto.EVisualizacaoDaWeb));
        }
    }
}