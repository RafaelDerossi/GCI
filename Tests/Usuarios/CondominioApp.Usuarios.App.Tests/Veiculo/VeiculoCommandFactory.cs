using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class VeiculoCommandFactory
    {
        private static CadastrarVeiculoCommand CadastrarVeiculoCommandFactory()
        {
            return new CadastrarVeiculoCommand(Guid.NewGuid(),"lmg8922","Modelo","Cor", Guid.NewGuid(), Guid.NewGuid());
        }

        public static CadastrarVeiculoCommand CriarComandoCadastroDeVeiculo()
        {
            return CadastrarVeiculoCommandFactory();
        }
      
    }
}