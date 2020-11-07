using System;
using System.Collections.Generic;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.ValueObjects;

namespace CondominioApp.Usuarios.App.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public const int Max = 200;

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

        public DateTime? UltimoLogin { get; private set; }

        public Endereco Endereco { get; set; }

        public bool SindicoProfissional { get; private set; }

        //EF
        private readonly List<Mobile> _Mobiles;

        public IReadOnlyCollection<Mobile> Mobiles => _Mobiles;

        protected Usuario() { }

        public Usuario(string nome, string sobrenome, string rg, Telefone cel, Email email, 
            Foto foto, TipoDeUsuario tpUsuario, Permissao permissao, DateTime? dataNascimento = null, Cpf cpf = null, string atribuicao = null, string funcao = null, 
            Telefone telefone = null, Endereco endereco = null, bool sindicoProfissional = false)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
            TpUsuario = tpUsuario;
            Permissao = permissao;
            Atribuicao = atribuicao;
            Funcao = funcao;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            SindicoProfissional = sindicoProfissional;

            Ativar();
        }

        public string NomeCompleto
        {
            get { return $"{Nome} {Sobrenome}"; }
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AtivarSindicoProfissional() => SindicoProfissional = true;

        public void DesativarSindicoProfissional() => SindicoProfissional = false;

        public void AtualizarUltimoLogin() => UltimoLogin = DateTime.UnixEpoch;

        public void SetNome(string nome) => Nome = nome;

        public void SetSobrenome(string sobrenome) => Sobrenome = sobrenome;

        public void SetRg(string rg) => Rg = rg;

        public void SetCpf(Cpf cpf) => Cpf = cpf;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetCelular(Telefone cel) => Cel = cel;

        public void SetEmail(Email email) => Email = email;

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetTipoDeUsuario(TipoDeUsuario tipoDeUsuario) => TpUsuario = tipoDeUsuario;

        public void SetPermissao(Permissao permissao) => Permissao = permissao;

        public void AdicionarMobile(Mobile mobile)
        {
            _Mobiles.Add(mobile);
        }
    }
}