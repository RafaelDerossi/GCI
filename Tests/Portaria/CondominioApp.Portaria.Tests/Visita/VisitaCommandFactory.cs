using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitaCommandFactory 
    {
        public static AdicionarVisitaPorPorteiroCommand CadastrarVisitaCommandFactory()
        {
            return new AdicionarVisitaPorPorteiroCommand
                ("OBS", StatusVisita.PENDENTE, Guid.NewGuid(),
                "Nome do Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR, "", Guid.NewGuid(),
                "Nome Condominio", Guid.NewGuid(), "101", "1º", "Bloco 1", 
                true, "LMG8888", "Modelo", "Prata", Guid.NewGuid(), "Nome Usuario");
        }

        public static AtualizarVisitaCommand EditarVisitaCommandFactory()
        {
            return new AtualizarVisitaCommand
                (Guid.NewGuid(), "Obs", "Nome do Visitante", TipoDeDocumento.CPF, "143.026.417-97",
                "rafael@condominioapp.com", "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR,
                "", Guid.NewGuid(), "101", "1", "Bloco 1", true, "LMG8888", "Modelo", "Prata",
                 Guid.NewGuid(), "Nome do Usuario");
        }


        
        /// CadastrarVisitaCommand        
        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_ComCPF()
        {
            return CadastrarVisitaCommandFactory();
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComCPFInvalido()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("143.026.417-98", TipoDeDocumento.CPF);           
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_Morador_ComCPF()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDataDeEntrada(DateTime.Today.AddDays(1).Date);
            comando.AprovarVisita();
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_ComRG()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("123456789", TipoDeDocumento.RG);
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_SemDocumento()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDocumentoVisitante("", TipoDeDocumento.OUTROS);
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_VisitanteNovo()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetVisitanteId(Guid.Empty);
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria_VisitaDeServico()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetTipoDeVisitante(TipoDeVisitante.SERVICO);
            comando.SetNomeEmpresaVisitante("Empresa Visitante");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemCondominioId()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemNomeDoCondominio()
        {
            var comando = CadastrarVisitaCommandFactory();          
            comando.SetNomeDoCondominio("");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemUnidadeId()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemNumeroUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetNumeroUnidade("");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemAndarUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetAndarUnidade("");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemGrupoUnidade()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetGrupoUnidade("");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_SemVeiculo()
        {
            var comando = CadastrarVisitaCommandFactory();            
            comando.SetVeiculoPeloPorteiro(false,"","","");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemPlaca()
        {
            var comando = CadastrarVisitaCommandFactory();            
            comando.SetVeiculoPeloPorteiro(true, "", "Modelo", "Prata");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemModelo()
        {
            var comando = CadastrarVisitaCommandFactory();            
            comando.SetVeiculoPeloPorteiro(true,"", "", "Prata");
            return comando;
        }

        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_ComVeiculoSemCor()
        {
            var comando = CadastrarVisitaCommandFactory();            
            comando.SetVeiculoPeloPorteiro(true,"", "Modelo", "");
            return comando;
        }


        ///EditarVisitaCommand
        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_ComCPF()
        {
            return EditarVisitaCommandFactory();
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_ComCPFInvalido()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("143.026.417-98", TipoDeDocumento.CPF);

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_ComRG()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("123456789", TipoDeDocumento.RG);

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemDocumento()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetDocumentoVisitante("", TipoDeDocumento.OUTROS);

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemUnidadeId()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetUnidadeId(Guid.Empty);

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemNumeroUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetNumeroUnidade("");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemAndarUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetAndarUnidade("");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemGrupoUnidade()
        {
            var comando = EditarVisitaCommandFactory();

            comando.SetGrupoUnidade("");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemVeiculo()
        {
            var comando = EditarVisitaCommandFactory();
            
            comando.SetVeiculoPeloPorteiro(false, "", "", "");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemPlaca()
        {
            var comando = EditarVisitaCommandFactory();
                        
            comando.SetVeiculoPeloPorteiro(true, "", "Modelo", "Prata");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemModelo()
        {
            var comando = EditarVisitaCommandFactory();
                        
            comando.SetVeiculoPeloPorteiro(true,"", "", "Prata");

            return comando;
        }

        public static AtualizarVisitaCommand CriarComandoEdicaoDeVisita_SemCor()
        {
            var comando = EditarVisitaCommandFactory();
                        
            comando.SetVeiculoPeloPorteiro(true,"", "Modelo", "");

            return comando;
        }

    }

}
