﻿using CondominioApp.Core.Messages;
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
    public class CondominioCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCondominioCommand, ValidationResult>,
         IRequestHandler<AlterarCondominioCommand, ValidationResult>,
         IRequestHandler<AlterarConfiguracaoCondominioCommand, ValidationResult>,
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

            if (!ValidationResult.IsValid) return ValidationResult;

            _condominioRepository.Adicionar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;
            
            var condominioBd = await _condominioRepository.ObterPorId(request.CondominioId);
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            condominioBd.SetCNPJ(new Cnpj(request.Cnpj));
            condominioBd.SetNome(request.Nome);
            condominioBd.SetDescricao(request.Descricao);
            condominioBd.SetFoto(new Foto(request.NomeOriginal, request.LogoMarca));
            condominioBd.SetTelefone(new Telefone(request.Telefone));
            condominioBd.SetEndereco(new Endereco(request.Logradouro, request.Complemento,request.Numero, request.Cep, request.Bairro, request.Cidade, request.Estado));

            if (_condominioRepository.CnpjCondominioJaCadastrado(condominioBd.Cnpj, condominioBd.Id).Result)
            {
                AdicionarErro("CNPJ informado ja consta no sistema.");
                return ValidationResult;
            }

            _condominioRepository.Atualizar(condominioBd);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarConfiguracaoCondominioCommand request, CancellationToken cancellationToken)
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

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Condominio CondominioFactory(CadastrarCondominioCommand request)
        {

            var condominio = new Condominio(new Cnpj(request.Cnpj), request.Nome, request.Descricao,
                new Foto(request.NomeOriginal, request.LogoMarca), new Telefone(request.Telefone),
                new Endereco(request.Logradouro, request.Complemento, request.Numero, request.Cep,
                request.Bairro, request.Cidade, request.Estado),
                request.RefereciaId, request.LinkGeraBoleto, request.BoletoFolder,
                new Url(request.UrlWebServer), request.Portaria, request.PortariaMorador, request.Classificado,
                request.ClassificadoMorador, request.Mural, request.MuralMorador, request.Chat, request.ChatMorador,
                request.Reserva, request.ReservaNaPortaria, request.Ocorrencia, request.OcorrenciaMorador,
                request.Correspondencia, request.CorrespondenciaNaPortaria, request.LimiteTempoReserva);

            return condominio;
        }


        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }


    }
}
