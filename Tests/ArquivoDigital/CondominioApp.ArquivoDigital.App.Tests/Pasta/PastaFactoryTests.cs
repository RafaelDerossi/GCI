using CondominioApp.ArquivoDigital.App.Models;
using System;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaFactoryTests
    {        
        public static Pasta Criar_Pasta_raiz_Valida()
        {            
            return new Pasta("Titulo", "Descricao",  Guid.NewGuid(), true, false, 0, true, Guid.Empty);    
        }

        public static Pasta Criar_SubPasta_Valida()
        {
            return new Pasta("Titulo", "Descricao", Guid.NewGuid(), true, false, 0, false, Guid.NewGuid());
        }

    }
}