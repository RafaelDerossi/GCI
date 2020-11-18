using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

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
            try
            {
                return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0, 
                    null, null, null, false, false, false, false, false, false, false, false, 
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemNome()
        {
            try
            {
                return new CadastrarCondominioCommand("26585345000148", "",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemCNPJ()
        {
            try
            {
                return new CadastrarCondominioCommand("", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComCNPJInvalido()
        {
            try
            {
                return new CadastrarCondominioCommand("26585345000150", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemFoto()
        {
            try
            {
                return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                    "Condominio Teste Unitario",null, null, "(21) 99796-7038", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioSemTelefone()
        {
            try
            {
                return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", null, 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarCondominioCommand CriarComandoCadastroDeCondominioComTelefoneInvalido()
        {
            try
            {
                return new CadastrarCondominioCommand("26585345000148", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "2199796703", 0,
                    null, null, null, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

       /// <summary>
       /// AlterarCommand
       /// </summary>
       /// <returns></returns>
        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominio()
        {
            try
            {
                return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000148", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioSemCNPJ()
        {
            try
            {
                return new AlterarCondominioCommand(Guid.NewGuid(), null, "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioComCNPJInvalido()
        {
            try
            {
                return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000150", "Condominio TU",
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AlterarCondominioCommand CriarComandoAlteracaoDeCondominioSemNome()
        {
            try
            {
                return new AlterarCondominioCommand(Guid.NewGuid(), "26585345000148", null,
                    "Condominio Teste Unitario", "Foto.jpg", "Foto.jpg", "(21) 99796-7038");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// AlterarConfiguracaoCommand
        /// </summary>
        /// <returns></returns>
        public static AlterarConfiguracaoCondominioCommand CriarComandoAlteracaoDeConfiguracaoDoCondominio()
        {
            try
            {
                return new AlterarConfiguracaoCondominioCommand(Guid.NewGuid(), true, false, true,
                    false,false, false, false, false, false, false, false, false, false, false, false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
