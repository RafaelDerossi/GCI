using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
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

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }

        public TipoDeUsuario TpUsuario { get; protected set; }

        public Permissao Permissao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

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
    }
}
