using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public abstract class ComunicadoCommand : Command
    {
        public Guid ComunicadoId { get; protected set; }

        public string Titulo { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime? DataDeRealizacao { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; protected set; }

        public VisibilidadeComunicado Visibilidade { get; protected set; }

        public CategoriaComunicado Categoria { get; protected set; }

        public bool TemAnexos { get; protected set; }

        public bool CriadoPelaAdministradora { get; protected set; }

        public IEnumerable<UnidadeComunicado> Unidades { get; protected set; }



        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominio(Guid id, string nome)
        {
            CondominioId = id;
            NomeCondominio = nome;
        }

        public void SetCondominioId(Guid id)
        {
            CondominioId = id;
        }

        public void SetUsuario(Guid id, string nome)
        {
            UsuarioId = id;
            NomeUsuario = nome;
        }

        public void SetVisibilidade(VisibilidadeComunicado visibilidade) => Visibilidade = visibilidade;

        public void SetUnidades(IEnumerable<UnidadeComunicado> unidades)
        {
            Unidades = unidades;
        }
        

    }
}
