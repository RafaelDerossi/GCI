using CondominioApp.Core.Messages;
using CondominioApp.Principal.Aplication.Events;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class CondominioCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCondominioCommand, ValidationResult>,
         IRequestHandler<EditarCondominioCommand, ValidationResult>,
         IRequestHandler<EditarConfiguracaoCondominioCommand, ValidationResult>,
         IRequestHandler<RemoverCondominioCommand, ValidationResult>, IDisposable
    {

        private ICondominioRepository _condominioRepository;

        public CondominioCommandHandler(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var condominio = CondominioFactory(request);

            if (request.Contrato!=null)
                condominio.AdicionarContrato(request.Contrato);

            if (_condominioRepository.CnpjCondominioJaCadastrado(request.Cnpj, request.CondominioId).Result)
            {
                AdicionarErro("CNPJ informado ja consta no sistema.");
                return ValidationResult;
            }

            _condominioRepository.Adicionar(condominio);

            AdicionarEventoDeCondominioCadastrado(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;
            
            var condominioBd = await _condominioRepository.ObterPorId(request.CondominioId);
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            if (_condominioRepository.CnpjCondominioJaCadastrado(request.Cnpj, request.CondominioId).Result)
            {
                AdicionarErro("CNPJ informado ja consta no sistema.");
                return ValidationResult;
            }

            condominioBd.SetCNPJ(request.Cnpj);
            condominioBd.SetNome(request.Nome);
            condominioBd.SetDescricao(request.Descricao);
            condominioBd.SetFoto(request.LogoMarca);
            condominioBd.SetTelefone(request.Telefone);
            condominioBd.SetEndereco(request.Endereco);            

            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
               new CondominioEditadoEvent(condominioBd.Id,
               condominioBd.Cnpj, condominioBd.Nome, condominioBd.Descricao, condominioBd.LogoMarca,
               condominioBd.Telefone, condominioBd.Endereco));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarConfiguracaoCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.CondominioId).Result;
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            if (request.Portaria)
                condominioBd.AtivarPortaria();
            else
                condominioBd.DesativarPortaria();


            if (request.PortariaMorador)
                condominioBd.AtivarPortariaMorador();
            else
                condominioBd.DesativarPortariaMorador();


            if (request.Classificado)
                condominioBd.AtivarClassificado();
            else
                condominioBd.DesativarClassificado();


            if (request.ClassificadoMorador)
                condominioBd.AtivarClassificadoMorador();
            else
                condominioBd.DesativarClassificadoMorador();


            if (request.Mural)
                condominioBd.AtivarMural();
            else
                condominioBd.DesativarMural();


            if (request.MuralMorador)
                condominioBd.AtivarMuralMorador();
            else
                condominioBd.DesativarMuralMorador();


            if (request.Chat)
                condominioBd.AtivarChat();
            else
                condominioBd.DesativarChat();


            if (request.ChatMorador)
                condominioBd.AtivarChatMorador();
            else
                condominioBd.DesativarChatMorador();

            if (request.Reserva)
                condominioBd.AtivarReserva();
            else
                condominioBd.DesativarReserva();


            if (request.ReservaNaPortaria)
                condominioBd.AtivarReservaNaPortaria();
            else
                condominioBd.DesativarReservaNaPortaria();


            if (request.Ocorrencia)
                condominioBd.AtivarOcorrencia();
            else
                condominioBd.DesativarOcorrencia();


            if (request.OcorrenciaMorador)
                condominioBd.AtivarOcorrenciaMorador();
            else
                condominioBd.DesativarOcorrenciaMorador();


            if (request.Correspondencia)
                condominioBd.AtivarCorrespondencia();
            else
                condominioBd.DesativarCorrespondencia();


            if (request.CorrespondenciaNaPortaria)
                condominioBd.AtivarCorrespondenciaNaPortaria();
            else
                condominioBd.DesativarCorrespondenciaNaPortaria();


            if (request.LimiteTempoReserva)
                condominioBd.AtivarLimiteTempoReserva();
            else
                condominioBd.DesativarLimiteTempoReserva();


            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
              new CondominioConfiguracaoEditadoEvent(condominioBd.Id,
              condominioBd.Portaria, condominioBd.PortariaMorador, condominioBd.Classificado, 
              condominioBd.ClassificadoMorador, condominioBd.Mural, condominioBd.MuralMorador, 
              condominioBd.Chat, condominioBd.ChatMorador, condominioBd.Reserva,
              condominioBd.ReservaNaPortaria, condominioBd.Ocorrencia, condominioBd.OcorrenciaMorador,
              condominioBd.Correspondencia, condominioBd.CorrespondenciaNaPortaria, condominioBd.LimiteTempoReserva));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.CondominioId).Result;
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            condominioBd.EnviarParaLixeira();

            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(new CondominioRemovidoEvent(condominioBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Condominio CondominioFactory(CadastrarCondominioCommand request)
        {
            var condominio = new Condominio(request.Cnpj, request.Nome, request.Descricao, request.LogoMarca, 
                request.Telefone, request.Endereco, request.RefereciaId, request.LinkGeraBoleto, request.BoletoFolder,
                request.UrlWebServer, request.Portaria, request.PortariaMorador, request.Classificado,
                request.ClassificadoMorador, request.Mural, request.MuralMorador, request.Chat, request.ChatMorador,
                request.Reserva, request.ReservaNaPortaria, request.Ocorrencia, request.OcorrenciaMorador,
                request.Correspondencia, request.CorrespondenciaNaPortaria, request.LimiteTempoReserva);
            
            return condominio;
        }

        private void AdicionarEventoDeCondominioCadastrado(Condominio condominio)
        {
            var contrato = new Contrato(condominio.Id, DateTime.Today.Date, 0, "", false, "");
            contrato.SetEntidadeId(Guid.Empty);
            if (condominio.Contratos.Count>0)
            {
                contrato = condominio.Contratos.FirstOrDefault();
            }

            condominio.AdicionarEvento(
               new CondominioCadastradoEvent(condominio.Id,
               condominio.Cnpj, condominio.Nome, condominio.Descricao, condominio.LogoMarca,
               condominio.Telefone, condominio.Endereco, condominio.RefereciaId, condominio.LinkGeraBoleto,
               condominio.BoletoFolder, condominio.UrlWebServer, condominio.Portaria, condominio.PortariaMorador,
               condominio.Classificado, condominio.ClassificadoMorador, condominio.Mural,
               condominio.MuralMorador, condominio.Chat, condominio.ChatMorador, condominio.Reserva,
               condominio.ReservaNaPortaria, condominio.Ocorrencia, condominio.OcorrenciaMorador,
               condominio.Correspondencia, condominio.CorrespondenciaNaPortaria, condominio.LimiteTempoReserva,
               contrato.Id, contrato.DataAssinatura, contrato.Tipo, contrato.Descricao, contrato.Ativo, contrato.Link));
        }

        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
