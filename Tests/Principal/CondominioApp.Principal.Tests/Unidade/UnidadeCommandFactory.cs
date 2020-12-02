using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandFactory
    {

        /// CadastroCommand
        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidade()
        {
            return new CadastrarUnidadeCommand(null, "101", "1", 2,
                  "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());            
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemNumero()
        {
            return new CadastrarUnidadeCommand(null, null, "1", 2,
                   "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());
        }           

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemAndar()
        {
            return new CadastrarUnidadeCommand(null, "101", null, 2,
                    "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());           
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemGrupo()
        {
            return new CadastrarUnidadeCommand(null, "101", "1", 2,
                   "(21) 96404-9371", "100", "complemento teste", Guid.Empty);            
        }

        public static CadastrarUnidadeCommand CriarComandoCadastroDeUnidadeSemTelefone()
        {
            return new CadastrarUnidadeCommand(null, "101", "1", 2,
                  "", "100", "complemento teste", Guid.NewGuid());
        }


        /// EditarCommand        
        public static EditarUnidadeCommand CriarComandoEdicaoDeUnidade()
        {
            return new EditarUnidadeCommand(Guid.NewGuid(), "101", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");            
        }

        public static EditarUnidadeCommand CriarComandoEdicaoDeUnidadeSemNumero()
        {
            return new EditarUnidadeCommand(Guid.NewGuid(), "", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        public static EditarUnidadeCommand CriarComandoEdicaoDeUnidadeSemAndar()
        {
            return new EditarUnidadeCommand(Guid.NewGuid(), "101", "", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        public static EditarUnidadeCommand CriarComandoEdicaoDeUnidadeSemTelefone()
        {
            return new EditarUnidadeCommand(Guid.NewGuid(), "101", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        ///ResetarCodigoCommand
        public static ResetCodigoUnidadeCommand CriarComandoResetarCodigoDaUnidade()
        {
            return new ResetCodigoUnidadeCommand(Guid.NewGuid());
        }
    }
}
