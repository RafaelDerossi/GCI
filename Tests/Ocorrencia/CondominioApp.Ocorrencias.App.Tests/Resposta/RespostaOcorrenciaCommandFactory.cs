using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class RespostaOcorrenciaCommandFactory
    {
        private static AdicionarRespostaOcorrenciaSindicoCommand CadastrarRespostaOcorrenciaSindicoCommandFactory()
        {
            return new AdicionarRespostaOcorrenciaSindicoCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(), "Nome do Usuario", "fotonome.jpg",
                StatusDaOcorrencia.EM_ANDAMENTO);
        }
        
        private static AdicionarRespostaOcorrenciaMoradorCommand CadastrarRespostaOcorrenciaMoradorCommandFactory()
        {
            return new AdicionarRespostaOcorrenciaMoradorCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(), "Nome do Usuario", "fotoNome.jpg");
        }

        private static AtualizarRespostaOcorrenciaCommand EditarRespostaOcorrenciaCommandFactory()
        {
            return new AtualizarRespostaOcorrenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "Nova Descricao", "fotonome.jpg");
        }



        public static AdicionarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico()
        {
            return CadastrarRespostaOcorrenciaSindicoCommandFactory();
        }

        public static AdicionarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemDescricao()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetDescricao("");

            return comando;
        }

        public static AdicionarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemUsuario()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }

        public static AdicionarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemFoto()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetFoto("");

            return comando;
        }

        public static AdicionarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_Resolvido()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetStatus(StatusDaOcorrencia.RESOLVIDA);

            return comando;
        }


        public static AdicionarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador()
        {
            return CadastrarRespostaOcorrenciaMoradorCommandFactory();
        }

        public static AdicionarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemDescricao()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetDescricao("");

            return comando;
        }

        public static AdicionarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemUsuario()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }

        public static AdicionarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemFoto()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetFoto("");

            return comando;
        }



        public static AtualizarRespostaOcorrenciaCommand CriarComando_EdicaoDeRespostaOcorrencia()
        {
            return EditarRespostaOcorrenciaCommandFactory();
        }
    }
}