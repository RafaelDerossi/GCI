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
         IRequestHandler<CadastrarGrupoCommand, ValidationResult>,
        IRequestHandler<AlterarGrupoCommand, ValidationResult>, IDisposable
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

            //Verifica se um Grupo com a mesma descricao ja esta cadastrado
            try
            {
                if (_condominioRepository.GrupoJaExiste(grupo.Descricao, grupo.CondominioId, grupo.Id).Result)
                {
                    AdicionarErro("Grupo informado ja consta no sistema.");
                    return ValidationResult;
                }
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            var condominio = _condominioRepository.ObterPorId(grupo.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
            condominio.AdicionarGrupo(grupo);                      
           

            _condominioRepository.AdicionarGrupo(grupo);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupoBd = _condominioRepository.ObterGrupoPorId(request.GrupoId).Result;           
            if (grupoBd == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }
            try
            {
                grupoBd.SetDescricao(request.Descricao);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            if (!ValidationResult.IsValid) return ValidationResult;

            //Verifica se um Grupo com a mesma descricao ja esta cadastrado
            try
            {
                if (_condominioRepository.GrupoJaExiste(grupoBd.Descricao, grupoBd.CondominioId, grupoBd.Id).Result)
                {
                    AdicionarErro("Grupo informado ja consta no sistema.");
                    return ValidationResult;
                }
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            var condominio = _condominioRepository.ObterPorId(grupoBd.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
            condominio.AlterarGrupo(grupoBd);
            

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
