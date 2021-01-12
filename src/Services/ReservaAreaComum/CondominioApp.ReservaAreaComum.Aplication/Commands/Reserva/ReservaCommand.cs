using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public abstract class ReservaCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid AreaComumId { get; protected set; }
        public string Observacao { get; protected set; }
        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public string NomeUsuario { get; protected set; }
        public DateTime DataDeRealizacao { get; protected set; }
        public string HoraInicio { get; protected set; }
        public string HoraFim { get; protected set; }
        public bool Ativa { get; protected set; }
        public decimal Preco { get; protected set; }
        public bool EstaNaFila { get; protected set; }
        public string Justificativa { get; protected set; }
        public string Origem { get; protected set; }
        public bool ReservadoPelaAdministracao { get; protected set; }


        public void SetAreaComumId(Guid id) => AreaComumId = id;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetNumeroUnidade(string numero) => NumeroUnidade = numero;

        public void SetAndarUnidade(string andar) => AndarUnidade = andar;

        public void SetGrupoUnidade(string grupo) => GrupoUnidade = grupo;

        public void SetUsuarioId(Guid id) => UsuarioId = id;

        public void SetNomeUsuario(string nome) => NomeUsuario = nome;

        public void SetHoraInicio(string hora) => HoraInicio = hora;

        public void SetHoraFim(string hora) => HoraFim = hora;


    }
}
