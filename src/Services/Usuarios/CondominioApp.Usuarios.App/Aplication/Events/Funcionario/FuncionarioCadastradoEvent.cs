using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioCadastradoEvent : FuncionarioEvent
    {        
        public FuncionarioCadastradoEvent(Guid id, Guid usuarioId, Guid condominioId, string nomeCondominio, 
            string atribuicao = null, string funcao = null, Permissao permissao = Permissao.USUARIO)
        {
            Id = id;
            UsuarioId = usuarioId;            

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            Atribuicao = atribuicao;
            Funcao = funcao;
            Permissao = permissao;            
                        
        }
    }
}