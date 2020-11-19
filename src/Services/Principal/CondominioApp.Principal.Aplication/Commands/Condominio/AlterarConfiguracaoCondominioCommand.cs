using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AlterarConfiguracaoCondominioCommand : CondominioCommand
    {

        public AlterarConfiguracaoCondominioCommand(Guid condominioId, bool portaria = false, bool portariaMorador = false,
            bool classificado = false, bool classificadoMorador = false, bool mural = false, bool muralMorador = false,
            bool chat = false, bool chatMorador = false, bool reserva = false, bool reservaNaPortaria = false,
            bool ocorrencia = false, bool ocorrenciaMorador = false, bool correspondencia = false,
            bool correspondenciaNaPortaria = false, bool limiteTempoReserva = false)
        {
            CondominioId = condominioId;           
            Portaria = portaria;
            PortariaMorador = portariaMorador;
            Classificado = classificado;
            ClassificadoMorador = classificadoMorador;
            Mural = mural;
            MuralMorador = muralMorador;
            Chat = chat;
            ChatMorador = chatMorador;
            Reserva = reserva;
            ReservaNaPortaria = reservaNaPortaria;
            Ocorrencia = ocorrencia;
            OcorrenciaMorador = ocorrenciaMorador;
            Correspondencia = correspondencia;
            CorrespondenciaNaPortaria = correspondenciaNaPortaria;
            LimiteTempoReserva = limiteTempoReserva;
        }


        public override bool EstaValido()
        {
            ValidationResult = new AlterarConfiguracaoCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarConfiguracaoCondominioCommandValidation : CondominioValidation<AlterarConfiguracaoCondominioCommand>
        {
            public AlterarConfiguracaoCondominioCommandValidation()
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
