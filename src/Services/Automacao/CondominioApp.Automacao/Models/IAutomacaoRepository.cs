using CondominioApp.Automacao.Models;
using CondominioApp.Core.Data;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Models
{
    public interface IAutomacaoRepository : IRepository<CondominioCredencial>
    {
        Task<bool> VerificaSeJaEstaCadastrado(Guid condominioId, TipoApiAutomacao tipoApiAutomacao);


        #region DispositivoWebhook
        Task<DispositivoWebhook> ObterDispositivoWebhookPorId(Guid Id);

        Task<IEnumerable<DispositivoWebhook>> ObterDispositivoWebhookPorCondominioId(Guid condominioId);

        Task<bool> VerificaDispositivoWebhookJaEstaCadastrado(Guid condominioId, string nome);

        void AdicionarDispositivoWebhook(DispositivoWebhook entity);

        void AtualizarDispositivoWebhook(DispositivoWebhook entity);

        void ApagarDispositivoWebhook(Func<DispositivoWebhook, bool> predicate);

        #endregion
    }
}