using CondominioApp.Enquetes.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class RespostaEnqueteCommandFactory
    {
        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnquete()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "Bloco Um", Guid.NewGuid(), "Nome Do Usuario", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemUnidadeId()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.Empty, "101", "Bloco Um", Guid.NewGuid(), "Nome Do Usuario", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemUnidade()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "", "Bloco Um", Guid.NewGuid(), "Nome Do Usuario", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemBloco()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "", Guid.NewGuid(), "Nome Do Usuario", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemUsuarioId()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "Bloco Um", Guid.Empty, "Nome Do Usuario", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemUsuario()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "Bloco Um", Guid.NewGuid(), "", "CLIENTE", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemTipoDeUsuario()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "Bloco Um", Guid.NewGuid(), "Nome Do Usuario", "", Guid.NewGuid());
        }

        public static CadastrarRespostaCommand CriarComandoCadastrarRespostaEnqueteSemAlternativaId()
        {
            //Act
            return new CadastrarRespostaCommand(
                Guid.NewGuid(), "104", "Bloco Um", Guid.NewGuid(), "Nome Do Usuario", "CLIENTE", Guid.Empty);
        }
    }
}