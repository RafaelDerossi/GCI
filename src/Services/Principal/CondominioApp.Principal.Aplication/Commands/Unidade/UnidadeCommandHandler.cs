using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
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
         IRequestHandler<AlterarUnidadeCommand, ValidationResult>,
         IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>,
         IRequestHandler<RemoverUnidadeCommand, ValidationResult>, IDisposable
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
            
            var grupo = _condominioRepository.ObterGrupoPorId(unidade.GrupoId).Result;
            if (grupo == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            var resultado = grupo.AdicionarUnidade(unidade);

            if (!resultado.IsValid) return resultado;
            
            _condominioRepository.AdicionarUnidade(unidade);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;


            try
            {
                var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;
                if (unidadeBD == null)
                {
                    AdicionarErro("Unidade não encontrada.");
                    return ValidationResult;
                }

                unidadeBD.SetNumero(request.Numero);
                unidadeBD.SetAndar(request.Andar);
                unidadeBD.SetVagas(request.Vaga);
                unidadeBD.SetTelefone(new Telefone(request.Telefone));
                unidadeBD.SetRamal(request.Ramal);
                unidadeBD.SetComplemento(request.Complemento);


                var grupo = _condominioRepository.ObterGrupoPorId(unidadeBD.GrupoId).Result;
                if (grupo == null)
                {
                    AdicionarErro("Grupo não encontrado.");
                    return ValidationResult;
                }

                grupo.AlterarUnidade(unidadeBD);

                var condominio = _condominioRepository.ObterPorId(unidadeBD.CondominioId).Result;
                if (condominio == null)
                {
                    AdicionarErro("Condominio não encontrado.");
                    return ValidationResult;
                }

                condominio.AlterarGrupo(grupo);

                _condominioRepository.Atualizar(condominio);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ResetCodigoUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            try
            {
                var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;

                if (unidadeBD == null)
                {
                    AdicionarErro("Unidade não encontrada.");
                    return ValidationResult;
                }

                unidadeBD.ResetCodigo();

                //Verifica se o codigo da unidade ja esta cadastrado
                VerificaSeCodigoJaEstaCadastrado(unidadeBD);

                var grupo = _condominioRepository.ObterGrupoPorId(unidadeBD.GrupoId).Result;
                if (grupo == null)
                {
                    AdicionarErro("Grupo não encontrado.");
                    return ValidationResult;
                }

                grupo.AlterarUnidade(unidadeBD);

                var condominio = _condominioRepository.ObterPorId(unidadeBD.CondominioId).Result;
                if (condominio == null)
                {
                    AdicionarErro("Condominio não encontrado.");
                    return ValidationResult;
                }

                condominio.AlterarGrupo(grupo);

                _condominioRepository.Atualizar(condominio);

            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            try
            {
                var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;

                if (unidadeBD == null)
                {
                    AdicionarErro("Unidade não encontrada.");
                    return ValidationResult;
                }

                unidadeBD.EnviarParaLixeira();

                var grupo = _condominioRepository.ObterGrupoPorId(unidadeBD.GrupoId).Result;
                if (grupo == null)
                {
                    AdicionarErro("Grupo não encontrado.");
                    return ValidationResult;
                }

                grupo.AlterarUnidade(unidadeBD);

                var condominio = _condominioRepository.ObterPorId(unidadeBD.CondominioId).Result;
                if (condominio == null)
                {
                    AdicionarErro("Condominio não encontrado.");
                    return ValidationResult;
                }

                condominio.AlterarGrupo(grupo);

                _condominioRepository.Atualizar(condominio);

            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }




        private Unidade UnidadeFactory(UnidadeCommand request)
        {
            try
            {

                return new Unidade(request.Numero, request.Andar, request.Vaga, new Telefone(request.Telefone),
                    request.Ramal, request.Complemento, request.GrupoId, request.CondominioId, request.Codigo);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return null;
            }
        }

        private void VerificaSeCodigoJaEstaCadastrado(Unidade unidade)
        {
            bool codigoIsValid = false;
            while (codigoIsValid == false)
            {
                try
                {
                    if (_condominioRepository.CodigoDaUnidadeJaExiste(unidade.Codigo, unidade.Id).Result)
                    {
                        unidade.ResetCodigo();
                    }
                    else
                    {
                        codigoIsValid = true;
                    }
                }
                catch (Exception)
                {
                }
            }
        }


        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
