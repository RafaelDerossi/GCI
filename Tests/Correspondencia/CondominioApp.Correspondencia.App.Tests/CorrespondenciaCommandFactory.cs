using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Correspondencias.App.Tests
{
    public class CorrespondenciaCommandFactory
    {
        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaFactory()
        {
            //Act
            return new AdicionarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "101", "Bloco", "", Guid.NewGuid(),
                "Rafael", "foto.jpg", "", DataHoraDeBrasilia.Get(), "Caixa", true, "");
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondencia()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemCondominio()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            comando.SetCondominio(Guid.Empty);

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemUnidadeId()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            comando.SetUnidade(Guid.Empty, "101", "Grupo");

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemNumeroUnidade()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();
            
            comando.SetUnidade(Guid.NewGuid(), "", "Grupo");

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemBloco()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            comando.SetUnidade(Guid.NewGuid(), "101", "");

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemFuncionarioId()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            comando.SetFuncionario(Guid.Empty, "Nome");

            return comando;
        }

        public static AdicionarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemNomeFuncionario()
        {
            var comando = CriarComandoCadastroDeCorrespondenciaFactory();

            comando.SetFuncionario(Guid.NewGuid(), "");

            return comando;
        }

        public static MarcarCorrespondenciaVistaCommand CriarComandoMarcarCorrespondenciaVista()
        {
            //Act
            return new MarcarCorrespondenciaVistaCommand(Guid.NewGuid());
        }

        public static MarcarCorrespondenciaRetiradaCommand CriarComandoMarcarCorrespondenciaRetirada()
        {
            //Act
            return new MarcarCorrespondenciaRetiradaCommand(Guid.NewGuid(),"Retirante","OBS",Guid.NewGuid(),"Usuario");
        }

        public static MarcarCorrespondenciaRetiradaCommand CriarComandoMarcarCorrespondenciaRetiradaSemNomeDoRetirante()
        {
            //Act
            return new MarcarCorrespondenciaRetiradaCommand(Guid.NewGuid(), null, "OBS", Guid.NewGuid(), "Usuario");
        }

        public static MarcarCorrespondenciaRetiradaCommand CriarComandoMarcarCorrespondenciaRetiradaSemUsuarioId()
        {
            //Act
            return new MarcarCorrespondenciaRetiradaCommand(Guid.NewGuid(), "Retirante", "OBS", Guid.Empty, "Usuario");
        }

        public static MarcarCorrespondenciaRetiradaCommand CriarComandoMarcarCorrespondenciaRetiradaSemNomeDoUsuario()
        {
            //Act
            return new MarcarCorrespondenciaRetiradaCommand(Guid.NewGuid(), "Retirante", "OBS", Guid.NewGuid(), null);
        }

        public static MarcarCorrespondenciaDevolvidaCommand CriarComandoMarcarCorrespondenciaDevolvida()
        {
            //Act
            return new MarcarCorrespondenciaDevolvidaCommand(Guid.NewGuid(), "OBS", Guid.NewGuid(), "Usuario");
        }

        public static MarcarCorrespondenciaDevolvidaCommand CriarComandoMarcarCorrespondenciaDevolvidaSemUsuarioId()
        {
            //Act
            return new MarcarCorrespondenciaDevolvidaCommand(Guid.NewGuid(), "OBS", Guid.Empty, "Usuario");
        }

        public static MarcarCorrespondenciaDevolvidaCommand CriarComandoMarcarCorrespondenciaDevolvidaSemNomeDoUsuario()
        {
            //Act
            return new MarcarCorrespondenciaDevolvidaCommand(Guid.NewGuid(), "OBS", Guid.NewGuid(), null);
        }

        public static DispararAlertaDeCorrespondenciaCommand CriarComandoDispararAlertaDeCorrespondencia()
        {
            //Act
            return new DispararAlertaDeCorrespondenciaCommand(Guid.NewGuid());
        }

        public static GerarExcelCorrespondenciaCommand CriarComandGerarExcelDeCorrespondencia()
        {
            //Arrange
            var lista = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            //Act
            return new GerarExcelCorrespondenciaCommand
                (lista,
                @"C:\Users\rafael souza\source\repos\CondominioAppBackEnd2.0\src\WebApi\CondominioApp.Api\wwwroot",
                Guid.NewGuid().ToString());
        }
    }
}