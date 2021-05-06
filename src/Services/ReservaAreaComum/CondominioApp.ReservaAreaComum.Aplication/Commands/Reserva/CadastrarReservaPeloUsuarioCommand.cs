

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CadastrarReservaPeloUsuarioCommand : ReservaCommand
    {

        public CadastrarReservaPeloUsuarioCommand
            (Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade,
             string andarUnidade, string descricaoGrupoUnidade, Guid moradorId, string nomeMorador,
             DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
             string origem, bool reservadoPelaAdministracao)
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
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarReservaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarReservaCommandValidation : ReservaValidation<CadastrarReservaPeloUsuarioCommand>
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
                ValidateReservadoPelaAdministracao();
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateOrigem();
            }
        }

    }
}
