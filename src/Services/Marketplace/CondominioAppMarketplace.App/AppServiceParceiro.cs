using AutoMapper;
using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.Model;
using CondominioAppMarketplace.App.ParceiroFactory;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAppMarketplace.App
{
    public class AppServiceParceiro : AppService, IAppServiceParceiro
    {
        private readonly IParceiroRepository _repository;

        private readonly IItemDeVendaRepository _itemDeVendaRepository;

        private readonly IMapper _mapper;

        public AppServiceParceiro(IParceiroRepository repository, IMapper mapper, IItemDeVendaRepository itemDeVendaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _itemDeVendaRepository = itemDeVendaRepository;
        }

        public async Task<ParceiroViewModel> ObterPorId(Guid Id)
        {
            var parceiro = await _repository.ObterPorId(Id);
            return await Task.FromResult(_mapper.Map<ParceiroViewModel>(parceiro));
        }

        public async Task<IEnumerable<ParceiroViewModel>> ObterTodos()
        {
            var parceiros = await _repository.ObterTodos();
            return await Task.FromResult(_mapper.Map<IEnumerable<ParceiroViewModel>>(parceiros));
        }

        public async Task<ValidationResult> Adicionar(ParceiroViewModel ViewModel)
        {
            ConstrutorDeParceiros fabricaDeParceiros;

            if (ViewModel.PreCadastro)
            {
                fabricaDeParceiros = new ConstrutorDeParceiros(new FabricaDeParceirosPreCadastro());
            }
            else
            {
                fabricaDeParceiros = new ConstrutorDeParceiros(new FabricaDeParceirosEfetivos());
            }

            var parceiro = fabricaDeParceiros.Construir(ViewModel);

            if (!fabricaDeParceiros.Fabrica.ValidationResult.IsValid) return fabricaDeParceiros.Fabrica.ValidationResult;

            if (EsteParceiroEstaCadastrado(parceiro))
            {
                AdicionarErro("Este Cnpj se encontra cadastrado, por favor tente outro!");
                return ValidationResult;
            }

            _repository.Adicionar(parceiro);

            return await PersistirDados(_repository.UnitOfWork);

        }

        private bool EsteParceiroEstaCadastrado(Parceiro Parceiro)
        {
            var parceiro = _repository.Obter(x => x.Cnpj.numero == Parceiro.Cnpj.numero &&
                                                  !x.Lixeira).Result.FirstOrDefault();
            if (parceiro != null)
                return true;

            return false;
        }


        public async Task<ValidationResult> ContratarVendedor(VendedorViewModel ViewModel)
        {
            var vendedor = _mapper.Map<Vendedor>(ViewModel);

            var VendedorObtido = _repository.ObterVendedores(x => x.Email.Endereco == vendedor.Email.Endereco &&
                                                                  !x.Lixeira, false, 1).Result.FirstOrDefault();

            if (VendedorObtido != null && VendedorObtido.Equals(vendedor))
            {
                AdicionarErro("Vendedor ja cadastrado para este parceiro!");
                return ValidationResult;
            }

            _repository.AdicionarVendedor(vendedor);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<IEnumerable<VendedorViewModel>> ObterTodosVendedores()
        {
            var vendedores = await _repository.ObterVendedores(x => !x.Lixeira, false, 250);
            return await Task.FromResult(_mapper.Map<IEnumerable<VendedorViewModel>>(vendedores));
        }

        public async Task<IEnumerable<VendedorViewModel>> ObterVendedoresDoParceiro(Guid ParceiroId)
        {
            var vendedores = await _repository.ObterVendedores(x => !x.Lixeira && x.Parceiro.Id == ParceiroId, false, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<VendedorViewModel>>(vendedores));
        }

        public async Task<ValidationResult> AtualizarVendedor(VendedorAlterarViewModel ViewModel)
        {
            var vendedor = await _repository.ObterVendedorPorId(ViewModel.VendedorId);
            if (vendedor == null)
            {
                AdicionarErro("Vendedor não encontrado!");
                return ValidationResult;
            }

            vendedor.setNome(ViewModel.Nome);
            vendedor.setEndereco(new Endereco(ViewModel.logradouro, ViewModel.complemento, ViewModel.numero, ViewModel.cep, ViewModel.bairro, ViewModel.cidade, ViewModel.estado));
            vendedor.setTelefone(new Telefone(ViewModel.TelefoneDoVendedor, ViewModel.Whatsapp));

            _repository.AtualizarVendedor(vendedor);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> RemoverParceiro(Guid ParceiroId)
        {
            var Parceiro = await _repository.ObterPorId(ParceiroId);
            Parceiro.EnviarParaLixeira();

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<IEnumerable<ParceiroViewModel>> ObterAtivos()
        {
            var parceiros = await _repository.Obter(x => !x.PreCadastro && !x.Lixeira, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<ParceiroViewModel>>(parceiros));
        }

        public async Task<ValidationResult> DesativarPreCadastro(Guid ParceiroId)
        {
            var Parceiro = await _repository.ObterPorId(ParceiroId);
            Parceiro.DesativarPreCadastro();

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Atualizar(ParceiroViewModel ViewModel)
        {
            var Parceiro = await _repository.ObterPorId(ViewModel.ParceiroId);

            if (!ViewModel.PreCadastro)
                Parceiro.setContrato(new Contrato(ViewModel.ContratoDataDeInicio, ViewModel.ContratoDataDeRenovacao, ViewModel.ContratoDescricao));

            Parceiro.setNomeCompleto(ViewModel.NomeCompleto);
            Parceiro.setNomeDoResponsavel(ViewModel.NomeDoResponsavel);
            Parceiro.setTelefoneFixo(new Telefone(ViewModel.TelefoneFixo));
            Parceiro.setTelefoneMovel(new Telefone(ViewModel.TelefoneCelular, ViewModel.Whatsapp));
            Parceiro.setDescricao(ViewModel.Descricao);
            Parceiro.setEndereco(new Endereco(ViewModel.Logradouro, ViewModel.Complemento, ViewModel.Numero,
                ViewModel.Cep, ViewModel.Bairro, ViewModel.Cidade, ViewModel.Estado));
            Parceiro.setEmail(new Email(ViewModel.EmailDoResponsavel));

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> AtualizarContrato(ContratoModel Model)
        {
            var Parceiro = await _repository.ObterPorId(Model.ParceiroId);

            Parceiro.setContrato(new Contrato(Model.ContratoDataDeInicio, Model.ContratoDataDeRenovacao, Model.ContratoDescricao));

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> AtualizarCnpj(ParceiroCnpjModel Model)
        {
            var Parceiro = await _repository.ObterPorId(Model.ParceiroId);

            Parceiro.setCnpj(new Cnpj(Model.Cnpj));

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> AtualizarLogoMarca(ParceiroLogoMarcaModel Model)
        {
            var Parceiro = await _repository.ObterPorId(Model.ParceiroId);

            Parceiro.setLogoMarca(Model.LogoMarca);

            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> LimparLogoMarca(Guid ParceiroId)
        {
            var Parceiro = await _repository.ObterPorId(ParceiroId);

            Parceiro.LimparLogoMarca();
            _repository.Atualizar(Parceiro);

            return await PersistirDados(_repository.UnitOfWork);
        }


        public async Task<ValidationResult> DesativarLoja(Guid ParceiroId)
        {
            var parceiro = await _repository.ObterPorId(ParceiroId);
            parceiro.AtivarPreCadastro();

            var ItensDeVenda = await _itemDeVendaRepository.ObterItensDoParceiro(ParceiroId);

            foreach (var ItenDeVenda in ItensDeVenda)
            {
                ItenDeVenda.EnviarParaLixeira();
                _itemDeVendaRepository.Atualizar(ItenDeVenda);
            }

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> ReativarLoja(Guid ParceiroId)
        {
            var parceiro = await _repository.ObterPorId(ParceiroId);
            parceiro.DesativarPreCadastro();

            var ItensDeVenda = await _itemDeVendaRepository.ObterItensDoParceiro(ParceiroId);
            foreach (var ItenDeVenda in ItensDeVenda)
            {
                ItenDeVenda.RestaurarDaLixeira();
                _itemDeVendaRepository.Atualizar(ItenDeVenda);
            }

            return await PersistirDados(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
