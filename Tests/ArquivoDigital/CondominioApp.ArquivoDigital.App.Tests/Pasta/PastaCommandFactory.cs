using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaCommandFactory
    {
        private static AdicionarPastaRaizCommand CadastrarPastaCommandFactoy()
        {
            return new AdicionarPastaRaizCommand
                ("Titulo", "Descricao", Guid.NewGuid(), true);
        }

        private static AtualizarPastaCommand EditarPastaCommandFactoy()
        {
            return new AtualizarPastaCommand
                 (Guid.NewGuid(), "Titulo", "Descricao", true);
        }



        public static AdicionarPastaRaizCommand CriarComando_CadastroDePasta()
        {
            return CadastrarPastaCommandFactoy();
        }

        public static AdicionarPastaRaizCommand CriarComando_CadastroDePasta_SemTitulo()
        {
            var comando = CadastrarPastaCommandFactoy();
            comando.SetTitulo("");
            return comando;
        }

        public static AdicionarPastaRaizCommand CriarComando_CadastroDePasta_SemCondominioId()
        {
            var comando = CadastrarPastaCommandFactoy();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }



        public static AtualizarPastaCommand CriarComando_EdicaoDePasta()
        {
            return EditarPastaCommandFactoy();
        }

        public static AtualizarPastaCommand CriarComando_EdicaoDePasta_SemTitulo()
        {
            var comando = EditarPastaCommandFactoy();
            comando.SetTitulo("");
            return comando;
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