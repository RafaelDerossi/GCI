using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitaCommandFactory 
    {
        public static CadastrarVisitaPorPorteiroCommand CadastrarVisitaCommandFactory()
        {
            return new CadastrarVisitaPorPorteiroCommand
                (DateTime.Today, "OBS", StatusVisita.PENDENTE, Guid.NewGuid(),
                "Nome do Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR, "", Guid.NewGuid(),
                "Nome Condominio", Guid.NewGuid(), "101", "1º", "Bloco 1", 
                true, "LMG8888", "Modelo", "Prata", Guid.NewGuid(), "Nome Usuario");
        }

        public static EditarVisitaCommand EditarVisitaCommandFactory()
        {
            return new EditarVisitaCommand
                (Guid.NewGuid(), "Obs", "Nome do Visitante", TipoDeDocumento.CPF, "143.026.417-97",
                "rafael@condominioapp.com", "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR,
                "", Guid.NewGuid(), "101", "1", "Bloco 1", true, "LMG8888", "Modelo", "Prata",
                 Guid.NewGuid(), "Nome do Usuario");
        }


        
        /// CadastrarVisitaCommand        
        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_ComCPF()
        {
            return CadastrarVisitaCommandFactory();
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComCPFInvalido()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("143.026.417-98", TipoDeDocumento.CPF);           
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_Morador_ComCPF()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDataDeEntrada(DateTime.Today.AddDays(1).Date);
            comando.AprovarVisita();
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_ComRG()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("123456789", TipoDeDocumento.RG);
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_SemDocumento()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("", TipoDeDocumento.OUTROS);
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_VisitanteNovo()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetVisitanteId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_VisitaDeServico()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetTipoDeVisitante(TipoDeVisitante.SERVICO);
            comando.SetNomeEmpresaVisitante("Empresa Visitante");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemCondominioId()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemNomeDoCondominio()
        {
            var comando = CadastrarVisitaCommandFactory();          
            comando.SetNomeDoCondominio("");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemUnidadeId()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemNumeroUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetNumeroUnidade("");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemAndarUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetAndarUnidade("");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemGrupoUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetGrupoUnidade("");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemVeiculo()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.MarcarQueNaoTemVeiculo();
            comando.SetVeiculo("","","");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemPlaca()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "Modelo", "Prata");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemModelo()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "", "Prata");
            return comando;
        }

        public static CadastrarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemCor()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "Modelo", "");
            return comando;
        }


        ///EditarVisitaCommand
        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_ComCPF()
        {
            return EditarVisitaCommandFactory();
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_ComCPFInvalido()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("143.026.417-98", TipoDeDocumento.CPF);

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_ComRG()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("123456789", TipoDeDocumento.RG);

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemDocumento()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("", TipoDeDocumento.OUTROS);

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemUnidadeId()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetUnidadeId(Guid.Empty);

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemNumeroUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetNumeroUnidade("");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemAndarUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetAndarUnidade("");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemGrupoUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetGrupoUnidade("");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemVeiculo()
        {
            var comando = EditarVisitaCommandFactory();

            comando.MarcarQueNaoTemVeiculo();
            comando.SetVeiculo("", "", "");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemPlaca()
        {
            var comando = EditarVisitaCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "Modelo", "Prata");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemModelo()
        {
            var comando = EditarVisitaCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "", "Prata");

            return comando;
        }

        public static EditarVisitaCommand CriarComandoEdicaoDeVisita_SemCor()
        {
            var comando = EditarVisitaCommandFactory();

            comando.MarcarQueTemVeiculo();
            comando.SetVeiculo("", "Modelo", "");

            return comando;
        }

    }

}
