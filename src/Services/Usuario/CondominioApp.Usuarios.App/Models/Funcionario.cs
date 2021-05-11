using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.Models
{
   public class Funcionario : Entity
    {
        public Guid UsuarioId { get; private set; }        

        public Guid CondominioId { get; private set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public Permissao Permissao { get; private set; }

        public bool Ativo { get; private set; }


        public Funcionario(Guid usuarioId, Guid condominioId, string atribuicao, string funcao, Permissao permissao)
        {
            UsuarioId = usuarioId;
            CondominioId = condominioId;
            Atribuicao = atribuicao;
            Funcao = funcao;
            Permissao = permissao;

            Ativar();
        }



        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;        

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetAtribuicao(string atribuicao) => Atribuicao = atribuicao;

        public void SetFuncao(string funcao) => Funcao = funcao;

        public void SetPermissao(Permissao permissao) => Permissao = permissao;

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

    }
}
