using System;
using System.Collections.Generic;

namespace CondominioApp.Usuarios.App.ViewModels
{
    public class UsuarioViewModel
    {
        public const int Max = 200;

        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Celular { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public string NomeOriginal { get; set; }

        public string TpUsuario { get; set; }        
      
        public DateTime? DataNascimento { get; set; }

        public DateTime? UltimoLogin { get; set; }

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public bool SindicoProfissional { get; set; }

        
        public IEnumerable<MobileViewModel> Mobiles;


        public string NomeCompleto
        {
            get { return $"{Nome} {Sobrenome}"; }
        }


    }
}