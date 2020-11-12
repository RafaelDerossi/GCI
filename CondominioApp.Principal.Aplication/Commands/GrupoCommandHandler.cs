using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class GrupoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarGrupoCommand, ValidationResult>, IDisposable
    {

        private ICondominioRepository _condominioRepository;

        public GrupoCommandHandler(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupo = GrupoFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = _condominioRepository.ObterPorId(grupo.CondominioId).Result;
            condominio.AdicionarGrupo(grupo);

            _condominioRepository.Atualizar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Grupo GrupoFactory(CadastrarGrupoCommand request)
        {
            try
            {
                var grupo = new Grupo(request.Descricao, request.CondominioId);

                return grupo;
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return null;
            }
        }


        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
