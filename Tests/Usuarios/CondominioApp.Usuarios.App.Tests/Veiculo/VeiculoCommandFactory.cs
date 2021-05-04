using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class VeiculoCommandFactory
    {
        private static CadastrarVeiculoCommand CadastrarVeiculoCommandFactory()
        {
            return new CadastrarVeiculoCommand
                (Guid.NewGuid(),"LMG8922","Modelo","Cor", Guid.NewGuid(),"101","1","Bloco A",
                Guid.NewGuid(), "Nome do Condominio");
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculo()
        {
            return CadastrarVeiculoCommandFactory();
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculoComPlacaInvalida()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("lmg-8955", "modelo", "cor");

            return comando;
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculoSemPlaca()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("", "modelo", "cor");

            return comando;
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculoSemModelo()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("LMG8955", "", "cor");

            return comando;
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculoSemCor()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("LMG8955", "modelo", "");

            return comando;
        }
        

    }
}