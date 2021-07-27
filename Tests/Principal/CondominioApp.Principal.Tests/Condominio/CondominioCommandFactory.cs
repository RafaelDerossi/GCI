using CondominioApp.Principal.Aplication.Commands;
using System;

namespace CondominioApp.Principal.Tests
{
    public class CondominioCommandFactory
    {
        private static AdicionarCondominioCommand CadastrarCondominioCommandFactory()
        {
            return new AdicionarCondominioCommand("26585345000148", "Condominio TU",
                            "Condominio Teste Unitario", "Foto.jpg", "21997967038",
                            "Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ",
                            false, false, false, false, false, false, false, false, false,
                            false, false, false, false, false, false, DateTime.Today.Date,
                            Core.Enumeradores.TipoDePlano.FREE, "Primeiro Contrato", true,
                            "contrato.pdf", 10);
        }
        private static AtualizarCondominioCommand EditarCondominioCommandFactory()
        {
            return new AtualizarCondominioCommand(Guid.NewGuid(), "26585345000148", "Condominio TU",
               "Condominio Teste Unitario", "21997967038", "Rua...", null, "1001", "23063260", "Bairro",
               "Cidade", "RJ");
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

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioComCNPJInvalido()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetCNPJ("26585345000150");

            return comando;                      
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemFoto()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetLogo(null);

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

            comando.SetTelefone("219979670");

            return comando;            
        }

        public static AdicionarCondominioCommand CriarComandoCadastroDeCondominioSemContrato()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetContrato(DateTime.Today.Date, 0, "", false, "", 10);

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
