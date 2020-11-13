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
    public class UnidadeCommandHandler : CommandHandler,
         IRequestHandler<CadastrarUnidadeCommand, ValidationResult>,
         IRequestHandler<AlterarUnidadeCommand, ValidationResult>, IDisposable
    {

        private ICondominioRepository _condominioRepository;

        public UnidadeCommandHandler(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidade = UnidadeFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = _condominioRepository.ObterPorId(unidade.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
            var grupo = _condominioRepository.ObterGrupoPorId(unidade.GrupoId).Result;
            if (grupo == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }
            condominio.AdicionarUnidade(unidade);

            //Verifica se uma Unidade igual ja esta cadastrado
            try
            {
                if (_condominioRepository.UnidadeJaExiste(unidade.Codigo,unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.CondominioId).Result)
                {
                    AdicionarErro("Unidade informada ja consta no sistema.");
                    return ValidationResult;
                }
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }


            _condominioRepository.AdicionarUnidade(unidade);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidade = UnidadeFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = _condominioRepository.ObterPorId(unidade.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
            var grupo = _condominioRepository.ObterGrupoPorId(unidade.GrupoId).Result;
            if (grupo == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }
            condominio.AlterarUnidade(unidade);

            
            _condominioRepository.Atualizar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Unidade UnidadeFactory(UnidadeCommand request)
        {
            try
            {
                var unidade = new Unidade(
                    request.Codigo, request.Numero, request.Andar, request.Vaga,
                    request.Telefone, request.Ramal, request.Complemento, request.GrupoId,
                    request.CondominioId);

                return unidade;
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
