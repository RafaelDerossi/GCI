using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class ComunicadoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarComunicadoCommand, ValidationResult>,
         IRequestHandler<EditarComunicadoCommand, ValidationResult>,
         IRequestHandler<RemoverComunicadoCommand, ValidationResult>,
         IDisposable
    {

        private IComunidadoRepository _ComunicadoRepository;

        public ComunicadoCommandHandler(IComunidadoRepository comunicadoRepository)
        {
            _ComunicadoRepository = comunicadoRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicado = ComunicadoFactory(request);

            if (comunicado.Visibilidade == VisibilidadeComunicado.UNIDADES || comunicado.Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                if (request.Unidades==null || request.Unidades.Count() == 0)
                {
                    AdicionarErro("Informe uma ou mais unidades.");
                    return ValidationResult;
                }

                foreach (Unidade unidade in request.Unidades)
                {
                    var resultado = comunicado.AdicionarUnidade(unidade);
                    if (!resultado.IsValid) return resultado;
                }
            }
           
            _ComunicadoRepository.Adicionar(comunicado);

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

            comunicado.SetTitulo(request.Titulo);
            comunicado.SetDescricao(request.Descricao);
            comunicado.SetDataDeRealizacao(request.DataDeRealizacao);
            comunicado.SetUsuarioId(request.UsuarioId);
            comunicado.SetNomeUsuario(request.NomeUsuario);
            comunicado.SetVisibilidade(request.Visibilidade);
            comunicado.SetCategoria(request.Categoria);

            if (comunicado.Unidades != null)
            {
                foreach (Unidade unidade in comunicado.Unidades)
                {
                    _ComunicadoRepository.RemoverUnidade(unidade);
                }
            }
            comunicado.RemoverTodasUnidade();

            if (comunicado.Visibilidade == VisibilidadeComunicado.UNIDADES || comunicado.Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                if (request.Unidades == null || request.Unidades.Count() == 0)
                {
                    AdicionarErro("Informe uma ou mais unidades.");
                    return ValidationResult;
                }

                foreach (Unidade unidade in request.Unidades)
                {
                    var resultado = comunicado.AdicionarUnidade(unidade);
                    if (!resultado.IsValid) return resultado;
                    _ComunicadoRepository.AdicionarUnidade(unidade);
                }
            }           


            _ComunicadoRepository.Atualizar(comunicado);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(RemoverComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicadoBd = await _ComunicadoRepository.ObterPorId(request.ComunicadoId);
            if (comunicadoBd == null)
            {
                AdicionarErro("Comunicado não encontrado.");
                return ValidationResult;
            }

            comunicadoBd.EnviarParaLixeira();

            _ComunicadoRepository.Atualizar(comunicadoBd);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }



        private Comunicado ComunicadoFactory(CadastrarComunicadoCommand request)
        {
            var comunicado = new Comunicado(
                request.Titulo, request.Descricao, request.DataDeRealizacao, request.CondominioId, 
                request.NomeCondominio, request.UsuarioId, request.NomeUsuario, request.Visibilidade,
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
