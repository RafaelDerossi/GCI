using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.ArquivoDigital.App.ValueObjects;
using System;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoFactoryTests
    {        
        public static Arquivo Criar_Arquivo_Valido()
        {   
            var id = Guid.NewGuid();
            var nome = new NomeArquivo("nomeOriginal.pdf", id);
            var arquivo = new Arquivo(nome, 10, Guid.NewGuid(), Guid.NewGuid());
            arquivo.SetEntidadeId(id);
            return arquivo;
        }

    }
}