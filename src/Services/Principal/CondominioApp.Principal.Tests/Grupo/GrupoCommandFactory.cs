using CondominioApp.Principal.Aplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Tests
{
   public class GrupoCommandFactory
    {

        /// <summary>
        /// CadastrarGrupoCommand
        /// </summary>
        /// <returns></returns>
        public static CadastrarGrupoCommand CriarComandoCadastroDeGrupo()
        {
            try
            {
                return new CadastrarGrupoCommand("Bloco 1", Guid.Parse("8a1daec5-ead4-4baa-9fb2-81c8c2d46841"));
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public static CadastrarGrupoCommand CriarComandoCadastroDeGrupoSemDescricao()
        {
            try
            {
                return new CadastrarGrupoCommand("", Guid.NewGuid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarGrupoCommand CriarComandoCadastroDeGrupoSemCondominio()
        {
            try
            {
                return new CadastrarGrupoCommand("Bloco 1", Guid.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// AlterarGrupoCommand
        /// </summary>
        /// <returns></returns>
        public static AlterarGrupoCommand CriarComandoAlteracaoDeGrupo()
        {
            try
            {
                return new AlterarGrupoCommand(Guid.NewGuid(), "Bloco 1");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AlterarGrupoCommand CriarComandoAlteracaoDeGrupoSemDescricao()
        {
            try
            {
                return new AlterarGrupoCommand(Guid.NewGuid(), null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AlterarGrupoCommand CriarComandoAlteracaoDeGrupoSemCondominio()
        {
            try
            {
                return new AlterarGrupoCommand(Guid.Empty, "Bloco 1");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
