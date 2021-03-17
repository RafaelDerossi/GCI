using CondominioApp.ArquivoDigital.App.Models;
using System;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaFactoryTests
    {        
        public static Pasta Criar_Pasta_Valida()
        {            
            return new Pasta("Titulo", "Descricao",  Guid.NewGuid(), true);    
        }

    }
}