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
    public class CondominioCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCondominioCommand, ValidationResult>, IDisposable
    {

        private ICondominioRepository _condominioRepository;

        public CondominioCommandHandler(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var condominio = CondominioFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            _condominioRepository.Adicionar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Condominio CondominioFactory(CadastrarCondominioCommand request)
        {
            try
            {
                var condominio = new Condominio(request.Cnpj, request.Nome, request.Descricao, request.LogoMarca,
                    request.Telefone, request.RefereciaId, request.LinkGeraBoleto, request.BoletoFolder, 
                    request.UrlWebServer, request.Portaria, request.PortariaMorador, request.Classificado, 
                    request.ClassificadoMorador, request.Mural, request.MuralMorador, request.Chat, request.ChatMorador,
                    request.Reserva, request.ReservaNaPortaria, request.Ocorrencia, request.OcorrenciaMorador, 
                    request.Correspondencia, request.CorrespondenciaNaPortaria, request.LimiteTempoReserva);

                return condominio;
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
