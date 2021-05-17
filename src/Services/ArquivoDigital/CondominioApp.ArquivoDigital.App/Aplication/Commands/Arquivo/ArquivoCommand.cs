using CondominioApp.ArquivoDigital.App.ValueObjects;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ArquivoCommand : Command
    {
        public Guid Id { get; protected set; }

        public NomeArquivo Nome { get; protected set; }

        public double Tamanho { get; protected set; }

        public Guid PastaId { get; protected set; }

        public bool Publico { get; protected set; }

        public Guid FuncionarioId { get; protected set; }

        public string NomeFuncionario { get; protected set; }

        public string Titulo { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid AnexadoPorId { get; protected set; }

        public IFormFile Arquivo { get; protected set; }

        public Url Url { get; protected set; }


        public void SetId(Guid id) => Id = id;

        public void SetNome(string nomeOriginal)
        {
            try
            {
                Nome = new NomeArquivo(nomeOriginal, Id);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetTamanho(long tamanhoEmBytes)
        {
            Tamanho = StorageHelper.ConverterBytesEmMegabytes(tamanhoEmBytes);
            if (Tamanho > 100)
                AdicionarErrosDeProcessamentoDoComando("Tamanho máximo do arquivo é de 100MB.");
        }

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

        public void SetFuncionario(Guid id, string nome)
        {
            FuncionarioId = id;
            NomeFuncionario = nome;
        }

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetAnexadoPorId(Guid id) => AnexadoPorId = id;

        public void SetArquivo(IFormFile arquivo)
        {
            if (!StorageHelper.VerificaTipoDoArquivoPermitido(arquivo.FileName))
            {
                AdicionarErrosDeProcessamentoDoComando("Formato do arquivo não suportado.");
            }
            if (arquivo.Length <= 0)
            {
                AdicionarErrosDeProcessamentoDoComando("Informe um arquivo!");
            }
            Arquivo = arquivo;
        }

        public void SetUrl(string url)
        {
            try
            {
                Url = new Url(url);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }        

    }
}
