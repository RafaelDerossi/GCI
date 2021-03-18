using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public abstract class OcorrenciaCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public Foto Foto { get; protected set; }
        public bool Publica { get; protected set; }


        public bool EmAndamento { get; protected set; }
        public DateTime? DataResposta { get; protected set; }
        public bool Resolvida { get; protected set; }
        public string Parecer { get; protected set; }
        public DateTime? DataResolucao { get; protected set; }

        public Guid UnidadeId { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public Guid CondominioId { get; protected set; }

        public bool Panico { get; protected set; }

        public bool TemAnexo { get; protected set; }


        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetUsuarioId(Guid id) => UsuarioId = id;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;



        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;


        public void MarcarComoOcorrenciaDePanico() => Panico = true;

        public void DesmarcarComoOcorrenciaDePanico() => Panico = false;


        public void ColocarEmAndamento()
        {
            Resolvida = false;
            Parecer = "";
            EmAndamento = true;
            DataResposta = DataHoraDeBrasilia.Get();
        }

        public void MarcarComoResolvida(string parecer)
        {
            EmAndamento = false;
            Resolvida = true;
            Parecer = parecer;
            DataResolucao = DataHoraDeBrasilia.Get();
        }


        public void MarcarQueTemAnexo() => TemAnexo = true;

        public void MarcarQueNaoTemAnexo() => TemAnexo = false;
    }
}
