using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class RespostaOcorrenciaCommandFactory
    {
        private static CadastrarRespostaOcorrenciaSindicoCommand CadastrarRespostaOcorrenciaSindicoCommandFactory()
        {
            return new CadastrarRespostaOcorrenciaSindicoCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(), "Nome do Usuario", "fotonome.jpg",
                "fotoNome.jpg", StatusDaOcorrencia.EM_ANDAMENTO);
        }
        
        private static CadastrarRespostaOcorrenciaMoradorCommand CadastrarRespostaOcorrenciaMoradorCommandFactory()
        {
            return new CadastrarRespostaOcorrenciaMoradorCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(), "Nome do Usuario", "fotonome.jpg",
                "fotoNome.jpg");
        }       



        public static CadastrarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico()
        {
            return CadastrarRespostaOcorrenciaSindicoCommandFactory();
        }

        public static CadastrarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemDescricao()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetDescricao("");

            return comando;
        }

        public static CadastrarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemUsuario()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }

        public static CadastrarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemFoto()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetFoto("", "");

            return comando;
        }

        public static CadastrarRespostaOcorrenciaSindicoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_Resolvido()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetStatus(StatusDaOcorrencia.RESOLVIDA);

            return comando;
        }


        public static CadastrarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador()
        {
            return CadastrarRespostaOcorrenciaMoradorCommandFactory();
        }

        public static CadastrarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemDescricao()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetDescricao("");

            return comando;
        }

        public static CadastrarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemUsuario()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }

        public static CadastrarRespostaOcorrenciaMoradorCommand CriarComando_CadastroDeRespostaOcorrenciaMorador_SemFoto()
        {
            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory();

            comando.SetFoto("", "");

            return comando;
        }

    }
}