using CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers;
using CondominioApp.Core.DomainObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
  public class ArquivoDTO
    {
        public Guid Id { get; private set; }        

        public string NomeArquivo { get; private set; }

        public string NomeOriginal { get; private set; }        

        public double Tamanho
        {
            get
            {                
                return StorageHelper.ConverterBytesEmMegabytes(Arquivo.Length);
            }
        }

        public Guid CondominioId { get; private set; }

        public Guid PastaId { get; private set; }

        public bool Publico { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public string NomeFuncionario { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        private IFormFile Arquivo { get; set; }

        public ArquivoDTO
            (Guid condominioId, Guid pastaId, bool publico, Guid funcionarioId,
             string nomeFuncionario, string titulo, string descricao, IFormFile arquivo)
        {
            Id = Guid.NewGuid();
            CondominioId = condominioId;
            PastaId = pastaId;
            Publico = publico;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Titulo = titulo;
            Descricao = descricao;
            Arquivo = arquivo;
        }
    }
}
