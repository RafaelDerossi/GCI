using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class CorrespondenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCorrespondenciaCommand, ValidationResult>,         
         IDisposable
    {

        private ICorrespondenciaRepository _CorrespondenciaRepository;

        public CorrespondenciaCommandHandler(ICorrespondenciaRepository correspondenciaRepository)
        {
            _CorrespondenciaRepository = correspondenciaRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enquete = CorrespondenciaFactory(request);           

            _CorrespondenciaRepository.Adicionar(enquete);           

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

       
        


        private Correspondencia CorrespondenciaFactory(CadastrarCorrespondenciaCommand request)
        {
            var correspondencia = new Correspondencia(
                request.UnidadeId, request.NumeroUnidade, request.Bloco, request.Visto, request.NomeRetirante,
                request.Observacao, request.DataDaRetirada, request.UsuarioId, request.NomeUsuario, request.Foto,
                request.NumeroRastreamentoCorreio, request.DataDeChegada, request.QuantidadeDeAlertasFeitos,
                request.TipoDeCorrespondencia, request.Status);

            return correspondencia;
        }


        public void Dispose()
        {
            _CorrespondenciaRepository?.Dispose();
        }


    }
}
