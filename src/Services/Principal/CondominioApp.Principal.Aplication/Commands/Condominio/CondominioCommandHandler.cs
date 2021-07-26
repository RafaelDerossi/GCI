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
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class CondominioCommandHandler : CommandHandler,
         IRequestHandler<AdicionarCondominioCommand, ValidationResult>,
         IRequestHandler<AtualizarCondominioCommand, ValidationResult>,
         IRequestHandler<AtualizarConfiguracaoCondominioCommand, ValidationResult>,
         IRequestHandler<ApagarCondominioCommand, ValidationResult>,
         IRequestHandler<DefinirSindicoDoCondominioCommand, ValidationResult>,
         IRequestHandler<AtualizarLogoDoCondominioCommand, ValidationResult>,
         IDisposable
    {

        private readonly IPrincipalRepository _condominioRepository;

        public CondominioCommandHandler(IPrincipalRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var condominio = CondominioFactory(request);

            if (request.Contrato!=null)
                condominio.AdicionarContrato(request.Contrato);

            if (_condominioRepository.CnpjCondominioJaCadastrado(request.Cnpj, request.Id).Result)
            {
                AdicionarErro("CNPJ informado ja consta no sistema.");
                return ValidationResult;
            }

            _condominioRepository.Adicionar(condominio);

            AdicionarEventoDeCondominioCadastrado(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;
            
            var condominioBd = await _condominioRepository.ObterPorId(request.Id);
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            if (_condominioRepository.CnpjCondominioJaCadastrado(request.Cnpj, request.Id).Result)
            {
                AdicionarErro("CNPJ informado ja consta no sistema.");
                return ValidationResult;
            }

            condominioBd.SetCNPJ(request.Cnpj);
            condominioBd.SetNome(request.Nome);
            condominioBd.SetDescricao(request.Descricao);
            condominioBd.SetTelefone(request.Telefone);
            condominioBd.SetEndereco(request.Endereco);

            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
               new CondominioAtualizadoEvent
               (condominioBd.Id, condominioBd.Cnpj, condominioBd.Nome, condominioBd.Descricao,
                condominioBd.Telefone, condominioBd.Endereco));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarConfiguracaoCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.Id).Result;
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            if (request.PortariaAtivada)
                condominioBd.AtivarPortaria();
            else
                condominioBd.DesativarPortaria();


            if (request.PortariaParaMoradorAtivada)
                condominioBd.AtivarPortariaMorador();
            else
                condominioBd.DesativarPortariaMorador();


            if (request.ClassificadoAtivado)
                condominioBd.AtivarClassificado();
            else
                condominioBd.DesativarClassificado();


            if (request.ClassificadoParaMoradorAtivado)
                condominioBd.AtivarClassificadoMorador();
            else
                condominioBd.DesativarClassificadoMorador();


            if (request.MuralAtivado)
                condominioBd.AtivarMural();
            else
                condominioBd.DesativarMural();


            if (request.MuralParaMoradorAtivado)
                condominioBd.AtivarMuralMorador();
            else
                condominioBd.DesativarMuralMorador();


            if (request.ChatAtivado)
                condominioBd.AtivarChat();
            else
                condominioBd.DesativarChat();


            if (request.ChatParaMoradorAtivado)
                condominioBd.AtivarChatMorador();
            else
                condominioBd.DesativarChatMorador();

            if (request.ReservaAtivada)
                condominioBd.AtivarReserva();
            else
                condominioBd.DesativarReserva();


            if (request.ReservaNaPortariaAtivada)
                condominioBd.AtivarReservaNaPortaria();
            else
                condominioBd.DesativarReservaNaPortaria();


            if (request.OcorrenciaAtivada)
                condominioBd.AtivarOcorrencia();
            else
                condominioBd.DesativarOcorrencia();


            if (request.OcorrenciaParaMoradorAtivada)
                condominioBd.AtivarOcorrenciaMorador();
            else
                condominioBd.DesativarOcorrenciaMorador();


            if (request.CorrespondenciaAtivada)
                condominioBd.AtivarCorrespondencia();
            else
                condominioBd.DesativarCorrespondencia();


            if (request.CorrespondenciaNaPortariaAtivada)
                condominioBd.AtivarCorrespondenciaNaPortaria();
            else
                condominioBd.DesativarCorrespondenciaNaPortaria();

            if (request.CadastroDeVeiculoPeloMoradorAtivado)
                condominioBd.AtivarCadastroDeVeiculoPeloMorador();
            else
                condominioBd.DesativarCadastroDeVeiculoPeloMorador();


            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
              new ConfiguracaoDoCondominioAtualizadaEvent(condominioBd.Id,
              condominioBd.PortariaAtivada, condominioBd.PortariaParaMoradorAtivada, condominioBd.ClassificadoAtivado, 
              condominioBd.ClassificadoParaMoradorAtivado, condominioBd.MuralAtivado, condominioBd.MuralParaMoradorAtivado, 
              condominioBd.ChatAtivado, condominioBd.ChatParaMoradorAtivado, condominioBd.ReservaAtivada,
              condominioBd.ReservaNaPortariaAtivada, condominioBd.OcorrenciaAtivada, condominioBd.OcorrenciaParaMoradorAtivada,
              condominioBd.CorrespondenciaAtivada, condominioBd.CorrespondenciaNaPortariaAtivada,
              condominioBd.CadastroDeVeiculoPeloMoradorAtivado));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarLogoDoCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var condominioBd = await _condominioRepository.ObterPorId(request.Id);
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
         
            condominioBd.SetLogo(request.Logo);           

            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
               new LogoDoCondominioAtualizadoEvent
               (condominioBd.Id, condominioBd.LogoMarca));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.Id).Result;
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            _condominioRepository.Apagar(x=>x.Id == condominioBd.Id);

            condominioBd.AdicionarEvento(new CondominioApagadoEvent(condominioBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DefinirSindicoDoCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.Id).Result;
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            condominioBd.SetFuncionarioIdDoSindico(request.FuncionarioIdDoSindico);

            _condominioRepository.Atualizar(condominioBd);

            condominioBd.AdicionarEvento(
                new SindicoDoCondominioDefinidoEvent(condominioBd.Id, request.FuncionarioIdDoSindico, request.NomeDoSindico));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        private Condominio CondominioFactory(AdicionarCondominioCommand request)
        {
            var condominio = new Condominio(request.Id, request.Cnpj, request.Nome, request.Descricao, request.Logo, 
                request.Telefone, request.Endereco, request.PortariaAtivada, request.PortariaParaMoradorAtivada,
                request.ClassificadoAtivado, request.ClassificadoParaMoradorAtivado, request.MuralAtivado,
                request.MuralParaMoradorAtivado, request.ChatAtivado, request.ChatParaMoradorAtivado,
                request.ReservaAtivada, request.ReservaNaPortariaAtivada, request.OcorrenciaAtivada,
                request.OcorrenciaParaMoradorAtivada, request.CorrespondenciaAtivada,
                request.CorrespondenciaNaPortariaAtivada, request.CadastroDeVeiculoPeloMoradorAtivado);
            
            return condominio;
        }

        private void AdicionarEventoDeCondominioCadastrado(Condominio condominio)
        {
            var contrato = condominio.Contratos.FirstOrDefault();
            if (contrato == null)
            {
                contrato = new Contrato(condominio.Id, DataHoraDeBrasilia.Get(), TipoDePlano.FREE, "", false, null, 0);
            }

            condominio.AdicionarEvento(
               new CondominioAdicionadoEvent(condominio.Id,
               condominio.Cnpj, condominio.Nome, condominio.Descricao, condominio.LogoMarca,
               condominio.Telefone, condominio.Endereco, condominio.PortariaAtivada, 
               condominio.PortariaParaMoradorAtivada, condominio.ClassificadoAtivado,
               condominio.ClassificadoParaMoradorAtivado, condominio.MuralAtivado,
               condominio.MuralParaMoradorAtivado, condominio.ChatAtivado, condominio.ChatParaMoradorAtivado,
               condominio.ReservaAtivada, condominio.ReservaNaPortariaAtivada, condominio.OcorrenciaAtivada,
               condominio.OcorrenciaParaMoradorAtivada, condominio.CorrespondenciaAtivada, 
               condominio.CorrespondenciaNaPortariaAtivada, condominio.CadastroDeVeiculoPeloMoradorAtivado,
               contrato.Id, contrato.DataAssinatura, contrato.Tipo, contrato.Descricao, contrato.Ativo,
               contrato.QuantidadeDeUnidadesContratada, contrato.ArquivoContrato));
        }

        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
