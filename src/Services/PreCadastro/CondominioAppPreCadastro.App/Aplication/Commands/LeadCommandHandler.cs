using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using CondominioAppPreCadastro.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
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

            var NovoLead = new Lead(request.Nome, new Email(request.Email), new Telefone(request.Telefone));

            foreach (var CondominioModel in request.Condominios)
            {
                var condominio = CondominioFactory(CondominioModel);
                
                NovoLead.AdicionarCondominio(condominio);
            }

            _leadRepository.Adicionar(NovoLead);

            return await PersistirDados(_leadRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _leadRepository?.Dispose();
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