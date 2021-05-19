using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class OcorrenciaCommandFactory
    {
        private static AdicionarOcorrenciaCommand CadastrarOcorrenciaCommandFactory()
        {
            return new AdicionarOcorrenciaCommand(
               "Descricao da Ocorrencia", "fotonome.jpg", false, Guid.NewGuid(),
               "101", "1", "Grupo", Guid.NewGuid(), "Nome Usuario", Guid.NewGuid(), "Nome do Condominio",
               false);
        }
        private static AtualizarOcorrenciaCommand EditarOcorrenciaCommandFactory()
        {
            return new AtualizarOcorrenciaCommand(
               Guid.NewGuid(), "Descricao da Ocorrencia", "fotonome.jpg", false);
        }


        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_Privada()
        {
            return CadastrarOcorrenciaCommandFactory();
        }
        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_Publica()
        {            
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.MarcarComoPublica();         
            return comando;
        }
        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemDescricao()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetDescricao("");
            return comando;
        }
        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemFoto()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetFoto("");
            return comando;
        }
        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemUnidade()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }
        public static AdicionarOcorrenciaCommand CriarComando_CadastroDeOcorrencia_SemUsuario()
        {
            var comando = CadastrarOcorrenciaCommandFactory();
            comando.SetMoradorId(Guid.Empty);
            return comando;
        }



        public static AtualizarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_Privada()
        {
            var comando = EditarOcorrenciaCommandFactory();
            
            return comando;
        }

        public static AtualizarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_SemDescricao()
        {            
            var comando = EditarOcorrenciaCommandFactory();

            comando.SetDescricao("");
         
            return comando;
        }

        public static AtualizarOcorrenciaCommand CriarComando_EdicaoDeOcorrencia_SemFoto()
        {
            var comando = EditarOcorrenciaCommandFactory();

            comando.SetFoto("");

            return comando;
        }

    }
}