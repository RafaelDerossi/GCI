using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtualizarUsuarioCommand : UsuarioCommand
    {

        public AtualizarUsuarioCommand(Guid usuarioId, string nome, string sobrenome,
            string rg = null, string cpf = null, string foto = null, string nomeOriginal = null,
            string cel = null, string tel = null, string logradouro = null, string complemento = null,
            string numero = null, string cep = null, string bairro = null, string cidade = null,
            string estado = null, DateTime ? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;
            
            Permissao = Permissao.USUARIO;
            
            SetCpf(cpf);
            SetFoto(foto, nomeOriginal);
            SetTelefone(tel);
            SetCelular(cel);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);
        }
        
        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        

        public class AtualizarUsuarioCommandValidation : UsuarioValidation<AtualizarUsuarioCommand>
        {
            public AtualizarUsuarioCommandValidation()
            {
                ValidateId();
                ValidateNome();                       
            }
        }
    }
}