using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.ValueObjects;
using System;


namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class CondominioCommand : Command
    {
        public Guid Id { get; protected set; }

        public Cnpj Cnpj { get; protected set; }      

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public Foto Logo { get; protected set; }       

        public Telefone Telefone { get; protected set; }

        public Endereco Endereco { get; protected set; }

       

        /// Referencia Externa
        /// <summary>
        /// Id de referencia externa do condominio
        /// </summary>
        public int? RefereciaId { get; protected set; }

        public string LinkGeraBoleto { get; protected set; }

        public string BoletoFolder { get; protected set; }

        public Url UrlWebServer { get; protected set; }

        public Guid FuncionarioIdDoSindico { get; protected set; }

        public string NomeDoSindico { get; protected set; }

        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool PortariaAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaParaMoradorAtivada { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool ClassificadoAtivado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoParaMoradorAtivado { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool MuralAtivado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralParaMoradorAtivado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool ChatAtivado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatParaMoradorAtivado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool ReservaAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortariaAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool OcorrenciaAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaParaMoradorAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool CorrespondenciaAtivada { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortariaAtivada { get; protected set; }

        public bool CadastroDeVeiculoPeloMoradorAtivado { get; protected set; }



        public Contrato Contrato { get; protected set; }    


        public void SetCNPJ(string cnpj)
        {
            try
            {
                Cnpj = new Cnpj(cnpj);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }            

        public void SetLogo(string nomeOriginal)
        {
            try
            {
                Logo = new Foto(nomeOriginal);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetTelefone(string telefone)
        {
            try
            {
                Telefone = new Telefone(telefone);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetEndereco(string logradouro, string complemento, string numero, 
            string cep, string bairro, string cidade, string estado)
        {
            try
            {
                Endereco = new Endereco(logradouro,complemento,numero,cep,bairro,cidade,estado);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetUrlWebServer(string url)
        {
            try
            {
                UrlWebServer = new Url(url);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetContrato(
            DateTime dataAssinatura, TipoDePlano tipoPlano, 
            string descricaoContrato, bool ativo, string nomeArquivoContrato,
            int quantidadeDeUnidadesContratada)
        {
            Contrato = new Contrato
                       (Id, dataAssinatura, tipoPlano, descricaoContrato, ativo,
                        new NomeArquivo(nomeArquivoContrato, Guid.NewGuid()),
                        quantidadeDeUnidadesContratada);
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetSindico(Guid id, string nome)
        {
            FuncionarioIdDoSindico = id;
            NomeDoSindico = nome;
        }


    }
}
