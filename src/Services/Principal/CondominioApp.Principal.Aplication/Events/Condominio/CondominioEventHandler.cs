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
        INotificationHandler<CondominioRemovidoEvent>,
        System.IDisposable
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public CondominioEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task Handle(CondominioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = new CondominioFlat
                (notification.CondominioId, notification.DataDeCadastro, notification.DataDeAlteracao,
                false, notification.Cnpj.NumeroFormatado, notification.Nome, notification.Descricao, 
                notification.LogoMarca.NomeDoArquivo, notification.Telefone.ObterNumeroFormatado,
                notification.Endereco.logradouro, notification.Endereco.complemento, 
                notification.Endereco.numero, notification.Endereco.cep, notification.Endereco.bairro,
                notification.Endereco.cidade, notification.Endereco.estado, notification.RefereciaId,
                notification.LinkGeraBoleto, notification.BoletoFolder, notification.UrlWebServer.Endereco,
                notification.Portaria, notification.PortariaMorador, notification.Classificado, 
                notification.ClassificadoMorador, notification.Mural, notification.MuralMorador, 
                notification.Chat, notification.ChatMorador, notification.Reserva, notification.ReservaNaPortaria,
                notification.Ocorrencia, notification.OcorrenciaMorador, notification.Correspondencia,
                notification.CorrespondenciaNaPortaria, notification.LimiteTempoReserva);

            _condominioQueryRepository.Adicionar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CondominioEditadoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);

            condominioFlat.SetDataDeAlteracao(notification.DataDeAlteracao);
            condominioFlat.SetCNPJ(notification.Cnpj.NumeroFormatado);
            condominioFlat.SetNome(notification.Nome);
            condominioFlat.SetDescricao(notification.Descricao);
            condominioFlat.SetFoto(notification.LogoMarca.NomeDoArquivo);
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

            condominioFlat.SetDataDeAlteracao(notification.DataDeAlteracao);

            if (notification.Portaria)
                condominioFlat.AtivarPortaria();
            else
                condominioFlat.DesativarPortaria();


            if (notification.PortariaMorador)
                condominioFlat.AtivarPortariaMorador();
            else
                condominioFlat.DesativarPortariaMorador();


            if (notification.Classificado)
                condominioFlat.AtivarClassificado();
            else
                condominioFlat.DesativarClassificado();


            if (notification.ClassificadoMorador)
                condominioFlat.AtivarClassificadoMorador();
            else
                condominioFlat.DesativarClassificadoMorador();


            if (notification.Mural)
                condominioFlat.AtivarMural();
            else
                condominioFlat.DesativarMural();


            if (notification.MuralMorador)
                condominioFlat.AtivarMuralMorador();
            else
                condominioFlat.DesativarMuralMorador();


            if (notification.Chat)
                condominioFlat.AtivarChat();
            else
                condominioFlat.DesativarChat();


            if (notification.ChatMorador)
                condominioFlat.AtivarChatMorador();
            else
                condominioFlat.DesativarChatMorador();

            if (notification.Reserva)
                condominioFlat.AtivarReserva();
            else
                condominioFlat.DesativarReserva();


            if (notification.ReservaNaPortaria)
                condominioFlat.AtivarReservaNaPortaria();
            else
                condominioFlat.DesativarReservaNaPortaria();


            if (notification.Ocorrencia)
                condominioFlat.AtivarOcorrencia();
            else
                condominioFlat.DesativarOcorrencia();


            if (notification.OcorrenciaMorador)
                condominioFlat.AtivarOcorrenciaMorador();
            else
                condominioFlat.DesativarOcorrenciaMorador();


            if (notification.Correspondencia)
                condominioFlat.AtivarCorrespondencia();
            else
                condominioFlat.DesativarCorrespondencia();


            if (notification.CorrespondenciaNaPortaria)
                condominioFlat.AtivarCorrespondenciaNaPortaria();
            else
                condominioFlat.DesativarCorrespondenciaNaPortaria();


            if (notification.LimiteTempoReserva)
                condominioFlat.AtivarLimiteTempoReserva();
            else
                condominioFlat.DesativarLimiteTempoReserva();



            _condominioQueryRepository.Atualizar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CondominioRemovidoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no CondominioFlat
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);

            condominioFlat.SetDataDeAlteracao(notification.DataDeAlteracao);

            condominioFlat.EnviarParaLixeira();

            _condominioQueryRepository.Atualizar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }        
    }
}
