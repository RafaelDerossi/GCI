using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Tests
{
    public class VisitanteCommandFactory
    {
      
        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_ComCPF()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante","143.026.417-97","rafael@condominioapp.com",
                "foto.jpg","nomeOriginal.jpg",Guid.NewGuid(),"Nome Condominio",Guid.NewGuid(),
                "101","1º","Bloco",false,"qrCode",TipoDeVisitante.PARTICULAR,"",true,
                "LMG8888","Modelo Veiculo","Prata");          
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_ComRG()
        {
            return new CadastrarVisitanteCommand
               ("Nome Visitante", "123456789", "rafael@condominioapp.com",
               "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
               "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
               "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemDocumento()
        {
            return new CadastrarVisitanteCommand
               ("Nome Visitante", "", "rafael@condominioapp.com",
               "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
               "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
               "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemEmail()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemFoto()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "", "", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemCondominioId()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.Empty, "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemNomeDoCondominio()
        {
            return new CadastrarVisitanteCommand
               ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
               "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "", Guid.NewGuid(),
               "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
               "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemUnidadeId()
        {
            return new CadastrarVisitanteCommand
               ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
               "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.Empty,
               "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
               "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemNumeroUnidade()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemAndarUnidade()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemGrupoUnidade()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemTipoDeVisitante()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", 0, "", true,
                "LMG8888", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemPlacaVeiculo()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "", "Modelo Veiculo", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemModeloVeiculo()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "", "Prata");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemCorVeiculo()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", true,
                "LMG8888", "Modelo", "");
        }

        public static CadastrarVisitanteCommand CriarComandoCadastroDeVisitante_SemVeiculo()
        {
            return new CadastrarVisitanteCommand
                ("Nome Visitante", "143.026.417-97", "rafael@condominioapp.com",
                "foto.jpg", "nomeOriginal.jpg", Guid.NewGuid(), "Nome Condominio", Guid.NewGuid(),
                "101", "1º", "Bloco", false, "qrCode", TipoDeVisitante.PARTICULAR, "", false,
                "", "", "");
        }



    }

}
