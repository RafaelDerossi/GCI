using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public abstract class CorrespondenciaCommand : Command
    {
        public Guid CorrespondenciaId { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string Grupo { get; protected set; }

        public bool Visto { get; private set; }

        public string NomeRetirante { get; protected set; }

        public string Observacao { get; protected set; }

        public DateTime? DataDaRetirada { get; protected set; }

        public Guid FuncionarioId { get; protected set; }

        public string NomeFuncionario { get; protected set; }

        public Foto FotoCorrespondencia { get; protected set; }

        public string NumeroRastreamentoCorreio { get; protected set; }

        public DateTime DataDeChegada { get; protected set; }

        public int QuantidadeDeAlertasFeitos { get; protected set; }

        public string TipoDeCorrespondencia { get; protected set; }

        public StatusCorrespondencia Status { get; protected set; }

        public string CodigoDeVerificacao { get; protected set; }

        public Foto FotoRetirante { get; protected set; }

        public Foto AssinaturaDigital { get; protected set; }



        public void SetFotoCorrespondencia(string nomeOriginal)
        {
            try
            {
                FotoCorrespondencia = new Foto(nomeOriginal);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

        public void SetStatus(StatusCorrespondencia status)
        {
            if (status == StatusCorrespondencia.RETIRADO)
            {
                SetRetirado();
            }
            else if(status == StatusCorrespondencia.DEVOLVIDO)
            {
                SetDevolvido();
            }
            else
            {
                SetPendente();
            }
        }

        public void SetPendente() => Status = StatusCorrespondencia.PENDENTE;

        public void SetRetirado() => Status = StatusCorrespondencia.RETIRADO;

        public void SetDevolvido() => Status = StatusCorrespondencia.DEVOLVIDO;

        public void SetCondominio(Guid id)
        {
            CondominioId = id;
        }

        public void SetUnidade(Guid id, string numero, string grupo)
        {
            UnidadeId = id;
            NumeroUnidade = numero;
            Grupo = grupo;
        }

        public void SetFuncionario(Guid id, string nomeFuncionario)
        {
            FuncionarioId = id;
            NomeFuncionario = nomeFuncionario;
        }

        public void SetDataDeChegada(DateTime data)
        {
            if (data > DataHoraDeBrasilia.Get())
            {
                AdicionarErrosDeProcessamentoDoComando("Data de Chegada deve ser anterior a data-hora atual.");
                return;
            }               

            DataDeChegada = data;
        }

        public void SetDataDeRetirada(DateTime? data)
        {
            if (data != null && data > DataHoraDeBrasilia.Get())
            {
                AdicionarErrosDeProcessamentoDoComando("Data de Retirada deve ser anterior a data-hora atual.");
                return;
            }

            DataDaRetirada = data;
        }
    }
}
