using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandFactory
    {

        /// CadastroCommand
        public static AdicionarUnidadeCommand CriarComandoCadastroDeUnidade()
        {
            return new AdicionarUnidadeCommand(null, "101", "1", 2,
                  "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());            
        }

        public static AdicionarUnidadeCommand CriarComandoCadastroDeUnidadeSemNumero()
        {
            return new AdicionarUnidadeCommand(null, null, "1", 2,
                   "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());
        }           

        public static AdicionarUnidadeCommand CriarComandoCadastroDeUnidadeSemAndar()
        {
            return new AdicionarUnidadeCommand(null, "101", null, 2,
                    "(21) 96404-9371", "100", "complemento teste", Guid.NewGuid());           
        }

        public static AdicionarUnidadeCommand CriarComandoCadastroDeUnidadeSemGrupo()
        {
            return new AdicionarUnidadeCommand(null, "101", "1", 2,
                   "(21) 96404-9371", "100", "complemento teste", Guid.Empty);            
        }

        public static AdicionarUnidadeCommand CriarComandoCadastroDeUnidadeSemTelefone()
        {
            return new AdicionarUnidadeCommand(null, "101", "1", 2,
                  "", "100", "complemento teste", Guid.NewGuid());
        }


        /// EditarCommand        
        public static AtualizarUnidadeCommand CriarComandoEdicaoDeUnidade()
        {
            return new AtualizarUnidadeCommand(Guid.NewGuid(), "101", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");            
        }

        public static AtualizarUnidadeCommand CriarComandoEdicaoDeUnidadeSemNumero()
        {
            return new AtualizarUnidadeCommand(Guid.NewGuid(), "", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        public static AtualizarUnidadeCommand CriarComandoEdicaoDeUnidadeSemAndar()
        {
            return new AtualizarUnidadeCommand(Guid.NewGuid(), "101", "", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        public static AtualizarUnidadeCommand CriarComandoEdicaoDeUnidadeSemTelefone()
        {
            return new AtualizarUnidadeCommand(Guid.NewGuid(), "101", "1", 2, "(21) 96404-9371",
                   "100", "complemento teste");
        }

        ///ResetarCodigoCommand
        public static ResetCodigoUnidadeCommand CriarComandoResetarCodigoDaUnidade()
        {
            return new ResetCodigoUnidadeCommand(Guid.NewGuid());
        }
    }
}
