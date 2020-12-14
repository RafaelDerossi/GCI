

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CadastrarAreaComumCommand : AreaComumCommand
    {

        public CadastrarAreaComumCommand(
            string nome, string descricao, string termoDeUso, Guid condominioId, 
            string nomeCondominio, int capacidade, string diasPermitidos, int antecedenciaMaximaEmMeses,
            int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias,
            bool requerAprovacaoDeReserva, bool temHorariosEspecificos, bool temIntervaloFixoEntreReservas,
            string tempoDeIntervaloEntreReservas, bool ativa, string tempoDeDuracaoDeReserva, 
            int numeroLimiteDeReservaPorUnidade, DateTime? dataInicioBloqueio, DateTime? dataFimBloqueio,
            bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta, int numeroLimiteDeReservaSobrepostaPorUnidade,
            ICollection<Periodo> periodos)
        {           
            Nome = nome;
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Capacidade = capacidade;
            DiasPermitidos = diasPermitidos;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            TemIntervaloFixoEntreReservas = temIntervaloFixoEntreReservas;
            TempoDeIntervaloEntreReservas = tempoDeIntervaloEntreReservas;
            Ativa = ativa;
            TempoDeDuracaoDeReserva = tempoDeDuracaoDeReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            DataInicioBloqueio = dataInicioBloqueio;
            DataFimBloqueio = dataFimBloqueio;
            PermiteReservaSobreposta = permiteReservaSobreposta;
            NumeroLimiteDeReservaSobreposta = numeroLimiteDeReservaSobreposta;
            NumeroLimiteDeReservaSobrepostaPorUnidade = numeroLimiteDeReservaSobrepostaPorUnidade;
            Periodos = periodos;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarAreaComumCommandValidation :AreaComumValidation<CadastrarAreaComumCommand>
        {
            public CadastrarAreaComumCommandValidation()
            {               
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
