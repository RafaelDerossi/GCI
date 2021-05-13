using System;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoCommandFactory
    {
        private static AdicionarArquivoCommand CadastrarArquivoCommandFactoy()
        {
            return new AdicionarArquivoCommand
                ("nomeArquivo.txt","NomeOriginal.txt", 10, Guid.NewGuid(), true, Guid.NewGuid(),
                "Nome do Usuario", "Titulo do Arquivo", "Descricao do Arquivo", Guid.Empty);
        }

        private static AtualizarArquivoCommand EditarArquivoCommandFactoy()
        {
            return new AtualizarArquivoCommand
                 (Guid.NewGuid(), "Titulo do Arquivo", "Descricao do Arquivo", true,
                 "nomeArquivo.pdf", "nomeOriginal.pdf");
        }



        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo()
        {
            return CadastrarArquivoCommandFactoy();
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_NomeArquivoSemExtensao()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("NomeArquivo", "NomeOriginal.txt");

            return commando;
        }
        public static AdicionarArquivoCommand CriarComando_CadastroDeArquivo_SemNomeArquivo()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("", "nomeOriginal.txt");

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