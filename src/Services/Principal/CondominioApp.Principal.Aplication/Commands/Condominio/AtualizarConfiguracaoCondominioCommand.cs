using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtualizarConfiguracaoCondominioCommand : CondominioCommand
    {

        public AtualizarConfiguracaoCondominioCommand(Guid condominioId, bool portaria = false, bool portariaMorador = false,
            bool classificado = false, bool classificadoMorador = false, bool mural = false, bool muralMorador = false,
            bool chat = false, bool chatMorador = false, bool reserva = false, bool reservaNaPortaria = false,
            bool ocorrencia = false, bool ocorrenciaMorador = false, bool correspondencia = false,
            bool correspondenciaNaPortaria = false, bool limiteTempoReserva = false)
        {
            CondominioId = condominioId;           
            PortariaAtivada = portaria;
            PortariaParaMoradorAtivada = portariaMorador;
            ClassificadoAtivado = classificado;
            ClassificadoParaMoradorAtivado = classificadoMorador;
            MuralAtivado = mural;
            MuralParaMoradorAtivado = muralMorador;
            ChatAtivado = chat;
            ChatParaMoradorAtivado = chatMorador;
            ReservaAtivada = reserva;
            ReservaNaPortariaAtivada = reservaNaPortaria;
            OcorrenciaAtivada = ocorrencia;
            OcorrenciaParaMoradorAtivada = ocorrenciaMorador;
            CorrespondenciaAtivada = correspondencia;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortaria;
            LimiteTempoReserva = limiteTempoReserva;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarConfiguracaoCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarConfiguracaoCondominioCommandValidation : CondominioValidation<AtualizarConfiguracaoCondominioCommand>
        {
            public AtualizarConfiguracaoCondominioCommandValidation()
            {
                ValidateId();
                ValidatePortaria();
                ValidatePortariaMorador();
                ValidateClassificado();
                ValidateClassificadoMorador();
                ValidateMural();
                ValidateMuralMorador();
                ValidateChat();
                ValidateChatMorador();
                ValidateReserva();
                ValidateReservaNaPortaria();
                ValidateOcorrencia();
                ValidateOcorrenciaMorador();
                ValidateCorrespondencia();
                ValidateCorrespondenciaNaPortaria();
                
            }
        }

    }
}
