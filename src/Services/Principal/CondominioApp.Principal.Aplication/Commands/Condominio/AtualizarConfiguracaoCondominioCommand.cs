using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtualizarConfiguracaoCondominioCommand : CondominioCommand
    {

        public AtualizarConfiguracaoCondominioCommand(Guid condominioId, bool portaria, bool portariaParaMoradorAtivada,
            bool classificadoAtivado, bool classificadoParaMoradorAtivado, bool muralAtivado, bool muralParaMoradorAtivado,
            bool chatAtivado, bool chatParaMoradorAtivado, bool reservaAtivada, bool reservaNaPortariaAtivada,
            bool ocorrenciaAtivada, bool ocorrenciaParaMoradorAtivada, bool correspondenciaAtivada,
            bool correspondenciaNaPortariaAtivada, bool cadastroDeVeiculoPeloMoradorAtivado)
        {
            Id = condominioId;           
            PortariaAtivada = portaria;
            PortariaParaMoradorAtivada = portariaParaMoradorAtivada;
            ClassificadoAtivado = classificadoAtivado;
            ClassificadoParaMoradorAtivado = classificadoParaMoradorAtivado;
            MuralAtivado = muralAtivado;
            MuralParaMoradorAtivado = muralParaMoradorAtivado;
            ChatAtivado = chatAtivado;
            ChatParaMoradorAtivado = chatParaMoradorAtivado;
            ReservaAtivada = reservaAtivada;
            ReservaNaPortariaAtivada = reservaNaPortariaAtivada;
            OcorrenciaAtivada = ocorrenciaAtivada;
            OcorrenciaParaMoradorAtivada = ocorrenciaParaMoradorAtivada;
            CorrespondenciaAtivada = correspondenciaAtivada;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortariaAtivada;
            CadastroDeVeiculoPeloMoradorAtivado = cadastroDeVeiculoPeloMoradorAtivado;
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
