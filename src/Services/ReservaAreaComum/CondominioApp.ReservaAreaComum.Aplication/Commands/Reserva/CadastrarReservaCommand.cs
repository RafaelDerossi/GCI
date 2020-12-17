

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
            string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId, string nomeUsuario,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            bool estaNaFila, string origem, bool reservadoPelaAdministracao)
        {            
            AreaComumId = areaComumId;
            Observacao = observacao;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            DataDeRealizacao = dataDeRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Preco = preco;
            EstaNaFila = estaNaFila;
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
                ValidateUsuarioId();
                ValidateNomeUsuario();
                ValidateDataDeRealizacao();
                ValidateHoraInicio();
                ValidateHoraFim();               
                ValidatePreco();
                ValidateEstaNaFila();
                ValidateOrigem();
                ValidateReservadoPelaAdministracao();
            }
        }

    }
}
