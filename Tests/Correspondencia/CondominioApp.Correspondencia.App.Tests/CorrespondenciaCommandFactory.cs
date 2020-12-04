using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Correspondencias.App.Tests
{
    public class CorrespondenciaCommandFactory
    {
        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondencia()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "101", "Bloco", null, Guid.NewGuid(),
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemCondominio()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.Empty, Guid.NewGuid(), "101", "Bloco", null, Guid.NewGuid(),
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemUnidadeId()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.Empty, "101", "Bloco", null, Guid.NewGuid(),
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemNumeroUnidade()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), null, "Bloco", null, Guid.NewGuid(),
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemBloco()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "101", null, null, Guid.NewGuid(),
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemUsuarioId()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "101", "Bloco", null, Guid.Empty,
                "Rafael", null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
        }

        public static CadastrarCorrespondenciaCommand CriarComandoCadastroDeCorrespondenciaSemNomeUsuario()
        {
            //Act
            return new CadastrarCorrespondenciaCommand(
                Guid.NewGuid(), Guid.NewGuid(), "101", "Bloco", null, Guid.NewGuid(),
                null, null, null, null, DataHoraDeBrasilia.Get(), "Caixa",
                StatusCorrespondencia.PENDENTE);
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
    }
}