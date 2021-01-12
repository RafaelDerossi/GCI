using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitanteCommandFactory
    {

        public static CadastrarVisitanteCommand CadastrarVisitanteCommandFactory()
        {
            return new CadastrarVisitanteCommand
              ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
              "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
              "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_ComCPF()
        {
            return CadastrarVisitanteCommandFactory();
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_ComCPFInvalido()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetDocumento("143.026.417-98");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_ComRG()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetDocumento("123456789");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemDocumento()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetDocumento("");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemEmail()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetEmail("");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemFoto()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetFoto("","");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemCondominioId()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemNomeDoCondominio()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetNomeCondominio("");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemUnidadeId()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemNumeroUnidade()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetNumeroUnidade("");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemAndarUnidade()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetAndarDaUnidade("");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemGrupoUnidade()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetGrupoDaUnidade("");
            return comando;
        }      

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemPlacaVeiculo()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetVeiculo("", "modelo", "Prata");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemModeloVeiculo()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetVeiculo("", "", "Prata");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemCorVeiculo()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.SetVeiculo("", "modelo", "");
            return comando;
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemVeiculo()
        {
            var comando = CadastrarVisitanteCommandFactory();
            comando.MarcarQueNaoTemVeiculo();
            comando.SetVeiculo("", "", "");
            return comando;
        }



    }

}
