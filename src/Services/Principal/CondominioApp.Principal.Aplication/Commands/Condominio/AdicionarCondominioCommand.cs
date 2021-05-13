using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AdicionarCondominioCommand : CondominioCommand
    {        

        public AdicionarCondominioCommand(string cnpj, string nome, string descricao, string logoMarca,
            string nomeOriginal, string telefone, string logradouro, string complemento, string numero,
            string cep, string bairro, string cidade, string estado, int? refereciaId, string linkGeraBoleto,
            string boletoFolder, string urlWebServer, bool portaria, bool portariaMorador, bool classificado,
            bool classificadoMorador, bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
            bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
            bool correspondenciaNaPortaria, bool limiteTempoReserva,
            DateTime DataAssinaturaContrato, TipoDePlano TipoDePlano, string descricaoContrato, 
            bool contratoAtivo, string LinkContrato)
        {                    
            Nome = nome;
            Descricao = descricao;          
            RefereciaId = refereciaId;
            LinkGeraBoleto = linkGeraBoleto;
            Portaria = portaria;
            BoletoFolder = boletoFolder;            
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

            SetCNPJ(cnpj);
            SetFoto(logoMarca, nomeOriginal);
            SetTelefone(telefone);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);
            SetUrlWebServer(urlWebServer);

            SetContrato(DataAssinaturaContrato, TipoDePlano, descricaoContrato, contratoAtivo, LinkContrato);
            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarCondominioCommandValidation : CondominioValidation<AdicionarCondominioCommand>
        {
            public AdicionarCondominioCommandValidation()
            {               
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
