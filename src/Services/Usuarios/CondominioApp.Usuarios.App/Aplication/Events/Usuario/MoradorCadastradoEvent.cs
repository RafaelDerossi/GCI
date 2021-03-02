using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorCadastradoEvent : UsuarioEvent
    {        
        public MoradorCadastradoEvent(Guid id, Guid usuarioId, string nome, string sobrenome, Email email,
            Guid condominioId, string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, Foto foto, string rg = null, Cpf cpf = null, Telefone cel = null, Telefone tel = null,
            bool proprietario = false, bool principal = false, Endereco endereco = null, DateTime? dataNascimento = null)
        {
            Id = id;
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            Proprietario = proprietario;
            Principal = principal;            
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