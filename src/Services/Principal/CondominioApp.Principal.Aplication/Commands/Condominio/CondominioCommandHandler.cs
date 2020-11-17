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
         IRequestHandler<CadastrarCondominioCommand, ValidationResult>,
         IRequestHandler<AlterarCondominioCommand, ValidationResult>,
         IRequestHandler<AlterarConfiguracaoCondominioCommand, ValidationResult>, IDisposable
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

            //Verifica se um condominio com o mesmo cnpj ja esta cadastrado
            try
            {
                if (_condominioRepository.CnpjCondominioJaCadastrado(condominio.Cnpj, condominio.Id).Result)
                {
                    AdicionarErro("CNPJ informado ja consta no sistema.");
                    return ValidationResult;
                }
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }
           
            _condominioRepository.Adicionar(condominio);

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var condominioBd = _condominioRepository.ObterPorId(request.CondominioId).Result;
            
            if (condominioBd == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }
            try
            {
                condominioBd.SetCNPJ(request.Cnpj);
                condominioBd.SetNome(request.Nome);                
                condominioBd.SetDescricao(request.Descricao);
                condominioBd.SetFoto(request.LogoMarca);
                condominioBd.SetTelefone(request.Telefone);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }


            if (!ValidationResult.IsValid) return ValidationResult;


            //Verifica se um condominio com o mesmo cnpj ja esta cadastrado
            try
            {
                if (_condominioRepository.CnpjCondominioJaCadastrado(condominioBd.Cnpj, condominioBd.Id).Result)
                {
                    AdicionarErro("CNPJ informado ja consta no sistema.");
                    return ValidationResult;
                }
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
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
            try
            {
                if (request.Portaria==true)
                {
                    condominioBd.AtivarPortaria();
                }
                else
                {
                    condominioBd.DesativarPortaria();
                }

                if (request.PortariaMorador == true)
                {
                    condominioBd.AtivarPortariaMorador();
                }
                else
                {
                    condominioBd.DesativarPortariaMorador();
                }

                if (request.Classificado == true)
                {
                    condominioBd.AtivarClassificado();
                }
                else
                {
                    condominioBd.DesativarClassificado();
                }

                if (request.ClassificadoMorador == true)
                {
                    condominioBd.AtivarClassificadoMorador();
                }
                else
                {
                    condominioBd.DesativarClassificadoMorador();
                }

                if (request.Mural == true)
                {
                    condominioBd.AtivarMural();
                }
                else
                {
                    condominioBd.DesativarMural();
                }

                if (request.MuralMorador == true)
                {
                    condominioBd.AtivarMuralMorador();
                }
                else
                {
                    condominioBd.DesativarMuralMorador();
                }

                if (request.Chat == true)
                {
                    condominioBd.AtivarChat();
                }
                else
                {
                    condominioBd.DesativarChat();
                }

                if (request.ChatMorador == true)
                {
                    condominioBd.AtivarChatMorador();
                }
                else
                {
                    condominioBd.DesativarChatMorador();
                }

                if (request.Reserva == true)
                {
                    condominioBd.AtivarReserva();
                }
                else
                {
                    condominioBd.DesativarReserva();
                }

                if (request.ReservaNaPortaria == true)
                {
                    condominioBd.AtivarReservaNaPortaria();
                }
                else
                {
                    condominioBd.DesativarReservaNaPortaria();
                }

                if (request.Ocorrencia == true)
                {
                    condominioBd.AtivarOcorrencia();
                }
                else
                {
                    condominioBd.DesativarOcorrencia();
                }

                if (request.OcorrenciaMorador == true)
                {
                    condominioBd.AtivarOcorrenciaMorador();
                }
                else
                {
                    condominioBd.DesativarOcorrenciaMorador();
                }

                if (request.Correspondencia == true)
                {
                    condominioBd.AtivarCorrespondencia();
                }
                else
                {
                    condominioBd.DesativarCorrespondencia();
                }

                if (request.CorrespondenciaNaPortaria == true)
                {
                    condominioBd.AtivarCorrespondenciaNaPortaria();
                }
                else
                {
                    condominioBd.DesativarCorrespondenciaNaPortaria();
                }

                if (request.LimiteTempoReserva == true)
                {
                    condominioBd.AtivarLimiteTempoReserva();
                }
                else
                {
                    condominioBd.DesativarLimiteTempoReserva();
                }
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return ValidationResult;
            }


            if (!ValidationResult.IsValid) return ValidationResult;
                        

            _condominioRepository.Atualizar(condominioBd);

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
