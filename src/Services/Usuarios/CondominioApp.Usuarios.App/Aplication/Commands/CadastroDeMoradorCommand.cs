using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastroDeMoradorCommand : Command
    {
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public Cpf Cpf { get; private set; }

        public Telefone Cel { get; private set; }

        public Telefone Telefone { get; private set; }

        public Email Email { get; private set; }

        public Foto Foto { get; private set; }

        public TipoDeUsuario TpUsuario { get; private set; }

        public Permissao Permissao { get; private set; }

        public bool Ativo { get; private set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public DateTime? DataNascimento { get; private set; }

        public CadastroDeMoradorCommand(string nome, string sobrenome, string rg, string cpf, string cel, string telefone, 
            string email, string foto, string NomeOriginal, TipoDeUsuario tpUsuario, Permissao permissao, bool ativo, string atribuicao, string funcao, DateTime? dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            TpUsuario = tpUsuario;
            Permissao = permissao;
            Ativo = ativo;
            Atribuicao = atribuicao;
            Funcao = funcao;
            DataNascimento = dataNascimento;

            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
        }
    }
}