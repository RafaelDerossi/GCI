using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Automacao.App.Services.Interfaces
{
   public interface IServiceBase
    {
        bool EstaValido();

        void AdicionarErrosDeProcessamento(string mensagemDeErro);
        
    }
}
