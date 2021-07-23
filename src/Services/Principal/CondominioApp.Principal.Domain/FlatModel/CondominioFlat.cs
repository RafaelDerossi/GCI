using System;
using System.Collections.Generic;
using System.Text;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Principal.Domain.ValueObjects;

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

        public string NomeArquivoLogo { get; private set; }        

        public string NomeOriginalArquivoLogo { get; private set; }

        public string UrlArquivoLogo
        {
            get
            {
                if (NomeArquivoLogo == null || NomeArquivoLogo == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(Id.ToString(), NomeArquivoLogo);
            }
        }

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

        public Guid FuncionarioIdDoSindico { get; private set; }

        public string NomeDoSindico { get; private set; }

        public bool PortariaAtivada { get; private set; }
       
        public bool PortariaParaMoradorAtivada { get; private set; }

        public bool ClassificadoAtivado { get; private set; }

        public bool ClassificadoParaMoradorAtivado { get; private set; }

        public bool MuralAtivado { get; private set; }

        public bool MuralParaMoradorAtivado { get; private set; }

        public bool ChatAtivado { get; private set; }

        public bool ChatParaMoradorAtivado { get; private set; }

        public bool ReservaAtivada { get; private set; }

        public bool ReservaNaPortariaAtivada { get; private set; }

        public bool OcorrenciaAtivada { get; private set; }

        public bool OcorrenciaParaMoradorAtivada { get; private set; }
        
        public bool CorrespondenciaAtivada { get; private set; }

        public bool CorrespondenciaNaPortariaAtivada { get; private set; }

        public bool CadastroDeVeiculoPeloMoradorAtivado { get; private set; }


        public Guid ContratoId { get; private set; }

        public DateTime DataAssinaturaContrato { get; private set; }

        public TipoDePlano TipoPlano { get; private set; }

        public string TipoPlanoDescricao
        {
            get
            {
                return TipoPlano switch
                {
                    TipoDePlano.FREE => "Free",
                    TipoDePlano.STANDARD => "Standard",
                    TipoDePlano.PREMIUM => "Premium",
                    _ => "Não Informado",
                };
            }
        }

        public string DescricaoContrato { get; private set; }

        public bool ContratoAtivo { get; private set; }

        public int QuantidadeDeUnidadesContratadas { get; private set; }

        public string NomeArquivoContrato { get; private set; }

        public string NomeOriginalArquivoContrato { get; private set; }

        public string UrlArquivoContrato
        {
            get
            {
                if (NomeArquivoContrato == null || NomeArquivoContrato == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(Id.ToString(), NomeArquivoContrato);
            }
        }



        protected CondominioFlat() { }

        public CondominioFlat(Guid id, bool lixeira, 
            string cnpj, string nome, string descricao, Foto logoMarca, 
            string telefone, string logradouro, string complemento, string numero, string cep, 
            string bairro, string cidade, string estado, bool portariaAtivada, bool portariaParaMoradorAtivada,
            bool classificadoAtivado, bool classificadoParaMoradorAtivado, bool muralAtivado,
            bool muralParaMoradorAtivado, bool chatAtivado, bool chatParaMoradorAtivado, bool reservaAtivada,
            bool reservaNaPortariaAtivado, bool ocorrenciaAtivada, bool ocorrenciaParaMoradorAtivada,
            bool correspondenciaAtivada, bool correspondenciaNaPortariaAtivada,
            bool cadastroDeVeiculoPeloMoradorAtivado, Guid contratoId, DateTime dataAssinaturaContrato,
            TipoDePlano tipoPlano, string descricaoContrato, bool contratoAtivo, NomeArquivo arquivoContrato)
        {
            Id = id;
            Lixeira = lixeira; 
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            SetLogo(logoMarca);
            Telefone = telefone;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;           
            PortariaAtivada = portariaAtivada;
            PortariaParaMoradorAtivada = portariaParaMoradorAtivada;
            ClassificadoAtivado = classificadoAtivado;
            ClassificadoParaMoradorAtivado = classificadoParaMoradorAtivado;
            MuralAtivado = muralAtivado;
            MuralParaMoradorAtivado = muralParaMoradorAtivado;
            ChatAtivado = chatAtivado;
            ChatParaMoradorAtivado = chatParaMoradorAtivado;
            ReservaAtivada = reservaAtivada;
            ReservaNaPortariaAtivada = reservaNaPortariaAtivado;
            OcorrenciaAtivada = ocorrenciaAtivada;
            OcorrenciaParaMoradorAtivada = ocorrenciaParaMoradorAtivada;
            CorrespondenciaAtivada = correspondenciaAtivada;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortariaAtivada;
            CadastroDeVeiculoPeloMoradorAtivado = cadastroDeVeiculoPeloMoradorAtivado;
            ContratoId = contratoId;
            DataAssinaturaContrato = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;
            ContratoAtivo = contratoAtivo;
            SetArquivoContrato(arquivoContrato);
        }


        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;        

        public void SetCNPJ(string cnpj) => Cnpj = cnpj;

        public void SetNome(string nome) => Nome = nome;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetLogo(Foto logo)
        {
            if (logo != null)
            {
                NomeArquivoLogo = logo.NomeDoArquivo;
                NomeOriginalArquivoLogo = logo.NomeOriginal;
            }                
        }

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


        public void SetArquivoContrato(NomeArquivo arquivo)
        {            
            if (arquivo != null)
            {
                NomeArquivoContrato = arquivo.NomeDoArquivo;
                NomeOriginalArquivoContrato = arquivo.NomeOriginal;
            }
            
        }

        public void SetSindico(Guid id, string nome)
        {
            FuncionarioIdDoSindico = id;
            NomeDoSindico = nome;
        }

        ///Métodos de Parametros

        /// <summary>
        /// Portaria
        /// </summary>
        public void AtivarPortaria() => PortariaAtivada = true;
        public void DesativarPortaria() => PortariaAtivada = false;
        public void AtivarPortariaMorador() => PortariaParaMoradorAtivada = true;
        public void DesativarPortariaMorador() => PortariaParaMoradorAtivada = false;


        /// <summary>
        /// Classificado
        /// </summary>
        public void AtivarClassificado() => ClassificadoAtivado = true;
        public void DesativarClassificado() => ClassificadoAtivado = false;
        public void AtivarClassificadoMorador() => ClassificadoParaMoradorAtivado = true;
        public void DesativarClassificadoMorador() => ClassificadoParaMoradorAtivado = false;

        /// <summary>
        /// Mural
        /// </summary>
        public void AtivarMural() => MuralAtivado = true;
        public void DesativarMural() => MuralAtivado = false;
        public void AtivarMuralMorador() => MuralParaMoradorAtivado = true;
        public void DesativarMuralMorador() => MuralParaMoradorAtivado = false;


        /// <summary>
        /// Chat
        /// </summary>
        public void AtivarChat() => ChatAtivado = true;
        public void DesativarChat() => ChatAtivado = false;
        public void AtivarChatMorador() => ChatParaMoradorAtivado = true;
        public void DesativarChatMorador() => ChatParaMoradorAtivado = false;

        /// <summary>
        /// Reserva
        /// </summary>
        public void AtivarReserva() => ReservaAtivada = true;
        public void DesativarReserva() => ReservaAtivada = false;
        public void AtivarReservaNaPortaria() => ReservaNaPortariaAtivada = true;
        public void DesativarReservaNaPortaria() => ReservaNaPortariaAtivada = false;

        /// <summary>
        /// Ocorrencia
        /// </summary>
        public void AtivarOcorrencia() => OcorrenciaAtivada = true;
        public void DesativarOcorrencia() => OcorrenciaAtivada = false;
        public void AtivarOcorrenciaMorador() => OcorrenciaParaMoradorAtivada = true;
        public void DesativarOcorrenciaMorador() => OcorrenciaParaMoradorAtivada = false;

        /// <summary>
        /// Correspondencia
        /// </summary>
        public void AtivarCorrespondencia() => CorrespondenciaAtivada = true;
        public void DesativarCorrespondencia() => CorrespondenciaAtivada = false;
        public void AtivarCorrespondenciaNaPortaria() => CorrespondenciaNaPortariaAtivada = true;
        public void DesativarCorrespondenciaNaPortaria() => CorrespondenciaNaPortariaAtivada = false;

        /// <summary>
        /// Cadastro de Veiculo pelo morador
        /// </summary>
        public void AtivarCadastroDeVeiculoPeloMorador() => CadastroDeVeiculoPeloMoradorAtivado = true;
        public void DesativarCadastroDeVeiculoPeloMorador() => CadastroDeVeiculoPeloMoradorAtivado = false;



    }
}
