using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaCommandFactory
    {
        private static CadastrarPastaCommand CadastrarPastaCommandFactoy()
        {
            return new CadastrarPastaCommand
                (Guid.NewGuid(), "Titulo", "Descricao", Guid.NewGuid(), true);
        }

        private static EditarPastaCommand EditarPastaCommandFactoy()
        {
            return new EditarPastaCommand
                 (Guid.NewGuid(), "Titulo", "Descricao", true);
        }



        public static CadastrarPastaCommand CriarComando_CadastroDePasta()
        {
            return CadastrarPastaCommandFactoy();
        }

        public static CadastrarPastaCommand CriarComando_CadastroDePasta_SemTitulo()
        {
            var comando = CadastrarPastaCommandFactoy();
            comando.SetTitulo("");
            return comando;
        }

        public static CadastrarPastaCommand CriarComando_CadastroDePasta_SemCondominioId()
        {
            var comando = CadastrarPastaCommandFactoy();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }



        public static EditarPastaCommand CriarComando_EdicaoDePasta()
        {
            return EditarPastaCommandFactoy();
        }

        public static EditarPastaCommand CriarComando_EdicaoDePasta_SemTitulo()
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