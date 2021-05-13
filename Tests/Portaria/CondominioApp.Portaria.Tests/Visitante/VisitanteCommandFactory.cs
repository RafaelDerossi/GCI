using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitanteCommandFactory
    {
        public static AdicionarVisitantePorMoradorCommand CadastrarVisitantePorMoradorCommandFactory()
        {
            return new AdicionarVisitantePorMoradorCommand
              ("Nome Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
              "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true);
        }

        public static AdicionarVisitantePorPorteiroCommand CadastrarVisitantePorPorteiroCommandFactory()
        {
            return new AdicionarVisitantePorPorteiroCommand
              (Guid.NewGuid(), "Nome Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
              "101", "1º", "Bloco", TipoDeVisitante.PARTICULAR, "", true);
        }

        public static AtualizarVisitantePorMoradorCommand EditarVisitantePorMoradorCommandFactory()
        {
            return new AtualizarVisitantePorMoradorCommand
              (Guid.NewGuid(), "Nome Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", false, TipoDeVisitante.PARTICULAR, "", true);
        }

        public static AtualizarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory()
        {
            return new AtualizarVisitantePorPorteiroCommand
              (Guid.NewGuid(), "Nome Visitante",TipoDeDocumento.CPF, "143.026.417-97", "rafael@condominioapp.com",
              "foto.jpg", "nomeOriginal.jpg", TipoDeVisitante.PARTICULAR, "", true);
        }


        /// CadastrarVisitanteCommand        
        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitantePorMorador_ComCPF()
        {
            return CadastrarVisitantePorMoradorCommandFactory();
        }

        public static AdicionarVisitantePorPorteiroCommand CriarComandoCadastroDeVisitantePorPorteiro_ComCPF()
        {
            return CadastrarVisitantePorPorteiroCommandFactory();
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_ComCPFInvalido()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("143.026.417-98", TipoDeDocumento.CPF);
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_ComRG()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("123456789", TipoDeDocumento.RG);
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemDocumento()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetDocumento("", TipoDeDocumento.OUTROS);
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemEmail()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetEmail("");
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemFoto()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetFoto("","");
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemCondominioId()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemNomeDoCondominio()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetNomeCondominio("");
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemUnidadeId()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetUnidadeId(Guid.Empty);
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemNumeroUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetNumeroUnidade("");
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemAndarUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetAndarDaUnidade("");
            return comando;
        }

        public static AdicionarVisitantePorMoradorCommand CriarComandoCadastroDeVisitante_SemGrupoUnidade()
        {
            var comando = CadastrarVisitantePorMoradorCommandFactory();
            comando.SetGrupoDaUnidade("");
            return comando;
        }      
        
        


        ///EditarVisitanteCommand
        public static AtualizarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitantePorMorador_ComCPF()
        {
            return EditarVisitantePorMoradorCommandFactory();
        }

        public static AtualizarVisitantePorPorteiroCommand CriarComandoEdicaoDeVisitantePorPorteiro_ComCPF()
        {
            return EditarVisitantePorPorteiroCommandFactory();
        }

        public static AtualizarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_ComCPFInvalido()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("14302641798", TipoDeDocumento.CPF);

            return comando;
        }

        public static AtualizarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_ComRG()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("123456789", TipoDeDocumento.RG);

            return comando;
        }

        public static AtualizarVisitantePorMoradorCommand CriarComandoEdicaoDeVisitante_SemDocumento()
        {
            var comando = EditarVisitantePorMoradorCommandFactory();

            comando.SetDocumento("", TipoDeDocumento.OUTROS);

            return comando;
        }
              
        

    }

}
