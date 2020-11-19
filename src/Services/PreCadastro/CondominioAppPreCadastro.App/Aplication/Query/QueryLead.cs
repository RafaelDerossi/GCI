using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioAppPreCadastro.App.Models;
using CondominioAppPreCadastro.App.ViewModel;

namespace CondominioAppPreCadastro.App.Aplication.Query
{
    public class QueryLead : IQueryLead
    {
        private readonly ILeadRepository _leadRepository;

        public QueryLead(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<LeadViewModel> ObterPorId(Guid Id)
        {
            var lead = await _leadRepository.ObterPorId(Id);

            return MapearLead(lead);
        }

        public async Task<IEnumerable<LeadViewModel>> ObterTodos()
        {
            var Limite = DateTime.Now.AddDays(-32);

            var leads = await _leadRepository.Obter(l => l.DataDeCadastro.Date >= Limite.Date && !l.Lixeira, true);

            return MapearLeads(leads.ToList());
        }

        public async Task<IEnumerable<LeadViewModel>> ObterPorDatas(DateTime DataInicio, DateTime DataFim)
        {
            var leads = await _leadRepository.Obter(l => l.DataDeCadastro.Date >= DataInicio.Date &&
                                                         l.DataDeCadastro <= DataFim.Date &&
                                                         !l.Lixeira);

            return MapearLeads(leads.ToList());
        }

        public async Task<IEnumerable<LeadViewModel>> ObterPendentes()
        {
            var leads = await _leadRepository.Obter(l => l.Status == StatusPreCadastro.PENDENTE && !l.Lixeira);

            return MapearLeads(leads.ToList());
        }

        public void Dispose()
        {
           _leadRepository?.Dispose();
        }


        private List<LeadViewModel> MapearLeads(List<Lead> ListaDeLead)
        {
            var Lista = new List<LeadViewModel>();

            foreach (var lead in ListaDeLead)
            {
                Lista.Add(MapearLead(lead));
            }

            return Lista;
        }


        private LeadViewModel MapearLead(Lead lead)
        {
            var LeadViewModel = new LeadViewModel()
            {
                LeadId = lead.Id,
                nome = lead.Nome,
                email = lead.Email.Endereco,
                telefone = lead.Telefone.ObterNumeroFormatado,
                DataDeCadastroFormatada = lead.DataDeCadastroFormatada,
                StatusDoCadastro = Enum.GetName(typeof(StatusPreCadastro),lead.Status),
                motivoStatus = lead.Motivo,
                PlanoEscolhido = Enum.GetName(typeof(TipoDePlano),lead.TipoDePlano)
            };

            LeadViewModel.condominios = lead.Condominios.Select(c => new CondominioModel()
            {
                CondominioId = c.Id,
                nomeDoCondominio = c.NomeDoCondominio,
                razaoSocial = c.RazaoSocial,
                nomeDoSindico = c.NomeDoSindico,
                emailDoSindico = c.EmailDoSindico.Endereco,
                telefoneDoSindico = c.TelefoneDoSindico.ObterNumeroFormatado,
                TipoDeDocumentoFormatada = Enum.GetName(typeof(TipoDeDocumento),c.TipoDeDocumento),
                outroTipoDeDocumento = c.OutroTipoDeDocumento,
                numeroDoDocumento = c.NumeroDoDocumento,
                TipoDeUnidadeFormatada = Enum.GetName(typeof(TipoDeUnidade), c.TipoDeUnidade),
                TipoDeGrupoFormatada = Enum.GetName(typeof(TipoDeGrupo), c.TipoDeGrupo),
                quantidadeDeGrupos = c.QuantidadeDeGrupos,
                quantidadeDeAndar = c.QuantidadeDeAndar,
                quantidadeDeUnidadesPorAndar = c.QuantidadeDeUnidadesPorAndar,
                quantidadeDeUnidades = c.QuantidadeDeUnidades,
                observacao = c.Observacao,
                Transferido = c.Transferido,
                cep = c.Endereco.ObterCepFormatado,
                bairro = c.Endereco.bairro,
                estado = c.Endereco.estado,
                cidade = c.Endereco.cidade,
                logradouro = c.Endereco.logradouro,
                numero = c.Endereco.numero,
                complemento = c.Endereco.complemento
            }).ToList();

            return LeadViewModel;
        }
    }
}