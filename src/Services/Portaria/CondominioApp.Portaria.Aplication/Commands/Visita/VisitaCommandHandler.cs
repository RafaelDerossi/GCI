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
         IRequestHandler<EditarVisitaCommand, ValidationResult>,
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

            //Evento
            //

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = await _visitanteRepository.ObterVisitaPorId(request.Id);
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }
            visitaBd.SetNomeCondomino(request.NomeCondomino);
            visitaBd.SetNomeVisitante(request.NomeVisitante);
            visitaBd.SetTipoDeVisitante(request.TipoDeVisitante);
            visitaBd.SetNomeEmpresaVisitante(request.NomeEmpresaVisitante);
            visitaBd.SetUnidadeId(request.UnidadeId);
            visitaBd.SetNumeroUnidade(request.NumeroUnidade);
            visitaBd.SetAndarUnidade(request.AndarUnidade);
            visitaBd.SetGrupoUnidade(request.GrupoUnidade);
            visitaBd.SetVeiculo(request.Veiculo);


            var visitanteBd = await _visitanteRepository.ObterPorId(visitaBd.VisitanteId);
            if (visitanteBd == null)
            {
                AdicionarErro("Visitante não encontrada.");
                return ValidationResult;
            }
            visitanteBd.SetNome(request.NomeVisitante);
            visitanteBd.SetTipoDeVisitante(request.TipoDeVisitante);
            visitanteBd.SetNomeEmpresa(request.NomeEmpresaVisitante);
            visitanteBd.SetVeiculo(request.Veiculo);

            visitanteBd.AdicionarVisita(visitaBd);
           
            _visitanteRepository.Atualizar(visitanteBd);

            //Evento
            //

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

            visitaBd.EnviarParaLixeira();

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            //

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }



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
