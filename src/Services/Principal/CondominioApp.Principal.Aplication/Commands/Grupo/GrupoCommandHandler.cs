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
         IRequestHandler<AdicionarGrupoCommand, ValidationResult>,
         IRequestHandler<AtualizarGrupoCommand, ValidationResult>,
         IRequestHandler<ApagarGrupoCommand, ValidationResult>, IDisposable
    {

        private readonly IPrincipalRepository _condominioRepository;

        public GrupoCommandHandler(IPrincipalRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarGrupoCommand request, CancellationToken cancellationToken)
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
                grupo.Descricao, grupo.CondominioId, condominio.Cnpj.Numero,
                condominio.Nome, condominio.Logo.NomeDoArquivo));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarGrupoCommand request, CancellationToken cancellationToken)
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

        public async Task<ValidationResult> Handle(ApagarGrupoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var grupoBd = _condominioRepository.ObterGrupoPorId(request.GrupoId).Result;

            if (grupoBd == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            _condominioRepository.ApagarGrupo(x=>x.Id == grupoBd.Id);

            grupoBd.AdicionarEvento(
             new GrupoApagadoEvent(grupoBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }
        
        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
