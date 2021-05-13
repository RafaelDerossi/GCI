using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class VeiculoCommandFactory
    {
        private static AdicionarVeiculoCommand CadastrarVeiculoCommandFactory()
        {
            return new AdicionarVeiculoCommand
                (Guid.NewGuid(),"LMG8922","Modelo","Cor", Guid.NewGuid(),"101","1","Bloco A",
                Guid.NewGuid(), "Nome do Condominio", "", "");
        }

        public static AdicionarVeiculoCommand CriarComandoCadastroDeVeiculo()
        {
            return CadastrarVeiculoCommandFactory();
        }

        public static AdicionarVeiculoCommand CriarComandoCadastroDeVeiculoComPlacaInvalida()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("lmg-8955", "modelo", "cor");

            return comando;
        }

        public static AdicionarVeiculoCommand CriarComandoCadastroDeVeiculoSemPlaca()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("", "modelo", "cor");

            return comando;
        }

        public static AdicionarVeiculoCommand CriarComandoCadastroDeVeiculoSemModelo()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("LMG8955", "", "cor");

            return comando;
        }

        public static AdicionarVeiculoCommand CriarComandoCadastroDeVeiculoSemCor()
        {
            var comando = CadastrarVeiculoCommandFactory();

            comando.SetVeiculo("LMG8955", "modelo", "");

            return comando;
        }
        

    }
}