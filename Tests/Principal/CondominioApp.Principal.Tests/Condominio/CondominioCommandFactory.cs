using CondominioApp.Principal.Aplication.Commands;
using System;

namespace CondominioApp.Principal.Tests
{
    public class CondominioCommandFactory
    {
        private static AdicionarCondominioCommand CadastrarCondominioCommandFactory()
        {
            return new AdicionarCondominioCommand("26585345000148", "Condominio TU",
                            "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038",
                            "Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ",
                            0, null, null, null, false, false, false, false, false, false, false, false,
                            false, false, false, false, false, false, false, DateTime.Today.Date,
                            Core.Enumeradores.TipoDePlano.BASIC, "Primeiro Contrato", true, "link");
        }
        private static AtualizarCondominioCommand EditarCondominioCommandFactory()
        {
            return new AtualizarCondominioCommand(Guid.NewGuid(), "26585345000148", "Condominio TU",
               "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038",
               "Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ");
        }


        /// <summary>
        /// CadastrarCommand
        /// </summary>
        /// <returns></returns>
        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominio()
        {

           return CadastrarCondominioCommandFactory();

        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemNome()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetNome("");

            return comando;
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemCNPJ()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetCNPJ("");

            return comando;         

        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioComCNPJInvalido()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetCNPJ("26585345000150");

            return comando;                      
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemFoto()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetFoto(null,null);

            return comando;
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemTelefone()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetTelefone(null);

            return comando;           
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioComTelefoneInvalido()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetTelefone("2199796703");

            return comando;            
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemContrato()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetContrato(DateTime.Today.Date, 0, "", false, "");

            return comando;
        }

        /// <summary>
        /// EditarCommand
        /// </summary>
        /// <returns></returns>
        public static AtualizarCondominioCommand CriarComandoEdicaoDeCondominio()
        {
            return EditarCondominioCommandFactory();
        }

        public static AtualizarCondominioCommand CriarComandoEdicaoDeCondominioSemCNPJ()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetCNPJ(null);

            return comando;
        }

        public static AtualizarCondominioCommand CriarComandoEdicaoDeCondominioComCNPJInvalido()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetCNPJ("26585345000150");

            return comando;
        }

        public static AtualizarCondominioCommand CriarComandoEdicaoDeCondominioSemNome()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetNome(null);

            return comando;
        }

        /// <summary>
        /// EditarConfiguracaoCommand
        /// </summary>
        /// <returns></returns>
        public static AtualizarConfiguracaoCondominioCommand CriarComandoEdicaoDeConfiguracaoDoCondominio()
        {

            return new AtualizarConfiguracaoCondominioCommand(Guid.NewGuid(), true, false, true,
                false, false, false, false, false, false, false, false, false, false, false, false);

        }
    }
}
