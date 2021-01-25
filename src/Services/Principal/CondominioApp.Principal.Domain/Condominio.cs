using CondominioApp.Core.DomainObjects;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;

namespace CondominioApp.Principal.Domain
{
    public class Condominio : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public Cnpj Cnpj { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Foto LogoMarca { get; private set; }

        public Telefone Telefone { get; private set; }

        public Endereco Endereco { get; private set; }

        /// Referencia Externa
        /// <summary>
        /// Id de referencia externa do condominio
        /// </summary>
        public int? RefereciaId { get; private set; }

        public string LinkGeraBoleto { get; private set; }

        public string BoletoFolder { get; private set; }

        public Url UrlWebServer { get; private set; }



        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool Portaria { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaMorador { get; private set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool Classificado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoMorador { get; private set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool Mural { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralMorador { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool Chat { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatMorador { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool Reserva { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortaria { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool Ocorrencia { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaMorador { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool Correspondencia { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortaria { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Limite de Tempo na Reserva
        /// </summary>
        public bool LimiteTempoReserva { get; private set; }




        private readonly List<Grupo> _Grupos;
        public IReadOnlyCollection<Grupo> Grupos => _Grupos;


        private readonly List<Unidade> _Unidades;
        public IReadOnlyCollection<Unidade> Unidades => _Unidades;


        private readonly List<Contrato> _Contratos;
        public IReadOnlyCollection<Contrato> Contratos => _Contratos;



        /// <summary>
        /// Construtores
        /// </summary>
        protected Condominio()
        {
            _Grupos = new List<Grupo>();
            _Unidades = new List<Unidade>();
            _Contratos = new List<Contrato>();

        }

        public Condominio(Cnpj cnpj, string nome, string descricao, Foto logoMarca,
            Telefone telefone, Endereco endereco, int? refereciaId, string linkGeraBoleto, string boletoFolder,
            Url urlWebServer, bool portaria, bool portariaMorador, bool classificado,
            bool classificadoMorador, bool mural, bool muralMorador, bool chat, bool
            chatMorador, bool reserva, bool reservaNaPortaria, bool ocorrencia,
            bool ocorrenciaMorador, bool correspondencia, bool correspondenciaNaPortaria,
            bool limiteTempoReserva)
        {
            _Grupos = new List<Grupo>();
            _Unidades = new List<Unidade>();
            _Contratos = new List<Contrato>();

            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Endereco = endereco;
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
        }




        ///Metodos Set

        public void SetCNPJ(Cnpj cnpj) => Cnpj = cnpj;

        public void SetNome(string nome) => Nome = nome;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(Foto logo) => LogoMarca = logo;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetEndereco(Endereco endereco) => Endereco = endereco;


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


        /// Metodos 
        public ValidationResult AdicionarGrupo(Grupo grupo)
        {
            if (_Grupos.Any(g => g.Descricao.Trim().ToUpper() == grupo.Descricao.Trim().ToUpper()))
            {
                AdicionarErrosDaEntidade("Já existe um grupo com esta descrição no condomínio!");
                return ValidationResult;
            }

            _Grupos.Add(grupo);
            return ValidationResult;
        }

        public ValidationResult AlterarGrupo(Grupo grupo)
        {
            if (_Grupos.Any(g => g.Descricao.Trim().ToUpper() == grupo.Descricao.Trim().ToUpper() && g.Id != grupo.Id))
            {
                AdicionarErrosDaEntidade("Já existe um grupo com esta descrição no condomínio!");
                return ValidationResult;
            }

            //var GrupoObtido = _Grupos.FirstOrDefault(u => u.Id == grupo.Id);

            //_Grupos.Remove(GrupoObtido);

            //GrupoObtido.SetDescricao(grupo.Descricao);

            //_Grupos.Add(GrupoObtido);


            _Grupos.Remove(grupo);
            _Grupos.Add(grupo);

            return ValidationResult;
        }


        public ValidationResult AdicionarContrato(Contrato contrato)
        {
            _Contratos.Add(contrato);
            return ValidationResult;
        }

    }
}
