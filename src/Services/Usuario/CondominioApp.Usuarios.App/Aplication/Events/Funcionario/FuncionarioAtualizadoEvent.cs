using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioAtualizadoEvent : FuncionarioEvent
    {        
        public FuncionarioAtualizadoEvent(Guid id, string atribuicao = null, string funcao = null, Permissao permissao = Permissao.USUARIO)
        {
            Id = id;            
            Atribuicao = atribuicao;
            Funcao = funcao;
            Permissao = permissao;            
                        
        }
    }
}