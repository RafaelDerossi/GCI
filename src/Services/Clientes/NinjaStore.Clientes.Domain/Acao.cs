using GCI.Core.DomainObjects;

namespace GCI.Acoes.Domain
{
    public class Acao : Entity, IAggregateRoot
    {
        public string Codigo { get; private set; }        

        public string RazaoSocial { get; private set; }

        protected Acao()
        {
        }

        public Acao(string codigo, string razaoSocial)
        {
            Codigo = codigo;
            RazaoSocial = razaoSocial;
        }

        public void SetCodigo(string codigo) => Codigo = codigo;        

        public void SetRazaoSocial(string razaoSocial) => RazaoSocial = razaoSocial;
    }
}
