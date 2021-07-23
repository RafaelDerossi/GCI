using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AdicionarCondominioCommand : CondominioCommand
    {
        public AdicionarCondominioCommand
            (string cnpj, string nome, string descricao, string nomeOriginalArquivoLogo, string telefone,
             string logradouro, string complemento, string numero, string cep, string bairro, string cidade, 
             string estado, bool portariaAtivada, bool portariaParaMoradorAtivada, bool classificadoAtivado,
             bool classificadoParaMoradorAtivado, bool muralAtivado, bool muralParaMoradorAtivado,
             bool chatAtivado, bool chatParaMoradorAtivado, bool reservaAtivada, bool reservaNaPortariaAtivada,
             bool ocorrenciaAtivada, bool ocorrenciaParaMoradorAtivada, bool correspondenciaAtivada, 
             bool correspondenciaNaPortariaAtivada, bool cadastroDeVeiculoPeloMoradorAtivado,
             DateTime DataAssinaturaContrato, TipoDePlano TipoDePlano, string descricaoContrato,
             bool contratoAtivo, string nomeOriginalArquivoContrato,  int quantidadeDeUnidadesContratada)
        {
            SetCNPJ(cnpj);
            Nome = nome;
            Descricao = descricao;
            SetFoto(nomeOriginalArquivoLogo);
            SetTelefone(telefone);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);         
            
            PortariaAtivada = portariaAtivada;
            PortariaParaMoradorAtivada = portariaParaMoradorAtivada;
            ClassificadoAtivado = classificadoAtivado;
            ClassificadoParaMoradorAtivado = classificadoParaMoradorAtivado;
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
            SetContrato
                (DataAssinaturaContrato, TipoDePlano, descricaoContrato, contratoAtivo,
                 nomeOriginalArquivoContrato, quantidadeDeUnidadesContratada);
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
