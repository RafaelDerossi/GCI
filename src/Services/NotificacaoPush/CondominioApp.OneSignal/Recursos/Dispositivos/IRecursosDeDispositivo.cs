
namespace CondominioApp.OneSignal.Recursos.Dispositivos
{
   public interface IRecursosDeDispositivo
    {
        RetornoDoAdicionarDispositivo Adicionar(OpcoesDoAdicionarDispositvo opcoes);

        void Editar(string id, OpcoesDoEditarDispositivo opcoes);
    }
}
