using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.ArquivoDigital.App.ValueObjects;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoFactoryTests
    {        
        public static Arquivo Criar_Arquivo_Valido()
        {   
            var id = Guid.NewGuid();
            var nome = new NomeArquivo("nomeOriginal.pdf", id);
            var arquivo = new Arquivo
                (nome, 10, Guid.NewGuid(), Guid.NewGuid(), true, Guid.NewGuid(), "Nome Usuario", 
                 "Titulo do Arquivo", "Descricao do Arquivo", Guid.Empty, new Url("https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/4943ee5b-214c-4138-b186-a1302ba3394e.pdf"));
            arquivo.SetEntidadeId(id);
            return arquivo;
        }

    }
}