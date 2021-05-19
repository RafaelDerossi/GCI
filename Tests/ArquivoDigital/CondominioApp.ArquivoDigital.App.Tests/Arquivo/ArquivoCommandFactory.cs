using System;
using System.IO;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoCommandFactory
    {        
        private static AdicionarArquivoCommand CadastrarArquivoCommandFactoy()
        {
            byte[] numbers = { 0, 16, 104, 213 };
            var memoryStream = new MemoryStream(numbers);           
            var arquivo = new FormFile(memoryStream, 0, memoryStream.Length, null, "anexoTeste.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            };            

            return new AdicionarArquivoCommand
            (Guid.NewGuid(), true, Guid.NewGuid(), "Nome do Usuario",
             "Titulo do Arquivo", "Descricao do Arquivo", Guid.Empty,
             arquivo);
        }

        private static AtualizarArquivoCommand EditarArquivoCommandFactoy()
        {
            return new AtualizarArquivoCommand
                 (Guid.NewGuid(), "Titulo do Arquivo", "Descricao do Arquivo", true,
                  "nomeOriginal.pdf");
        }



        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo()
        {
            return CadastrarArquivoCommandFactoy();
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_NomeOroginalDoArquivoSemExtensao()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("NomeOriginal");

            return commando;
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_SemArquivo()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetArquivo(null);

            return commando;
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_SemNomeArquivo()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("");

            return commando;
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_SemTamanho()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetTamanho(0);

            return commando;
        }       
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_SemPastaId()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetPastaId(Guid.Empty);

            return commando;
        }


        public static AtualizarArquivoCommand CriarComando_EdicaoDeArquivo()
        {
            return EditarArquivoCommandFactoy();
        }
        

        public static AlterarPastaDoArquivoCommand CriarComando_AlterarPastaDoArquivo()
        {
            return new AlterarPastaDoArquivoCommand(Guid.NewGuid(), Guid.NewGuid());
        }
        public static AlterarPastaDoArquivoCommand CriarComando_AlterarPastaDoArquivo_SemPastaId()
        {
            return new AlterarPastaDoArquivoCommand(Guid.NewGuid(), Guid.Empty);
        }


        public static MarcarArquivoComoPublicoCommand CriarComando_MarcarArquivoComoPublico()
        {
            return new MarcarArquivoComoPublicoCommand(Guid.NewGuid());
        }


        public static MarcarArquivoComoPrivadoCommand CriarComando_MarcarArquivoComoPrivado()
        {
            return new MarcarArquivoComoPrivadoCommand(Guid.NewGuid());
        }

    }
}