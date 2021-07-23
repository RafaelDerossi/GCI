using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using MediatR;


namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEventHandler : EventHandler, 
        INotificationHandler<CondominioCadastradoEvent>,
        INotificationHandler<CondominioEditadoEvent>,
        INotificationHandler<CondominioConfiguracaoEditadoEvent>,
        INotificationHandler<CondominioApagadoEvent>,
        INotificationHandler<SindicoDoCondominioDefinidoEvent>,
        System.IDisposable
    {
        private readonly IPrincipalQueryRepository _condominioQueryRepository;

        public CondominioEventHandler(IPrincipalQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task Handle(CondominioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = new CondominioFlat
                (notification.CondominioId, false, notification.Cnpj.NumeroFormatado, notification.Nome,
                 notification.Descricao, notification.LogoMarca, notification.Telefone.ObterNumeroFormatado,
                 notification.Endereco.logradouro, notification.Endereco.complemento, 
                 notification.Endereco.numero, notification.Endereco.cep, notification.Endereco.bairro,
                 notification.Endereco.cidade, notification.Endereco.estado, notification.PortariaAtivada,
                 notification.PortariaMoradorAtivada, notification.ClassificadoAtivado,
                 notification.ClassificadoMoradorAtivado, notification.MuralAtivado,
                 notification.MuralMoradorAtivado, notification.ChatAtivado, notification.ChatMoradorAtivado,
                 notification.ReservaAtivada, notification.ReservaNaPortariaAtivada,
                 notification.OcorrenciaAtivada, notification.OcorrenciaMoradorAtivada, 
                 notification.CorrespondenciaAtivada, notification.CorrespondenciaNaPortariaAtivada, 
                 notification.CadastroDeVeiculoPeloMoradorAtivado, notification.ContratoId, 
                 notification.DataAssinatura, notification.TipoPlano, notification.DescricaoContrato,
                 notification.ContratoAtivo, notification.ArquivoContrato);

            _condominioQueryRepository.Adicionar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CondominioEditadoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);

            condominioFlat.SetCNPJ(notification.Cnpj.NumeroFormatado);
            condominioFlat.SetNome(notification.Nome);
            condominioFlat.SetDescricao(notification.Descricao);            
            condominioFlat.SetTelefone(notification.Telefone.ObterNumeroFormatado);
            condominioFlat.SetEndereco(notification.Endereco.logradouro, notification.Endereco.complemento, 
                notification.Endereco.numero, notification.Endereco.cep, notification.Endereco.bairro, 
                notification.Endereco.cidade, notification.Endereco.estado);
            

            _condominioQueryRepository.Atualizar(condominioFlat);

            //Atualizar no GrupoFlat
            var gruposDoCondominio = await _condominioQueryRepository.ObterGruposPorCondominio(notification.CondominioId);
            foreach (GrupoFlat grupo in gruposDoCondominio)
            {
                grupo.SetCondominioCNPJ(notification.Cnpj.NumeroFormatado);
                grupo.SetCondominioNome(notification.Nome);
                grupo.SetCondominioLogomarca(notification.LogoMarca.NomeDoArquivo);

                _condominioQueryRepository.AtualizarGrupo(grupo);
            }

            //Atualizar no Unidade Flat
            var unidadesDoCondominio = await _condominioQueryRepository.ObterUnidadesPorCondominio(notification.CondominioId);
            foreach (UnidadeFlat unidade in unidadesDoCondominio)
            {
                unidade.SetCondominioCNPJ(notification.Cnpj.NumeroFormatado);
                unidade.SetCondominioNome(notification.Nome);
                unidade.SetCondominioLogomarca(notification.LogoMarca.NomeDoArquivo);

                _condominioQueryRepository.AtualizarUnidade(unidade);
            }

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CondominioConfiguracaoEditadoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);

          
            if (notification.PortariaAtivada)
                condominioFlat.AtivarPortaria();
            else
                condominioFlat.DesativarPortaria();


            if (notification.PortariaMoradorAtivada)
                condominioFlat.AtivarPortariaMorador();
            else
                condominioFlat.DesativarPortariaMorador();


            if (notification.ClassificadoAtivado)
                condominioFlat.AtivarClassificado();
            else
                condominioFlat.DesativarClassificado();


            if (notification.ClassificadoMoradorAtivado)
                condominioFlat.AtivarClassificadoMorador();
            else
                condominioFlat.DesativarClassificadoMorador();


            if (notification.MuralAtivado)
                condominioFlat.AtivarMural();
            else
                condominioFlat.DesativarMural();


            if (notification.MuralMoradorAtivado)
                condominioFlat.AtivarMuralMorador();
            else
                condominioFlat.DesativarMuralMorador();


            if (notification.ChatAtivado)
                condominioFlat.AtivarChat();
            else
                condominioFlat.DesativarChat();


            if (notification.ChatMoradorAtivado)
                condominioFlat.AtivarChatMorador();
            else
                condominioFlat.DesativarChatMorador();

            if (notification.ReservaAtivada)
                condominioFlat.AtivarReserva();
            else
                condominioFlat.DesativarReserva();


            if (notification.ReservaNaPortariaAtivada)
                condominioFlat.AtivarReservaNaPortaria();
            else
                condominioFlat.DesativarReservaNaPortaria();


            if (notification.OcorrenciaAtivada)
                condominioFlat.AtivarOcorrencia();
            else
                condominioFlat.DesativarOcorrencia();


            if (notification.OcorrenciaMoradorAtivada)
                condominioFlat.AtivarOcorrenciaMorador();
            else
                condominioFlat.DesativarOcorrenciaMorador();


            if (notification.CorrespondenciaAtivada)
                condominioFlat.AtivarCorrespondencia();
            else
                condominioFlat.DesativarCorrespondencia();


            if (notification.CorrespondenciaNaPortariaAtivada)
                condominioFlat.AtivarCorrespondenciaNaPortaria();
            else
                condominioFlat.DesativarCorrespondenciaNaPortaria();


            if (notification.CadastroDeVeiculoPeloMoradorAtivado)
                condominioFlat.AtivarCadastroDeVeiculoPeloMorador();
            else
                condominioFlat.DesativarCadastroDeVeiculoPeloMorador();


            _condominioQueryRepository.Atualizar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CondominioApagadoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);            

            _condominioQueryRepository.Apagar(x=>x.Id == condominioFlat.Id);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(SindicoDoCondominioDefinidoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);

            condominioFlat.SetSindico(notification.FuncionarioIdDoSindico, notification.NomeDoSindico);

            _condominioQueryRepository.Atualizar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }        
    }
}
