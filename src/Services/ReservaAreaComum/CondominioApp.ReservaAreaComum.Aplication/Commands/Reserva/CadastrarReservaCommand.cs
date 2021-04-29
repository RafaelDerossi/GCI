

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CadastrarReservaCommand : ReservaCommand
    {

        public CadastrarReservaCommand
            (Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade,
             string andarUnidade, string descricaoGrupoUnidade, Guid moradorId, string nomeMorador,
             DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
             string origem, bool criadaPelaAdministracao, bool reservadoPelaAdministracao)
        {            
            SetAreaComumId(areaComumId);
            Observacao = observacao;
            UnidadeId = unidadeId;
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(descricaoGrupoUnidade);
            SetMoradorId(moradorId);
            SetNomeMorador(nomeMorador);
            DataDeRealizacao = dataDeRealizacao;
            SetHoraInicio(horaInicio);
            SetHoraFim(horaFim);
            Preco = preco;            
            Origem = origem;
            CriadaPelaAdministracao = criadaPelaAdministracao;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarReservaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarReservaCommandValidation : ReservaValidation<CadastrarReservaCommand>
        {
            public CadastrarReservaCommandValidation()
            {
                ValidateAreaComumId();
                ValidateObservacao();
                ValidateUnidadeId();
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateDescricaoGrupoUnidade();
                ValidateMoradorId();
                ValidateNomeMorador();
                ValidateDataDeRealizacao();
                ValidateHoraInicio();
                ValidateHoraFim();               
                ValidatePreco();                
                ValidateOrigem();
                ValidateCriadoPelaAdministracao();
                ValidateReservadoPelaAdministracao();
            }
        }

    }
}
