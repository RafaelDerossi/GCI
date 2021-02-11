

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public interface IRecursosDeNotificacao
    {        
        RetornoDoCriarNotificacao Criar(OpcoesDoCriarNotificacao opcoes);


        RetornoDoCancelarNotificacao Cancelar(OpcoesDoCancelarNotificacao opcoes);

       
        RetornoDoVerNotificacao Ver(OpcoesDoVerNotificacao opcoes);
    }
}
