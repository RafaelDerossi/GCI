
namespace CondominioApp.Core.Service
{
   public interface IServiceBase
    {
        bool EstaValido();

        void AdicionarErrosDeProcessamento(string mensagemDeErro);
        
    }
}
