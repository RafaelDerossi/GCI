using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;

namespace CondominioApp.Portaria.Tests
{
    public class VisitaCommandFactory 
    {
        public static AdicionarVisitaPorPorteiroCommand CadastrarVisitaCommandFactory()
        {
            return new AdicionarVisitaPorPorteiroCommand
                ("OBS", Guid.NewGuid(), TipoDeVisitante.PARTICULAR, "", Guid.NewGuid(),
                "Nome Condominio", Guid.NewGuid(), "101", "1º", "Bloco 1", 
                true, "LMG8888", "Modelo", "Prata", Guid.NewGuid(), "Nome Usuario");
        }

        public static AtualizarVisitaCommand EditarVisitaCommandFactory()
        {
            return new AtualizarVisitaCommand
                (Guid.NewGuid(), "Obs", TipoDeVisitante.PARTICULAR, "",
                 Guid.NewGuid(), "101", "1", "Bloco 1", true, "LMG8888", "Modelo", "Prata",
                 Guid.NewGuid(), "Nome do Usuario");
        }


        
        /// CadastrarVisitaCommand        
        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_NaPortaria()
        {
            return CadastrarVisitaCommandFactory();
        }
       
        public static AdicionarVisitaPorPorteiroCommand CriarComandoCadastroDeVisita_Morador()
        {
            var comando = CadastrarVisitaCommandFactory();
            comando.SetDataDeEntrada(DateTime.Today.AddDays(1).Date);
            comando.AprovarVisita();
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
