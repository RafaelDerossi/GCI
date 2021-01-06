using CondominioApp.Core.Messages;
using CondominioApp.Principal.Aplication.Events;
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
         IRequestHandler<EditarGrupoCommand, ValidationResult>,
         IRequestHandler<RemoverGrupoCommand, ValidationResult>, IDisposable
    {

        private ICondominioRepository _condominioRepository;

        public GrupoCommandHandler(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupo = new Grupo(request.Descricao, request.CondominioId);

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = await _condominioRepository.ObterPorId(grupo.CondominioId);
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            var resultado = condominio.AdicionarGrupo(grupo);

            if (!resultado.IsValid) return resultado;

            _condominioRepository.AdicionarGrupo(grupo);

            grupo.AdicionarEvento(
                new GrupoCadastradoEvent(grupo.Id,
                grupo.Descricao, grupo.CondominioId, condominio.Cnpj.NumeroFormatado,
                condominio.Nome, condominio.LogoMarca.NomeDoArquivo));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupoBd = _condominioRepository.ObterGrupoPorId(request.GrupoId).Result;
            if (grupoBd == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            grupoBd.SetDescricao(request.Descricao);

            var condominio = _condominioRepository.ObterPorId(grupoBd.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            var resultado = condominio.AlterarGrupo(grupoBd);

            if (!resultado.IsValid) return resultado;

            _condominioRepository.Atualizar(condominio);

            grupoBd.AdicionarEvento(
              new GrupoEditadoEvent(grupoBd.Id, grupoBd.Descricao));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupoBd = _condominioRepository.ObterGrupoPorId(request.GrupoId).Result;

            if (grupoBd == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            grupoBd.EnviarParaLixeira();

            grupoBd.AdicionarEvento(
             new GrupoRemovidoEvent(grupoBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }
        
        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
