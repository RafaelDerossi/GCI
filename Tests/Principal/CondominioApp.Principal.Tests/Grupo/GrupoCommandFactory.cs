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
        public static AdicionarGrupoCommand CriarComandoCadastroDeGrupo()
        {
            try
            {
                return new AdicionarGrupoCommand("Bloco 1", Guid.Parse("8a1daec5-ead4-4baa-9fb2-81c8c2d46841"));
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public static AdicionarGrupoCommand CriarComandoCadastroDeGrupoSemDescricao()
        {
            try
            {
                return new AdicionarGrupoCommand("", Guid.NewGuid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AdicionarGrupoCommand CriarComandoCadastroDeGrupoSemCondominio()
        {
            try
            {
                return new AdicionarGrupoCommand("Bloco 1", Guid.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// EditarGrupoCommand
        /// </summary>
        /// <returns></returns>
        public static AtualizarGrupoCommand CriarComandoEdicaoDeGrupo()
        {
            try
            {
                return new AtualizarGrupoCommand(Guid.NewGuid(), "Bloco 1");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AtualizarGrupoCommand CriarComandoEdicaoDeGrupoSemDescricao()
        {
            try
            {
                return new AtualizarGrupoCommand(Guid.NewGuid(), null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AtualizarGrupoCommand CriarComandoEdicaoDeGrupoSemCondominio()
        {
            try
            {
                return new AtualizarGrupoCommand(Guid.Empty, "Bloco 1");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
