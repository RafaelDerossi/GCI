using System;
using System.Collections.Generic;
using System.Text;
using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class CondominioFlat : IAggregateRoot
   {
        public const int Max = 200;
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Cnpj { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string LogoMarca { get; private set; }

        public string Telefone { get; private set; }

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }
        

       
        public int? RefereciaId { get; private set; }

        public string LinkGeraBoleto { get; private set; }

        public string BoletoFolder { get; private set; }

        public string UrlWebServer { get; private set; }
        


        public bool Portaria { get; private set; }
       
        public bool PortariaMorador { get; private set; }

        public bool Classificado { get; private set; }

        public bool ClassificadoMorador { get; private set; }

        public bool Mural { get; private set; }

        public bool MuralMorador { get; private set; }

        public bool Chat { get; private set; }

        public bool ChatMorador { get; private set; }

        public bool Reserva { get; private set; }

        public bool ReservaNaPortaria { get; private set; }

        public bool Ocorrencia { get; private set; }

        public bool OcorrenciaMorador { get; private set; }
        
        public bool Correspondencia { get; private set; }

        public bool CorrespondenciaNaPortaria { get; private set; }

        public bool LimiteTempoReserva { get; private set; }

        public DateTime DataAssinaturaContrato { get; private set; }

        public string TipoPlano { get; private set; }

        public string LinkContrato { get; private set; }

        public bool ContratoAtivo { get; private set; }


        protected CondominioFlat() { }

        public CondominioFlat(Guid id, bool lixeira, 
            string cnpj, string nome, string descricao, string logoMarca, 
            string telefone, string logradouro, string complemento, string numero, string cep, 
            string bairro, string cidade, string estado, int? refereciaId, string linkGeraBoleto, 
            string boletoFolder, string urlWebServer, bool portaria, bool portariaMorador, bool classificado,
            bool classificadoMorador, bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
            bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
            bool correspondenciaNaPortaria, bool limiteTempoReserva, DateTime dataAssinaturaContrato,
            string tipoPlano, string linkContrato, bool contratoAtivo)
        {
            Id = id;
            Lixeira = lixeira; 
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            RefereciaId = refereciaId;
            LinkGeraBoleto = linkGeraBoleto;
            BoletoFolder = boletoFolder;
            UrlWebServer = urlWebServer;
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
            DataAssinaturaContrato = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            LinkContrato = linkContrato;
            ContratoAtivo = contratoAtivo;

        }


        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;        

        public void SetCNPJ(string cnpj) => Cnpj = cnpj;

        public void SetNome(string nome) => Nome = nome;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(string logo) => LogoMarca = logo;

        public void SetTelefone(string telefone) => Telefone = telefone;

        public void SetEndereco(string logradouro, string complemento, string numero,
            string cep, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }


        ///Métodos de Parametros

        /// <summary>
        /// Portaria
        /// </summary>
        public void AtivarPortaria() => Portaria = true;
        public void DesativarPortaria() => Portaria = false;
        public void AtivarPortariaMorador() => PortariaMorador = true;
        public void DesativarPortariaMorador() => PortariaMorador = false;


        /// <summary>
        /// Classificado
        /// </summary>
        public void AtivarClassificado() => Classificado = true;
        public void DesativarClassificado() => Classificado = false;
        public void AtivarClassificadoMorador() => ClassificadoMorador = true;
        public void DesativarClassificadoMorador() => ClassificadoMorador = false;

        /// <summary>
        /// Mural
        /// </summary>
        public void AtivarMural() => Mural = true;
        public void DesativarMural() => Mural = false;
        public void AtivarMuralMorador() => MuralMorador = true;
        public void DesativarMuralMorador() => MuralMorador = false;


        /// <summary>
        /// Chat
        /// </summary>
        public void AtivarChat() => Chat = true;
        public void DesativarChat() => Chat = false;
        public void AtivarChatMorador() => ChatMorador = true;
        public void DesativarChatMorador() => ChatMorador = false;

        /// <summary>
        /// Reserva
        /// </summary>
        public void AtivarReserva() => Reserva = true;
        public void DesativarReserva() => Reserva = false;
        public void AtivarReservaNaPortaria() => ReservaNaPortaria = true;
        public void DesativarReservaNaPortaria() => ReservaNaPortaria = false;

        /// <summary>
        /// Ocorrencia
        /// </summary>
        public void AtivarOcorrencia() => Ocorrencia = true;
        public void DesativarOcorrencia() => Ocorrencia = false;
        public void AtivarOcorrenciaMorador() => OcorrenciaMorador = true;
        public void DesativarOcorrenciaMorador() => OcorrenciaMorador = false;

        /// <summary>
        /// Correspondencia
        /// </summary>
        public void AtivarCorrespondencia() => Correspondencia = true;
        public void DesativarCorrespondencia() => Correspondencia = false;
        public void AtivarCorrespondenciaNaPortaria() => CorrespondenciaNaPortaria = true;
        public void DesativarCorrespondenciaNaPortaria() => CorrespondenciaNaPortaria = false;

        /// <summary>
        /// LimiteTempoReserva
        /// </summary>
        public void AtivarLimiteTempoReserva() => LimiteTempoReserva = true;
        public void DesativarLimiteTempoReserva() => LimiteTempoReserva = false;
    }
}
