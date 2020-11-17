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
         IRequestHandler<AlterarUnidadeCommand, ValidationResult>,
        IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, IDisposable
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


            //Verifica se o codigo da unidade ja esta cadastrado
            VerificaSeCodigoJaEstaCadastrado(unidade);


            condominio.AdicionarUnidade(unidade);

            if (!ValidationResult.IsValid)
            {
                return ValidationResult;
            }

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
            
            var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;

            if (unidadeBD==null)
            {
                AdicionarErro("Unidade não encontrada.");
                return ValidationResult;
            }
            try
            {
                unidadeBD.SetNumero(request.Numero);
                unidadeBD.SetAndar(request.Andar);
                unidadeBD.SetVagas(request.Vaga);
                unidadeBD.SetTelefone(request.Telefone);
                unidadeBD.SetRamal(request.Ramal);
                unidadeBD.SetComplemento(request.Complemento);

            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }                

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = _condominioRepository.ObterPorId(unidadeBD.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }           
            condominio.AlterarUnidade(unidadeBD);

            if (!ValidationResult.IsValid)
            {
                return ValidationResult;
            }

            _condominioRepository.Atualizar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ResetCodigoUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;

            if (unidadeBD == null)
            {
                AdicionarErro("Unidade não encontrada.");
                return ValidationResult;
            }
            try
            {
                unidadeBD.ResetCodigo();               
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }

            if (!ValidationResult.IsValid) return ValidationResult;

            var condominio = _condominioRepository.ObterPorId(unidadeBD.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            //Verifica se o codigo da unidade ja esta cadastrado
            VerificaSeCodigoJaEstaCadastrado(unidadeBD);

            condominio.AlterarUnidade(unidadeBD);

            if (!ValidationResult.IsValid)
            {
                return ValidationResult;
            }           

            _condominioRepository.Atualizar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        private Unidade UnidadeFactory(UnidadeCommand request)
        {
            try
            {
                var unidade = new Unidade(
                    request.Numero, request.Andar, request.Vaga,
                    request.Telefone, request.Ramal, request.Complemento, request.GrupoId,
                    request.CondominioId);

                unidade.SetCodigo(request.Codigo);

                return unidade;
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
