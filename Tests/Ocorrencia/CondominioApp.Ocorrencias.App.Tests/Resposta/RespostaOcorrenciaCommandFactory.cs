using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using System;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class RespostaOcorrenciaCommandFactory
    {
        private static AdicionarRespostaOcorrenciaAdministracaoCommand CadastrarRespostaOcorrenciaSindicoCommandFactory()
        {
            return new AdicionarRespostaOcorrenciaAdministracaoCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(), "Nome do Funcionario",
                "fotonome.jpg", StatusDaOcorrencia.EM_ANDAMENTO, "nomeOriginalArquivoAnexo.jpg");
        }
        
        private static AdicionarRespostaOcorrenciaMoradorCommand CadastrarRespostaOcorrenciaMoradorCommandFactory()
        {
            return new AdicionarRespostaOcorrenciaMoradorCommand(
                Guid.NewGuid(), "Descricao da Ocorrencia", Guid.NewGuid(),
                "Nome do Morador", "fotoNome.jpg", "nomeOriginalArquivoAnexo.jpg");
        }

        private static AtualizarRespostaOcorrenciaCommand EditarRespostaOcorrenciaCommandFactory()
        {
            return new AtualizarRespostaOcorrenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "Nova Descricao");
        }



        public static AdicionarRespostaOcorrenciaAdministracaoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico()
        {
            return CadastrarRespostaOcorrenciaSindicoCommandFactory();
        }

        public static AdicionarRespostaOcorrenciaAdministracaoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemDescricao()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetDescricao("");

            return comando;
        }

        public static AdicionarRespostaOcorrenciaAdministracaoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemUsuario()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetAutorId(Guid.Empty);

            return comando;
        }

        public static AdicionarRespostaOcorrenciaAdministracaoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_SemFoto()
        {
            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory();

            comando.SetFoto("");

            return comando;
        }

        public static AdicionarRespostaOcorrenciaAdministracaoCommand CriarComando_CadastroDeRespostaOcorrenciaSindico_Resolvido()
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

            comando.SetAutorId(Guid.Empty);

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