using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public class VisitaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarVisitaCommand, ValidationResult>,
         IDisposable
    {
        private IVisitanteRepository _visitanteRepository;

        public VisitaCommandHandler(IVisitanteRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            Visitante visitante;

            if (request.VisitanteId == Guid.Empty)
            {
                if (request.CpfVisitante != null)
                {
                    if (_visitanteRepository.VisitanteJaCadastradoPorCpf(request.CpfVisitante, request.VisitanteId).Result)
                    {
                        AdicionarErro("CPF informado ja consta no sistema.");
                        return ValidationResult;
                    }
                }

                if (request.RgVisitante != null)
                {
                    if (_visitanteRepository.VisitanteJaCadastradoPorRg(request.RgVisitante, request.VisitanteId).Result)
                    {
                        AdicionarErro("RG informado ja consta no sistema.");
                        return ValidationResult;
                    }
                }

                visitante = VisitanteFactory(request);
            }
            else
            {
                visitante = await _visitanteRepository.ObterPorId(request.VisitanteId);
                if (visitante == null)
                {
                    AdicionarErro("Visitante não encontrado.");
                    return ValidationResult;
                }
                visitante.SetNome(request.NomeVisitante);
                visitante.SetTipoDeDocumento(request.TipoDeDocumentoVisitante);
                visitante.SetCpf(request.CpfVisitante);
                visitante.SetRg(request.RgVisitante);
                visitante.SetEmail(request.EmailVisitante);
                visitante.SetFoto(request.FotoVisitante);
                visitante.SetTipoDeVisitante(request.TipoDeVisitante);
                visitante.SetNomeEmpresa(request.NomeEmpresaVisitante);
                visitante.SetVeiculo(request.Veiculo);
            }
            
            
            var visita = VisitaFactory(request);

            visitante.AdicionarVisita(visita);

            
            if (request.VisitanteId == Guid.Empty)
            {
                _visitanteRepository.Adicionar(visitante);
            }
            else
            {
                _visitanteRepository.AdicionarVisita(visita);
                _visitanteRepository.Atualizar(visitante);
            }



            //visitante.AdicionarEvento(
            //    new CondominioCadastradoEvent(visitante.Id,
            //    visitante.Cnpj, visitante.Nome, visitante.Descricao, visitante.LogoMarca,
            //    visitante.Telefone, visitante.Endereco, visitante.RefereciaId, visitante.LinkGeraBoleto, 
            //    visitante.BoletoFolder, visitante.UrlWebServer, visitante.Portaria, visitante.PortariaMorador,
            //    visitante.Classificado, visitante.ClassificadoMorador, visitante.Mural,
            //    visitante.MuralMorador, visitante.Chat, visitante.ChatMorador, visitante.Reserva,
            //    visitante.ReservaNaPortaria, visitante.Ocorrencia, visitante.OcorrenciaMorador,
            //    visitante.Correspondencia, visitante.CorrespondenciaNaPortaria, visitante.LimiteTempoReserva));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        //public async Task<ValidationResult> Handle(EditarCondominioCommand request, CancellationToken cancellationToken)
        //{
        //    if (!request.EstaValido()) return request.ValidationResult;
            
        //    var condominioBd = await _visitanteRepository.ObterPorId(request.CondominioId);
        //    if (condominioBd == null)
        //    {
        //        AdicionarErro("Condominio não encontrado.");
        //        return ValidationResult;
        //    }

        //    if (_visitanteRepository.CnpjCondominioJaCadastrado(request.Cnpj, request.CondominioId).Result)
        //    {
        //        AdicionarErro("CNPJ informado ja consta no sistema.");
        //        return ValidationResult;
        //    }

        //    condominioBd.SetCNPJ(request.Cnpj);
        //    condominioBd.SetNome(request.Nome);
        //    condominioBd.SetDescricao(request.Descricao);
        //    condominioBd.SetFoto(request.LogoMarca);
        //    condominioBd.SetTelefone(request.Telefone);
        //    condominioBd.SetEndereco(request.Endereco);            

        //    _visitanteRepository.Atualizar(condominioBd);

        //    condominioBd.AdicionarEvento(
        //       new CondominioEditadoEvent(condominioBd.Id,
        //       condominioBd.Cnpj, condominioBd.Nome, condominioBd.Descricao, condominioBd.LogoMarca,
        //       condominioBd.Telefone, condominioBd.Endereco));

        //    return await PersistirDados(_visitanteRepository.UnitOfWork);
        //}

        //public async Task<ValidationResult> Handle(EditarConfiguracaoCondominioCommand request, CancellationToken cancellationToken)
        //{
        //    if (!request.EstaValido())
        //        return request.ValidationResult;

        //    var condominioBd = _visitanteRepository.ObterPorId(request.CondominioId).Result;
        //    if (condominioBd == null)
        //    {
        //        AdicionarErro("Condominio não encontrado.");
        //        return ValidationResult;
        //    }

        //    if (request.Portaria)
        //        condominioBd.AtivarPortaria();
        //    else
        //        condominioBd.DesativarPortaria();


        //    if (request.PortariaMorador)
        //        condominioBd.AtivarPortariaMorador();
        //    else
        //        condominioBd.DesativarPortariaMorador();


        //    if (request.Classificado)
        //        condominioBd.AtivarClassificado();
        //    else
        //        condominioBd.DesativarClassificado();


        //    if (request.ClassificadoMorador)
        //        condominioBd.AtivarClassificadoMorador();
        //    else
        //        condominioBd.DesativarClassificadoMorador();


        //    if (request.Mural)
        //        condominioBd.AtivarMural();
        //    else
        //        condominioBd.DesativarMural();


        //    if (request.MuralMorador)
        //        condominioBd.AtivarMuralMorador();
        //    else
        //        condominioBd.DesativarMuralMorador();


        //    if (request.Chat)
        //        condominioBd.AtivarChat();
        //    else
        //        condominioBd.DesativarChat();


        //    if (request.ChatMorador)
        //        condominioBd.AtivarChatMorador();
        //    else
        //        condominioBd.DesativarChatMorador();

        //    if (request.Reserva)
        //        condominioBd.AtivarReserva();
        //    else
        //        condominioBd.DesativarReserva();


        //    if (request.ReservaNaPortaria)
        //        condominioBd.AtivarReservaNaPortaria();
        //    else
        //        condominioBd.DesativarReservaNaPortaria();


        //    if (request.Ocorrencia)
        //        condominioBd.AtivarOcorrencia();
        //    else
        //        condominioBd.DesativarOcorrencia();


        //    if (request.OcorrenciaMorador)
        //        condominioBd.AtivarOcorrenciaMorador();
        //    else
        //        condominioBd.DesativarOcorrenciaMorador();


        //    if (request.Correspondencia)
        //        condominioBd.AtivarCorrespondencia();
        //    else
        //        condominioBd.DesativarCorrespondencia();


        //    if (request.CorrespondenciaNaPortaria)
        //        condominioBd.AtivarCorrespondenciaNaPortaria();
        //    else
        //        condominioBd.DesativarCorrespondenciaNaPortaria();


        //    if (request.LimiteTempoReserva)
        //        condominioBd.AtivarLimiteTempoReserva();
        //    else
        //        condominioBd.DesativarLimiteTempoReserva();


        //    _visitanteRepository.Atualizar(condominioBd);

        //    condominioBd.AdicionarEvento(
        //      new CondominioConfiguracaoEditadoEvent(condominioBd.Id,
        //      condominioBd.Portaria, condominioBd.PortariaMorador, condominioBd.Classificado, 
        //      condominioBd.ClassificadoMorador, condominioBd.Mural, condominioBd.MuralMorador, 
        //      condominioBd.Chat, condominioBd.ChatMorador, condominioBd.Reserva,
        //      condominioBd.ReservaNaPortaria, condominioBd.Ocorrencia, condominioBd.OcorrenciaMorador,
        //      condominioBd.Correspondencia, condominioBd.CorrespondenciaNaPortaria, condominioBd.LimiteTempoReserva));

        //    return await PersistirDados(_visitanteRepository.UnitOfWork);
        //}

        //public async Task<ValidationResult> Handle(RemoverCondominioCommand request, CancellationToken cancellationToken)
        //{
        //    if (!request.EstaValido()) return request.ValidationResult;

        //    var condominioBd = _visitanteRepository.ObterPorId(request.CondominioId).Result;
        //    if (condominioBd == null)
        //    {
        //        AdicionarErro("Condominio não encontrado.");
        //        return ValidationResult;
        //    }

        //    condominioBd.EnviarParaLixeira();

        //    _visitanteRepository.Atualizar(condominioBd);

        //    condominioBd.AdicionarEvento(new CondominioRemovidoEvent(condominioBd.Id));

        //    return await PersistirDados(_visitanteRepository.UnitOfWork);
        //}


        private Visita VisitaFactory(CadastrarVisitaCommand request)
        {
            return new Visita
                (request.DataDeEntrada, request.NomeCondominio, request.Observacao, request.Status,
                 request.VisitanteId, request.NomeVisitante,request.TipoDeDocumentoVisitante,
                 request.RgVisitante,request.CpfVisitante, request.EmailVisitante,request.FotoVisitante,
                 request.TipoDeVisitante, request.NomeEmpresaVisitante, request.CondominioId,
                 request.NomeCondominio, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.GrupoUnidade, request.Veiculo);            
        }


        private Visitante VisitanteFactory(CadastrarVisitaCommand request)
        {
            return new Visitante
                (request.NomeVisitante, request.TipoDeDocumentoVisitante, request.RgVisitante,
                request.CpfVisitante, request.EmailVisitante, request.FotoVisitante, request.CondominioId,
                request.NomeCondominio, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                request.GrupoUnidade, false, "", request.TipoDeVisitante, request.NomeEmpresaVisitante, request.Veiculo);
        }

        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
