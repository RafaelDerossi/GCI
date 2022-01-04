using GCI.Acoes.Aplication.Commands;
using System;

namespace GCI.Acoes.Tests
{
    public class AcaoCommandFactory
    {
        private static AdicionarAcaoCommand AdicionarAcaoCommandFactoy()
        {
            return new AdicionarAcaoCommand("TSLA", "Tesla");
        }


        public static AdicionarAcaoCommand CriarComandoAdicionarAcao()
        {
            return AdicionarAcaoCommandFactoy();
        }

        public static AdicionarAcaoCommand CriarComandoAdicionarAcaoSemCodigo()
        {
            var comando = AdicionarAcaoCommandFactoy();

            comando.SetCodigo("");
            
            return comando;
        }

    }
}