using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public abstract class UsuarioCommand : Command
    {
        public Guid UsuarioId { get; protected set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public Cpf Cpf { get; protected set; }

        public Telefone Cel { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }

        public TipoDeUsuario TpUsuario { get; protected set; }

        public Permissao Permissao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }


        public Endereco Endereco { get; protected set; }
    
        public bool SindicoProfissional { get; protected set; }



        public void SetNome(string nome) => Nome = nome;

        public void SetSobrenome(string sobrenome) => Sobrenome = sobrenome;

        public void SetDataNascimento(DateTime dataNascimento) => DataNascimento = dataNascimento;


        public void SetCpf(string cpf)
        {
            try
            {
                Cpf = new Cpf(cpf);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetCelular(string cel)
        {
            try
            {
                Cel = new Telefone(cel);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetTelefone(string tel)
        {
            try
            {
                Telefone = new Telefone(tel);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetEmail(string email)
        {
            try
            {
                Email = new Email(email);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetFoto(string foto, string nomeOriginal)
        {
            try
            {
                Foto = new Foto(nomeOriginal, foto);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetEndereco
            (string logradouro, string complemento, string numero, string cep,
            string bairro, string cidade, string estado)
        {
            try
            {
                Endereco = new Endereco(logradouro, complemento, numero, cep, bairro, cidade, estado);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
    }
}
