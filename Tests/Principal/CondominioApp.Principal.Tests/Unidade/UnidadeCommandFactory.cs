using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandFactory
    {
        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidade()
        {
            try
            {
                return new CadastrarUnidadeCommand(null,"101","1",2, 
                   "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemNumero()
        {
            try
            {
                return new CadastrarUnidadeCommand(null, null, "1", 2,
                    "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemAndar()
        {
            try
            {
                return new CadastrarUnidadeCommand(null, "101", null, 2,
                    "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemGrupo()
        {
            try
            {
                return new CadastrarUnidadeCommand(null, "101", "1", 2,
                    "(21) 96404-9371", "100", "complemento teste", Guid.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
