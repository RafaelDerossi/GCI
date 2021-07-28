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

        public Foto Logo { get; private set; }

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

        public Guid FuncionarioIdDoSindico { get; private set; }



        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool PortariaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaParaMoradorAtivada { get; private set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool ClassificadoAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoParaMoradorAtivado { get; private set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool MuralAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralParaMoradorAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool ChatAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatParaMoradorAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool ReservaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortariaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool OcorrenciaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaParaMoradorAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool CorrespondenciaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortariaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita o cadastro de veículo pelo morador no app.
        /// </summary>
        public bool CadastroDeVeiculoPeloMoradorAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita a criação de enquetes
        /// </summary>
        public bool EnqueteAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita o Controle de Acesso
        /// </summary>
        public bool ControleDeAcessoAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita a gestão de tarefas
        /// </summary>
        public bool TarefaAtivada { get; private set; }

        /// <summary>
        /// Habilita/Desabilita a gestão de orçamentos
        /// </summary>
        public bool OrcamentoAtivado { get; private set; }

        /// <summary>
        /// Habilita/Desabilita a automação
        /// </summary>
        public bool AutomacaoAtivada { get; private set; }


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

        public Condominio(Guid id, Cnpj cnpj, string nome, string descricao, Foto logo,
            Telefone telefone, Endereco endereco, bool portariaAtivada, 
            bool portariaParaMoradorAtivada, bool classificadoAtivado,  bool classificadoMorador,
            bool muralAtivado, bool muralParaMoradorAtivado, bool chatAtivado, bool chatParaMoradorAtivado, 
            bool reservaAtivada, bool reservaNaPortariaAtivada, bool ocorrenciaAtivada, 
            bool ocorrenciaParaMoradorAtivada, bool correspondenciaAtivada, 
            bool correspondenciaNaPortariaAtivada, bool cadastroDeVeiculoPeloMoradorAtivado,
            bool enqueteAtivada, bool controleDeAcessoAtivado, bool tarefaAtivada, bool orcamentoAtivado,
            bool automacaoAtivada)
        {
            _Grupos = new List<Grupo>();
            _Unidades = new List<Unidade>();
            _Contratos = new List<Contrato>();

            SetEntidadeId(id);
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            Logo = logo;
            Telefone = telefone;
            Endereco = endereco;          
            PortariaAtivada = portariaAtivada;
            PortariaParaMoradorAtivada = portariaParaMoradorAtivada;
            ClassificadoAtivado = classificadoAtivado;
            ClassificadoParaMoradorAtivado = classificadoMorador;
            MuralAtivado = muralAtivado;
            MuralParaMoradorAtivado = muralParaMoradorAtivado;
            ChatAtivado = chatAtivado;
            ChatParaMoradorAtivado = chatParaMoradorAtivado;
            ReservaAtivada = reservaAtivada;
            ReservaNaPortariaAtivada = reservaNaPortariaAtivada;
            OcorrenciaAtivada = ocorrenciaAtivada;
            OcorrenciaParaMoradorAtivada = ocorrenciaParaMoradorAtivada;
            CorrespondenciaAtivada = correspondenciaAtivada;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortariaAtivada;
            CadastroDeVeiculoPeloMoradorAtivado = cadastroDeVeiculoPeloMoradorAtivado;
            EnqueteAtivada = enqueteAtivada;
            ControleDeAcessoAtivado = controleDeAcessoAtivado;
            TarefaAtivada = tarefaAtivada;
            OrcamentoAtivado = orcamentoAtivado;
            AutomacaoAtivada = automacaoAtivada;
        }




        ///Metodos Set

        public void SetCNPJ(Cnpj cnpj) => Cnpj = cnpj;

        public void SetNome(string nome) => Nome = nome;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetLogo(Foto logo) => this.Logo = logo;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetEndereco(Endereco endereco) => Endereco = endereco;

        public void SetFuncionarioIdDoSindico(Guid id) => FuncionarioIdDoSindico = id;


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
        /// Cadastro de Veículo pelo morador
        /// </summary>
        public void AtivarCadastroDeVeiculoPeloMorador() => CadastroDeVeiculoPeloMoradorAtivado = true;
        public void DesativarCadastroDeVeiculoPeloMorador() => CadastroDeVeiculoPeloMoradorAtivado = false;


        /// <summary>
        /// Enquetes
        /// </summary>
        public void AtivarEnquete() => EnqueteAtivada = true;
        public void DesativarEnquete() => EnqueteAtivada = false;

        /// <summary>
        /// Controle de Acesso
        /// </summary>
        public void AtivarControleDeAcesso() => ControleDeAcessoAtivado = true;
        public void DesativarControleDeAcesso() => ControleDeAcessoAtivado = false;

        /// <summary>
        /// Tarefas
        /// </summary>
        public void AtivarTarefa() => TarefaAtivada = true;
        public void DesativarTarefa() => TarefaAtivada = false;

        /// <summary>
        /// Orçamentos
        /// </summary>
        public void AtivarOrcamento() => OrcamentoAtivado = true;
        public void DesativarOrcamento() => OrcamentoAtivado = false;

        /// <summary>
        /// Automação
        /// </summary>
        public void AtivarAutomacao() => AutomacaoAtivada = true;
        public void DesativarAutomacao() => AutomacaoAtivada = false;




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
            if (contrato.Ativo)
            {
                DesativarContratos();
                switch (contrato.Tipo)
                {
                    case Core.Enumeradores.TipoDePlano.SEM_CONTRATO:
                        DesativarFuncoesDoCondominio();
                        break;
                    case Core.Enumeradores.TipoDePlano.FREE:
                        DesativarFuncoesDoCondominioParaPlanoFree();
                        break;
                    case Core.Enumeradores.TipoDePlano.STANDARD:
                        DesativarFuncoesDoCondominioParaPlanoStandard();
                        break;                   
                    default:
                        break;
                }
            }
            else
            {
                DesativarFuncoesDoCondominio();
            }

            contrato.SetCondominioId(Id);

            _Contratos.Add(contrato);                

            return ValidationResult;
        }

        public void RemoverContrato(Contrato contrato)
        {
            _Contratos.Remove(contrato);
        }

        private void DesativarContratos()
        {
            foreach (Contrato contrato in _Contratos)
            {
                contrato.Desativar();               
            }
        }

        private void DesativarFuncoesDoCondominio()
        {
            DesativarFuncoesDoCondominioParaPlanoFree();

            DesativarCadastroDeVeiculoPeloMorador();
            DesativarChat();
            DesativarChatMorador();
            DesativarClassificado();
            DesativarClassificadoMorador();
            DesativarCorrespondencia();
            DesativarCorrespondenciaNaPortaria();            
            DesativarMural();
            DesativarMuralMorador();
            DesativarOcorrencia();
            DesativarOcorrenciaMorador();
        }

        private void DesativarFuncoesDoCondominioParaPlanoFree()
        {
            DesativarFuncoesDoCondominioParaPlanoStandard();
                    
            DesativarCorrespondenciaNaPortaria();                                    
            DesativarPortaria();
            DesativarPortariaMorador();
            DesativarReserva();
            DesativarReservaNaPortaria();
            DesativarEnquete();
            DesativarControleDeAcesso();
            DesativarTarefa();
            DesativarOrcamento();            
        }

        private void DesativarFuncoesDoCondominioParaPlanoStandard()
        {            
            DesativarAutomacao();
        }
        
    }
}
