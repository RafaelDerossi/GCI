using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class OcorrenciaCommandFactory
    {
        private static CadastrarOcorrenciaCommand CadastrarOcorrenciaCommandFactory()
        {
            return new CadastrarOcorrenciaCommand(
               "Descricao da Ocorrencia", "fotonome.jpg", "fotoNome.jpg", false, Guid.NewGuid(),
               "101", "1", "Grupo", Guid.NewGuid(), "Nome Usuario", Guid.NewGuid(), "Nome do Condominio",
               false);
        }
        private static EditarOcorrenciaCommand EditarOcorrenciaCommandFactory()
        {
            return new EditarOcorrenciaCommand(
               Guid.NewGuid(), "Descricao da Ocorrencia", "fotonome.jpg", "fotoNome.jpg", false);
        }


        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_Privada()
        {
            return CadastrarOcorrenciaCommandFactory();
        }
        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_Publica()
        {            
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.MarcarComoPublica();         
            return comando;
        }
        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemDescricao()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetDescricao("");
            return comando;
        }
        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemFoto()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetFoto("", "");
            return comando;
        }
        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemUnidade()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }
        public static CadastrarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemUsuario()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetUsuarioId(Guid.Empty);
            return comando;
        }



        public static EditarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_Privada()
        {
            var comando = EditarOcorrenciaCommandFactory();
            
            return comando;
        }

        public static EditarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_SemDescricao()
        {            
            var comando = EditarOcorrenciaCommandFactory();

            comando.SetDescricao("");
         
            return comando;
        }

        public static EditarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_SemFoto()
        {
            var comando = EditarOcorrenciaCommandFactory();

            comando.SetFoto("","");

            return comando;
        }

    }
}