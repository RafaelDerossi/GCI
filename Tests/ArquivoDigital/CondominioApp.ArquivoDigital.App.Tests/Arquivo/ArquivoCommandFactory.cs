using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoCommandFactory
    {
        private static CadastrarArquivoCommand CadastrarArquivoCommandFactoy()
        {
            return new CadastrarArquivoCommand
                ("NomeOriginal.txt", 10, Guid.NewGuid(), true, Guid.NewGuid(), "Nome do Usuario", "Titulo do Arquivo", "Descricao do Arquivo");
        }

        private static EditarArquivoCommand EditarArquivoCommandFactoy()
        {
            return new EditarArquivoCommand
                 (Guid.NewGuid(), "Titulo do Arquivo", "Descricao do Arquivo", true);
        }



        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo()
        {
            return CadastrarArquivoCommandFactoy();
        }
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_NomeOriginalSemExtensao()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("NomeOriginal");

            return commando;
        }
        public static CadastrarArquivoCommand CriarComando_CadastroDeArquivo_SemNomeOriginal()
        {
            var commando = CadastrarArquivoCommandFactoy();

            commando.SetNome("");

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