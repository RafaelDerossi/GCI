

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CadastrarReservaPelaAdmCommand : ReservaCommand
    {

        public CadastrarReservaPelaAdmCommand
            (Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade,
             string andarUnidade, string descricaoGrupoUnidade, Guid moradorId, string nomeMorador,
             DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
             string origem, bool reservadoPelaAdministracao,  Guid funcionarioId, string nomeFuncionario)
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
            ReservadoPelaAdministracao = reservadoPelaAdministracao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarReservaPelaAdmCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarReservaPelaAdmCommandValidation : ReservaValidation<CadastrarReservaPelaAdmCommand>
        {
            public CadastrarReservaPelaAdmCommandValidation()
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
                ValidateReservadoPelaAdministracao();
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateOrigem();
            }
        }

    }
}
