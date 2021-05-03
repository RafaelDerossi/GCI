using CondominioApp.Core.DomainObjects;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.FlatModel
{
    public class MoradorFlat : IAggregateRoot
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid UsuarioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }

        public bool Proprietario { get; private set; }

        public bool Principal { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public string Cpf { get; private set; }

        public string Cel { get; private set; }

        public string Telefone { get; private set; }

        public string Email { get; private set; }

        public string Foto { get; private set; }      



        public bool Ativo { get; private set; }

        public DateTime? DataNascimento { get; private set; }
        

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }      



        public MoradorFlat()
        {
        }

        public MoradorFlat
            (Guid id, Guid usuarioId, Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade,
            Guid condominioId, string nomeCondominio, bool proprietario, bool principal, string nome, string sobrenome, 
            string rg, string cpf, string cel, string telefone, string email, string foto,
            DateTime? dataNascimento, string logradouro, string complemento, string numero, string cep, string bairro,
            string cidade, string estado)
        {
            Id = id;            
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Proprietario = proprietario;
            Principal = principal;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;            
            Ativo = true;
            DataNascimento = dataNascimento;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }


        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;


        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;        

        

        public void SetNome(string nome) => Nome = nome;

        public void SetSobrenome(string sobrenome) => Sobrenome = sobrenome;

        public void SetRg(string rg) => Rg = rg;

        public void SetCpf(Cpf cpf)
        {
            if (cpf != null)
                Cpf = cpf.Numero;
            else
                Cpf = "";
        }
        

        public void SetTelefone(Telefone telefone)
        {
            if (telefone != null)
                Telefone = telefone.Numero;
            else
                Telefone = "";
        }

        public void SetCelular(Telefone cel)
        {
            if (cel != null)
                Cel = cel.Numero;
            else
                Cel = "";
        }

        public void SetEmail(Email email)
        {
            if (email != null)
                Email = email.Endereco;
            else
                Email = "";
        }

        public void SetFoto(Foto foto)
        {
            if (foto != null)
                Foto = foto.NomeDoArquivo;
            else
                Foto = "";
        }

        public void SetEndereco(Endereco endereco)
        {
            Logradouro = endereco.logradouro;
            Complemento = endereco.complemento;
            Numero = endereco.numero;
            Cep = endereco.cep;
            Bairro = endereco.bairro;
            Cidade = endereco.cidade;
            Estado = endereco.estado;
        }
        


        public void MarcarComoPrincipal() => Principal = true;

        public void DesmarcarComoPrincipal() => Principal = false;

        public void MarcarComoProprietario() => Proprietario = true;

        public void DesmarcarComoProprietario() => Proprietario = false;

    }
}