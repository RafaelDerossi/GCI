using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandFactory
    {
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
    }
}
