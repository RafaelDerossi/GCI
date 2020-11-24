using CondominioApp.Core.DomainObjects;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain
{
   public class Unidade:Entity
    {
        public const int Max = 200;
        public string Codigo { get; private set; }
        public string Numero { get; private set; }
        public string Andar { get; private set; }
        public int Vagas { get; private set; }
        public Telefone Telefone { get; private set; }
        public string Ramal { get; private set; }
        public string Complemento { get; private set; }      
        public Guid GrupoId { get; private set; }
        public Grupo Grupo { get; protected set; }               
        public Guid CondominioId { get; private set; }
        public Condominio Condominio { get; protected set; }

        
        /// <summary>
        /// Construtores
        /// </summary>
        protected Unidade()
        {
        }

        public Unidade(string numero, string andar, int vagas, 
            Telefone telefone, string ramal, string complemento, Guid grupoId, Guid condominioId, string codigo = null)
        {
            Numero = numero;
            Andar = andar;
            Vagas = vagas;
            Telefone = telefone;
            Ramal = ramal;
            Complemento = complemento;
            GrupoId = grupoId;
            CondominioId = condominioId;

            Codigo = codigo;

            if (string.IsNullOrEmpty(codigo)) ResetCodigo();
        }


        /// <summary>
        /// Metodos       
        /// </summary>

        public void ResetCodigo()
        {
           Codigo = Id.ToString().Substring(0, 4) + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
        }
        

        public void SetNumero(string numero) => this.Numero = numero;

        public void SetAndar(string andar) => this.Andar = andar;
       
        public void SetGrupoId(Guid Id) => this.GrupoId = Id;

        public void SetCondominioId(Guid Id) => this.CondominioId = Id;      

        public void SetVagas(int vagas) => Vagas = vagas;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetRamal(String ramal) => Ramal = ramal;

        public void SetComplemento(String complemento) => Complemento = complemento;


        /// <summary>
        /// Retorna o Código do Apartamento, número do Apartamento e o Grupo Separados por '|'
        /// </summary>
        /// <returns></returns>
        /// 
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Codigo) && string.IsNullOrEmpty(Numero) && Grupo != null)
                return Codigo + "|" + Numero.ToString() + "|" + Grupo.Descricao + "|" + Andar;

            return " | | ";
        }
     
        
    }
}
