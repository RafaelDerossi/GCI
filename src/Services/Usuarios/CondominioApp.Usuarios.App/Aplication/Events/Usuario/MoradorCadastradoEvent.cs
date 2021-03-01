using System;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorCadastradoEvent : UsuarioEvent
    {        
        public MoradorCadastradoEvent(Guid usuarioId, string nome, string sobrenome, string email,
            string rg, string cpf, string cel, string telefone, string foto, bool ativo, Guid unidadeId, 
            Guid condominioId, bool proprietario, bool principal, DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
            Proprietario = proprietario;
            Principal = principal;
            Ativo = ativo;
            TpUsuario = TipoDeUsuario.MORADOR.ToString(); 

            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
        }
    }
}