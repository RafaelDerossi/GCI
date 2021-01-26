using CondominioApp.Principal.Aplication.Commands;
using System;

namespace CondominioApp.Principal.Tests
{
    public class CondominioCommandFactory
    {
        private static CadastrarCondominioCommand CadastrarCondominioCommandFactory()
        {
            return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                            "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038",
                            "Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ",
                            0, null, null, null, false, false, false, false, false, false, false, false,
                            false, false, false, false, false, false, false, DateTime.Today.Date,
                            Core.Enumeradores.TipoDePlano.BASIC, "Primeiro Contrato", true, "link");
        }
        private static EditarCondominioCommand EditarCondominioCommandFactory()
        {
            return new EditarCondominioCommand(Guid.NewGuid(), "26585345000148", "Condominio TU",
               "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038",
               "Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ");
        }


        /// <summary>
        /// CadastrarCommand
        /// </summary>
        /// <returns></returns>
        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominio()
        {

           return CadastrarCondominioCommandFactory();

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemNome()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetNome("");

            return comando;
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemCNPJ()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetCNPJ("");

            return comando;         

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComCNPJInvalido()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetCNPJ("26585345000150");

            return comando;                      
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemFoto()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetFoto(null,null);

            return comando;
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemTelefone()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetTelefone(null);

            return comando;           
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComTelefoneInvalido()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetTelefone("2199796703");

            return comando;            
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemContrato()
        {
            var comando = CadastrarCondominioCommandFactory();

            comando.SetContrato(DateTime.Today.Date, 0, "", false, "");

            return comando;
        }

        /// <summary>
        /// EditarCommand
        /// </summary>
        /// <returns></returns>
        public static EditarCondominioCommand CriarComandoEdicaoDeCondominio()
        {
            return EditarCondominioCommandFactory();
        }

        public static EditarCondominioCommand CriarComandoEdicaoDeCondominioSemCNPJ()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetCNPJ(null);

            return comando;
        }

        public static EditarCondominioCommand CriarComandoEdicaoDeCondominioComCNPJInvalido()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetCNPJ("26585345000150");

            return comando;
        }

        public static EditarCondominioCommand CriarComandoEdicaoDeCondominioSemNome()
        {
            var comando = EditarCondominioCommandFactory();

            comando.SetNome(null);

            return comando;
        }

        /// <summary>
        /// EditarConfiguracaoCommand
        /// </summary>
        /// <returns></returns>
        public static EditarConfiguracaoCondominioCommand CriarComandoEdicaoDeConfiguracaoDoCondominio()
        {

            return new EditarConfiguracaoCondominioCommand(Guid.NewGuid(), true, false, true,
                false, false, false, false, false, false, false, false, false, false, false, false);

        }
    }
}
