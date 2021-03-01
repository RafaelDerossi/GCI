using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEvent : Core.Messages.Event
    {
        public Guid UsuarioId { get; set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public string Cpf { get; protected set; }

        public string Cel { get; protected set; }

        public string Telefone { get; protected set; }

        public string Email { get; protected set; }

        public string Foto { get; protected set; }

        public bool Ativo { get; protected set; }

        public string TpUsuario { get; protected set; }

        public string Permissao { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }



        public void SetNome(string nome) => Nome = nome;

        public void SetCpf(string cpf) => Cpf = cpf;

        public void SetCelular(string cel) => Cel = cel;

        public void SetEmail(string email) => Email = email;            

        public void SetFoto(string foto)=> Foto = foto;

    }
}