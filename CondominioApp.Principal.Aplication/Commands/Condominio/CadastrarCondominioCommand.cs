using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;


namespace CondominioApp.Principal.Aplication.Commands
{
   public class CadastrarCondominioCommand : CondominioCommand
    {

        public CadastrarCondominioCommand(string cnpj, string nome, string descricao = null, string logoMarca = null,
            string nomeOriginal = null, string telefone = null, int? refereciaId = 0, string linkGeraBoleto = null,
            string boletoFolder = null, string urlWebServer = null, bool portaria = false, bool portariaMorador = false,
            bool classificado = false, bool classificadoMorador = false, bool mural = false, bool muralMorador = false,
            bool chat = false, bool chatMorador = false, bool reserva = false, bool reservaNaPortaria = false,
            bool ocorrencia = false, bool ocorrenciaMorador = false, bool correspondencia = false,
            bool correspondenciaNaPortaria = false, bool limiteTempoReserva = false)
        {
            Cnpj = new Cnpj(cnpj);
            Nome = nome;
            Descricao = descricao;
            LogoMarca = new Foto(nomeOriginal,logoMarca);
            Telefone = new Telefone(telefone);
            RefereciaId = refereciaId;
            LinkGeraBoleto = linkGeraBoleto;
            BoletoFolder = boletoFolder;
            UrlWebServer = new Url(urlWebServer);
            Portaria = portaria;
            PortariaMorador = portariaMorador;
            Classificado = classificado;
            ClassificadoMorador = classificadoMorador;
            Mural = mural;
            MuralMorador = muralMorador;
            Chat = chat;
            ChatMorador = chatMorador;
            Reserva = reserva;
            ReservaNaPortaria = reservaNaPortaria;
            Ocorrencia = ocorrencia;
            OcorrenciaMorador = ocorrenciaMorador;
            Correspondencia = correspondencia;
            CorrespondenciaNaPortaria = correspondenciaNaPortaria;
            LimiteTempoReserva = limiteTempoReserva;
        }


        public override bool EstaValido()
        {
            ValidationResult = new CadastrarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarCondominioCommandValidation : CondominioValidation<CadastrarCondominioCommand>
        {
            public CadastrarCondominioCommandValidation()
            {               
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
