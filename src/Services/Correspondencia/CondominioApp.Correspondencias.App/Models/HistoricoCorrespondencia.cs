using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Correspondencias.App.Models
{
    public class HistoricoCorrespondencia : Entity
    {
        public const int Max = 200;

        public Guid CorrespondenciaId { get; private set; }

        public AcoesCorrespondencia Acao { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public string NomeFuncionario { get; private set; }

        public bool Visto { get; private set; }



        public HistoricoCorrespondencia()
        {
        }

        public HistoricoCorrespondencia
            (Guid correspondenciaId, AcoesCorrespondencia acao, Guid funcionarioId,
             string nomeFuncionario, bool visto)
        {
            CorrespondenciaId = correspondenciaId;
            Acao = acao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Visto = visto;
        }


        ///Metodos Set
        ///
        public void SetCorrespondenciaId(Guid correspondenciaId) => CorrespondenciaId = correspondenciaId;

        public void SetAcao(AcoesCorrespondencia acao) => Acao = acao;

        public void SetFuncionarioId(Guid usuarioId) => FuncionarioId = usuarioId;

        public void SetNomeFuncionario(string nomeUsuario) => NomeFuncionario = nomeUsuario;

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

    }
}
