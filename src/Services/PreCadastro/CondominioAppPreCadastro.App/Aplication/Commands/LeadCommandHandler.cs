using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using CondominioAppPreCadastro.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioAppPreCadastro.App.Aplication.Events;
using CondominioAppPreCadastro.App.ViewModel;

namespace CondominioAppPreCadastro.App.Aplication.Commands
{
    public class LeadCommandHandler : CommandHandler,
        IRequestHandler<InserirNovoLeadCommand, ValidationResult>, IDisposable
    {
        private readonly ILeadRepository _leadRepository;

        public LeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<ValidationResult> Handle(InserirNovoLeadCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;
            
            var NovoLead = LeadFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            foreach (var CondominioModel in request.Condominios)
            {
                var condominio = CondominioFactory(CondominioModel);

                NovoLead.AdicionarCondominio(condominio);
            }

            _leadRepository.Adicionar(NovoLead);

            NovoLead.AdicionarEvento(new LeadCadastradoEvent(NovoLead));

            return await PersistirDados(_leadRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _leadRepository?.Dispose();
        }

        private Lead LeadFactory(InserirNovoLeadCommand Comando)
        {
            try
            {
                return new Lead(Comando.Nome, new Email(Comando.Email), new Telefone(Comando.Telefone), (TipoDePlano)Comando.Plano);
            }
            catch (Exception e)
            {
                AdicionarErro(e.Message);
                return null;
            }
        }

        private Condominio CondominioFactory(CondominioModel CondominioModel)
        {
            return new Condominio(CondominioModel.nomeDoCondominio, CondominioModel.razaoSocial, CondominioModel.nomeDoSindico,
                new Email(CondominioModel.emailDoSindico), new Telefone(CondominioModel.telefoneDoSindico),
                (TipoDeDocumento)CondominioModel.tipoDeDocumento, CondominioModel.outroTipoDeDocumento, CondominioModel.numeroDoDocumento, (TipoDeUnidade)CondominioModel.tipoDeUnidade,
                (TipoDeGrupo)CondominioModel.tipoDeGrupo, CondominioModel.quantidadeDeGrupos, CondominioModel.quantidadeDeAndar, CondominioModel.quantidadeDeUnidadesPorAndar,
                CondominioModel.quantidadeDeUnidades, CondominioModel.observacao,
                new Endereco(CondominioModel.logradouro, CondominioModel.complemento, CondominioModel.numero, CondominioModel.cep, CondominioModel.bairro, CondominioModel.cidade, CondominioModel.estado), (TipoDePlano)CondominioModel.plano);
        }
    }
}