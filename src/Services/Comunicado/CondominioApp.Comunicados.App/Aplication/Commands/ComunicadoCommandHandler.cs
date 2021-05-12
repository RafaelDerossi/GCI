using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class ComunicadoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarComunicadoCommand, ValidationResult>,
         IRequestHandler<EditarComunicadoCommand, ValidationResult>,
         IRequestHandler<ApagarComunicadoCommand, ValidationResult>,         
         IDisposable
    {

        private readonly IComunidadoRepository _ComunicadoRepository;

        public ComunicadoCommandHandler(IComunidadoRepository comunicadoRepository)
        {
            _ComunicadoRepository = comunicadoRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicado = ComunicadoFactory(request);

            var retorno = comunicado.AdicionarUnidades(request.Unidades);
            if (!retorno.IsValid)
                return retorno;
                       
            _ComunicadoRepository.Adicionar(comunicado);

            comunicado.EnviarPushNovoComunicado();
            
            comunicado.EnviarEmailNovoComunicado();

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(EditarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicado = await _ComunicadoRepository.ObterPorId(request.ComunicadoId);
            if (comunicado == null)
            {
                AdicionarErro("Comuninicado não encontrado!");
                return ValidationResult;
            }


            if (comunicado.Unidades != null)
            {
                foreach (UnidadeComunicado unidade in comunicado.Unidades)
                {
                    _ComunicadoRepository.RemoverUnidade(unidade);
                }
            }

            var retornotoEdicao = comunicado.Editar
                (request.Titulo, request.Descricao, request.DataDeRealizacao, request.FuncionarioId,
                 request.NomeFuncionario, request.Visibilidade, request.Categoria, request.Unidades);
            if (!retornotoEdicao.IsValid)
                return retornotoEdicao;


            if (comunicado.Unidades != null)
            {
                foreach (UnidadeComunicado unidade in comunicado.Unidades)
                {
                    _ComunicadoRepository.AdicionarUnidade(unidade);
                }
            }

           
            _ComunicadoRepository.Atualizar(comunicado);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(ApagarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicadoBd = await _ComunicadoRepository.ObterPorId(request.ComunicadoId);
            if (comunicadoBd == null)
            {
                AdicionarErro("Comunicado não encontrado.");
                return ValidationResult;
            }          

            _ComunicadoRepository.Apagar(x=>x.Id == comunicadoBd.Id);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }
        


        private Comunicado ComunicadoFactory(CadastrarComunicadoCommand request)
        {
            var comunicado = new Comunicado(
                request.Titulo, request.Descricao, request.DataDeRealizacao, request.CondominioId, 
                request.NomeCondominio, request.FuncionarioId, request.NomeFuncionario, request.Visibilidade,
                request.Categoria, request.TemAnexos, request.CriadoPelaAdministradora);

            comunicado.SetEntidadeId(request.ComunicadoId);

            return comunicado;
        }

     

        public void Dispose()
        {
            _ComunicadoRepository?.Dispose();
        }


    }
}
