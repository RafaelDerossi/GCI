using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using CondominioApp.Automacao.ViewModel;
using CondominioApp.Automacao.App.Services.Interfaces;
using CondominioApp.Core.Service;
using CondominioApp.Automacao.App.Aplication.Query;
using System;
using CondominioApp.Automacao.Webhook;
using System.Linq;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Automacao.Services
{
   public class DispositivosWebhookService : ServiceBase, IDispositivosService
    {
        private readonly IAutomacaoQuery _automacaoQuery;
        private readonly Guid _condominioId;

        public DispositivosWebhookService(Guid condominioId, IAutomacaoQuery automacaoQuery)
        {
            _condominioId = condominioId;
            _automacaoQuery = automacaoQuery;
        }


        public async Task<IEnumerable<DispositivoViewModel>> ObterDispositivos()
        {
            var dispositivos = await _automacaoQuery.ObterDispositivoWebhookPorCondominioId(_condominioId);
            
            var dispositivosViewModel = new List<DispositivoViewModel>();
            if (dispositivos.Count() > 0)
            {
                foreach (var dispositivo in dispositivos)
                {
                    var dispositivoViewModel = new DispositivoViewModel()
                    {
                        DispositivoId = dispositivo.Id.ToString(),
                        Nome = dispositivo.Nome,
                        TipoAutomacao = TipoApiAutomacao.WEBHOOK                        
                    };

                    dispositivoViewModel.State = "off";
                    if (dispositivo.Ligado)
                        dispositivoViewModel.State = "on";

                    dispositivosViewModel.Add(dispositivoViewModel);
                }             
            }
            return dispositivosViewModel;
        }
    

        public ValidationResult LigarDesligarDispositivo(string dispositivoId)
        {
            var dispositivo = _automacaoQuery.ObterDispositivoWebhookPorId(Guid.Parse(dispositivoId)).Result;

            string retorno;
            if (dispositivo.Ligado)
            {
                retorno = RestWebhook.Acao(dispositivo.UrlDesligar.Endereco).Result;
                return ValidationResult;
            }

            retorno = RestWebhook.Acao(dispositivo.UrlLigar.Endereco).Result;
            return ValidationResult;
        }

       
       
    }
}
