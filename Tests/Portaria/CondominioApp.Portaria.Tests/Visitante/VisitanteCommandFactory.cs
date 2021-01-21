using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitanteCommandFactory
    {
        public static CadastrarVisitantePorMoradorCommand CadastrarVisitantePorMoradorCommandFactory()
        {
            return new CadastrarVisitantePorMoradorCommand
              ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
              "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
              "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitantePorPorteiroCommand CadastrarVisitantePorPorteiroCommandFactory()
        {
            return new CadastrarVisitantePorPorteiroCommand
              (Guid.NewGuid(), "Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
              "101", "1º", "Bloco", TipoDeVisitante.PARTICULAR, "", true,
              "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static EditarVisitantePorMoradorCommand EditarVisitantePorMoradorCommandFactory()
        {
            return new EditarVisitantePorMoradorCommand
              (Guid.NewGuid(), "Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", false, TipoDeVisitante.PARTICULAR, "", true,
              "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static EditarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory()
        {
            return new EditarVisitantePorPorteiroCommand
              (Guid.NewGuid(), "Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR, "", true,
              "LMG8888", "Modelo Veiculo", "Prata");
        }


        /// CadastrarVisitanteCommand        
        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitantePorMorador_ComCPF()
        {
            return CadastrarVisitantePorMoradorCommandFactory();
        }

        public static CadastrarVisitantePorPorteiroCommand CriarComandoCadastroDeVisitantePorPorteiro_ComCPF()
        {
            return CadastrarVisitantePorPorteiroCommandFactory();
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_ComCPFInvalido()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("143.026.417-98");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_ComRG()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("123456789");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemDocumento()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemEmail()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetEmail("");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemFoto()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetFoto("","");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemCondominioId()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemNomeDoCondominio()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetNomeCondominio("");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemUnidadeId()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemNumeroUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetNumeroUnidade("");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemAndarUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetAndarDaUnidade("");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemGrupoUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetGrupoDaUnidade("");
            return comando;
        }      

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemPlacaVeiculo()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetVeiculo("", "modelo", "Prata");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemModeloVeiculo()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetVeiculo("", "", "Prata");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemCorVeiculo()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetVeiculo("", "modelo", "");
            return comando;
        }

        public static CadastrarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemVeiculo()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.MarcarQueNaoTemVeiculo();
            comando.SetVeiculo("", "", "");
            return comando;
        }


        ///EditarVisitanteCommand
        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitantePorMorador_ComCPF()
        {
            return EditarVisitantePorMoradorCommandFactory();
        }

        public static EditarVisitantePorPorteiroCommand CriarComandoEdicaoDeVisitantePorPorteiro_ComCPF()
        {
            return EditarVisitantePorPorteiroCommandFactory();
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_ComCPFInvalido()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("14302641798");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_ComRG()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("123456789");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemDocumento()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemPlaca()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("","Modelo","Prata");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemModelo()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "", "Prata");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemCor()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "Modelo", "");

            return comando;
        }

        public static EditarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemVeiculo()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.MarcarQueNaoTemVeiculo();
            comando.SetVeiculo("", "", "");

            return comando;
        }

    }

}
