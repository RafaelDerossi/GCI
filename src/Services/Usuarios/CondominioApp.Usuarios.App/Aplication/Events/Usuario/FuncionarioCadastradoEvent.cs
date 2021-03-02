using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioCadastradoEvent : UsuarioEvent
    {        
        public FuncionarioCadastradoEvent(Guid usuarioId, string nome, string sobrenome, Email email,
            Guid condominioId, string nomeCondominio, Foto foto, string rg = null, Cpf cpf = null, Telefone cel = null,
            Telefone tel = null, string atribuicao = null, string funcao = null, bool sindicoProfissional = false,
            Endereco endereco = null, DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            Atribuicao = atribuicao;
            Funcao = funcao;
            SindicoProfissional = sindicoProfissional;
            
            TpUsuario = TipoDeUsuario.MORADOR; 

            Cpf = cpf;
            Cel = cel;
            Telefone = tel;
            Email = email;
            Foto = foto;
            Endereco = endereco;
                        
        }
    }
}