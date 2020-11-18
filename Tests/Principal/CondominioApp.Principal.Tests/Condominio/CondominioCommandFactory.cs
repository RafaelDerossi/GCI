using CondominioApp.Principal.Aplication.Commands;
using System;

namespace CondominioApp.Principal.Tests
{
    public class CondominioCommandFactory
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        /// <returns></returns>
        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominio()
        {

            return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemNome()
        {

            return new CadastrarCondominioCommand("26585345000148", "",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemCNPJ()
        {

            return new CadastrarCondominioCommand("", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComCNPJInvalido()
        {
            return new CadastrarCondominioCommand("26585345000150", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemFoto()
        {

            return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                "Condominio Teste Unitario", null, null, "(21) 99796-7038", 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemTelefone()
        {

            return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", null, 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComTelefoneInvalido()
        {

            return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "2199796703", 0,
                null, null, null, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false);

        }

        /// <summary>
        /// AlterarCommand
        /// </summary>
        /// <returns></returns>
        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominio()
        {

            return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000148", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");

        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioSemCNPJ()
        {

            return new AlterarCondominioCommand(Guid.NewGuid(), null, "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");

        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioComCNPJInvalido()
        {

            return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000150", "Condominio TU",
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");

        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioSemNome()
        {

            return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000148", null,
                "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");

        }

        /// <summary>
        /// AlterarConfiguracaoCommand
        /// </summary>
        /// <returns></returns>
        public static AlterarConfiguracaoCondominioCommand CriarComandoAlteracaoDeConfiguracaoDoCondominio()
        {

            return new AlterarConfiguracaoCondominioCommand(Guid.NewGuid(), true, false, true,
                false, false, false, false, false, false, false, false, false, false, false, false);

        }
    }
}
