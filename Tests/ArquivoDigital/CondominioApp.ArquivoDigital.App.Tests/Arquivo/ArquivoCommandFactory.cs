using System;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoCommandFactory
    {
        private static CadastrarArquivoCommand CadastrarArquivoCommandFactoy()
        {
            return new CadastrarArquivoCommand
                ("nomeArquivo.txt","NomeOriginal.txt", 10, Guid.NewGuid(), true, Guid.NewGuid(),
                "Nome do Usuario", "Titulo do Arquivo", "Descricao do Arquivo", Guid.Empty);
        }

        private static EditarArquivoCommand EditarArquivoCommandFactoy()
        {
            return new EditarArquivoCommand
                 (Guid.NewGuid(), "Titulo do Arquivo", "Descricao do Arquivo", true,
                 "nomeArquivo.pdf", "nomeOriginal.pdf");
        }



        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo()
        {
            return CadastrarArquivoCommandFactoy();
        }
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_NomeArquivoSemExtensao()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("NomeArquivo", "NomeOriginal.txt");

            return commando;
        }
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_SemNomeArquivo()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("", "nomeOriginal.txt");

            return commando;
        }
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_SemTamanho()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetTamanho(0);

            return commando;
        }       
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_SemPastaId()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetPastaId(Guid.Empty);

            return commando;
        }


        public static EditarArquivoCommand CriarComando_EdicaoDeArquivo()
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