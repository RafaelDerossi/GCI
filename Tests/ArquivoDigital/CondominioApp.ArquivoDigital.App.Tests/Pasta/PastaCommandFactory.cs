using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaCommandFactory
    {
        private static AdicionarPastaRaizCommand CadastrarPastaRaizCommandFactory()
        {
            return new AdicionarPastaRaizCommand
                ("Titulo", "Descricao", Guid.NewGuid(), true);
        }
        private static AdicionarSubPastaCommand CadastrarSubPastaCommandFactory()
        {
            return new AdicionarSubPastaCommand
                ("Titulo", "Descricao", true, Guid.NewGuid());
        }
        private static AdicionarPastaDeSistemaCommand CadastrarPastaDeSistemaCommandFactory()
        {
            return new AdicionarPastaDeSistemaCommand
                ("Titulo", "Descricao", Guid.NewGuid(), CategoriaDaPastaDeSistema.COMUNICADO);
        }


        private static AtualizarPastaCommand EditarPastaCommandFactory()
        {
            return new AtualizarPastaCommand
                 (Guid.NewGuid(), "Titulo", "Descricao", true);
        }

        private static MoverPastaParaRaizCommand MoverPastaParaRaizCommandFactory()
        {
            return new MoverPastaParaRaizCommand
                 (Guid.NewGuid());
        }

        private static MoverSubPastaCommand MoverSubPastaCommandFactory()
        {
            return new MoverSubPastaCommand
                 (Guid.NewGuid(), Guid.NewGuid());
        }



        public static AdicionarPastaRaizCommand CriarComando_CadastroDePastaRaiz()
        {
            return CadastrarPastaRaizCommandFactory();
        }
        public static AdicionarPastaRaizCommand CriarComando_CadastroDePastaRaiz_SemTitulo()
        {
            var comando = CadastrarPastaRaizCommandFactory();
            comando.SetTitulo("");
            return comando;
        }
        public static AdicionarPastaRaizCommand CriarComando_CadastroDePastaRaiz_SemCondominioId()
        {
            var comando = CadastrarPastaRaizCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }


        public static AdicionarSubPastaCommand CriarComando_CadastroDeSubPasta()
        {
            return CadastrarSubPastaCommandFactory();
        }
        public static AdicionarSubPastaCommand CriarComando_CadastroDeSubPasta_SemTitulo()
        {
            var comando = CadastrarSubPastaCommandFactory();
            comando.SetTitulo("");
            return comando;
        }
        public static AdicionarSubPastaCommand CriarComando_CadastroDeSubPasta_SemPastaMaeId()
        {
            var comando = CadastrarSubPastaCommandFactory();
            comando.SetPastaMaeId(null);
            return comando;
        }


        public static AdicionarPastaDeSistemaCommand CriarComando_CadastroDePastaDeSistema()
        {
            return CadastrarPastaDeSistemaCommandFactory();
        }
        public static AdicionarPastaDeSistemaCommand CriarComando_CadastroDePastaDeSistema_SemTitulo()
        {
            var comando = CadastrarPastaDeSistemaCommandFactory();
            comando.SetTitulo("");
            return comando;
        }
        public static AdicionarPastaDeSistemaCommand CriarComando_CadastroDePastaDeSistema_SemCondominioId()
        {
            var comando = CadastrarPastaDeSistemaCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }



        public static AtualizarPastaCommand CriarComando_EdicaoDePasta()
        {
            return EditarPastaCommandFactory();
        }
        public static AtualizarPastaCommand CriarComando_EdicaoDePasta_SemTitulo()
        {
            var comando = EditarPastaCommandFactory();
            comando.SetTitulo("");
            return comando;
        }
        public static MoverPastaParaRaizCommand CriarComando_MoverPastaParaRaiz()
        {
            return MoverPastaParaRaizCommandFactory();
        }
        public static MoverSubPastaCommand CriarComando_MoverParaSubPasta()
        {
            return MoverSubPastaCommandFactory();
        }


        public static MarcarPastaComoPublicaCommand CriarComandoMarcarPastaComoPublica()
        {
            return new MarcarPastaComoPublicaCommand(Guid.NewGuid());
        }
        public static MarcarPastaComoPrivadaCommand CriarComandoMarcarPastaComoPrivada()
        {
            return new MarcarPastaComoPrivadaCommand(Guid.NewGuid());
        }

    }
}