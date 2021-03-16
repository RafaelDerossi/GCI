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
    public class UnidadeCommandHandler : CommandHandler,
         IRequestHandler<CadastrarUnidadeCommand, ValidationResult>,
         IRequestHandler<EditarUnidadeCommand, ValidationResult>,
         IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>,
         IRequestHandler<RemoverUnidadeCommand, ValidationResult>, IDisposable
    {

        private IPrincipalRepository _condominioRepository;

        public UnidadeCommandHandler(IPrincipalRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidade = UnidadeFactory(request);

            var grupo = await _condominioRepository.ObterGrupoPorId(request.GrupoId);
            if (grupo == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            var condominio = await _condominioRepository.ObterPorId(grupo.CondominioId);
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }           

            var resultado = grupo.AdicionarUnidade(unidade);

            if (!resultado.IsValid) return resultado;

            //Verifica se o codigo da unidade ja esta cadastrado
            VerificaSeCodigoJaEstaCadastrado(unidade);

            _condominioRepository.AdicionarUnidade(unidade);

            unidade.AdicionarEvento(
                new UnidadeCadastradaEvent(unidade.Id,
                unidade.Codigo, unidade.Numero, unidade.Andar, unidade.Vagas,
                unidade.Telefone.Numero, unidade.Ramal, unidade.Complemento, unidade.GrupoId,
                grupo.Descricao, unidade.CondominioId, condominio.Cnpj.NumeroFormatado,
                condominio.Nome, condominio.LogoMarca.NomeDoArquivo));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidadeBD = await _condominioRepository.ObterUnidadePorId(request.UnidadeId);
            if (unidadeBD == null)
            {
                AdicionarErro("Unidade não encontrada.");
                return ValidationResult;
            }
            
            unidadeBD.SetNumero(request.Numero);
            unidadeBD.SetAndar(request.Andar);
            unidadeBD.SetVagas(request.Vaga);
            unidadeBD.SetTelefone(request.Telefone);
            unidadeBD.SetRamal(request.Ramal);
            unidadeBD.SetComplemento(request.Complemento);          

            var grupo = _condominioRepository.ObterGrupoPorId(unidadeBD.GrupoId).Result;
            if (grupo == null)
            {
                AdicionarErro("Grupo não encontrado.");
                return ValidationResult;
            }

            grupo.AlterarUnidade(unidadeBD);

            unidadeBD.AdicionarEvento(
               new UnidadeEditadaEvent(unidadeBD.Id,
               unidadeBD.Numero, unidadeBD.Andar, unidadeBD.Vagas, unidadeBD.Telefone.Numero,
               unidadeBD.Ramal, unidadeBD.Complemento));

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

            unidadeBD.ResetCodigo();

            //Verifica se o codigo da unidade ja esta cadastrado
            VerificaSeCodigoJaEstaCadastrado(unidadeBD);

            unidadeBD.AdicionarEvento(
              new CodigoUnidadeResetadoEvent(unidadeBD.Id, unidadeBD.Codigo));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverUnidadeCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var unidadeBD = _condominioRepository.ObterUnidadePorId(request.UnidadeId).Result;

            if (unidadeBD == null)
            {
                AdicionarErro("Unidade não encontrada.");
                return ValidationResult;
            }

            unidadeBD.EnviarParaLixeira();

            unidadeBD.AdicionarEvento(new UnidadeRemovidaEvent(unidadeBD.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);

        }




        private Unidade UnidadeFactory(UnidadeCommand request)
        {
            return new Unidade(request.Numero, request.Andar, request.Vaga, request.Telefone,
                    request.Ramal, request.Complemento, request.GrupoId, request.CondominioId,
                    request.Codigo);
        }

        private void VerificaSeCodigoJaEstaCadastrado(Unidade unidade)
        {
            bool codigoIsValid = false;
            while (codigoIsValid == false)
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
        }


        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
