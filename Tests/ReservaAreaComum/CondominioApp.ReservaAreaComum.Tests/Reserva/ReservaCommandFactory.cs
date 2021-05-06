using CondominioApp.ReservaAreaComum.Aplication.Commands;
using System;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class ReservaCommandFactory
    {      

        #region SolicitarReservaComoMoradorCommand
        public static SolicitarReservaComoMoradorCommand SolicitarReservaComoMoradorCommandFactory()
        {
            return new SolicitarReservaComoMoradorCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Morador", DateTime.Now.Date, "08:00", "09:00",
                150, "Mobile", false);
        }

                
        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaComoMorador()
        {
            return SolicitarReservaComoMoradorCommandFactory();
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemAreaComumIdComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetAreaComumId(Guid.Empty);

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemUnidadeIdComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetUnidadeId(Guid.Empty);

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemNumeroDaUnidadeComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetNumeroUnidade("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemAndarDaUnidadeComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetAndarUnidade("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemGrupoDaUnidadeComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetGrupoUnidade("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemUsuarioIdComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetMoradorId(Guid.Empty);

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemNomeDoUsuarioComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetNomeMorador("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemHoraInicioComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetHoraInicio("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaComHoraInicioInvalidoComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetHoraInicio("30:00");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaSemHoraFimComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetHoraFim("");

            return comando;
        }

        public static SolicitarReservaComoMoradorCommand CriarComandoSolicitacaoDeReservaComHoraFimInvalidoComoMorador()
        {
            var comando = SolicitarReservaComoMoradorCommandFactory();

            comando.SetHoraFim("30:00");

            return comando;
        }
        #endregion



        #region SolicitarReservaComoAdministradorCommand
        public static SolicitarReservaComoAdministradorCommand SolicitarReservaComoAdministradorCommandFactory()
        {
            return new SolicitarReservaComoAdministradorCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Morador", DateTime.Now.Date, "08:00", "09:00",
                150, "Mobile", false, Guid.NewGuid(), "Nome do Funcionario");
        }


        
        public static SolicitarReservaComoAdministradorCommand CriarComandoSolicitacaoDeReservaComoAdministrador()
        {
            return SolicitarReservaComoAdministradorCommandFactory();
        }

        #endregion

    }

}
