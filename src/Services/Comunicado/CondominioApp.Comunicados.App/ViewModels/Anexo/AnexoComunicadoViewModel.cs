﻿using System;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class AnexoComunicadoViewModel
    {
        public Guid ArquivoId { get; set; }        

        public string NomeArquivo { get; set; }

        public string NomeOriginal { get; set; }        

        public string Extensao { get; set; }

        public double Tamanho { get; set; }


        public AnexoComunicadoViewModel
            (Guid arquivoId, string nomeArquivo, string nomeOriginal, string extensao, double tamanho)
        {
            ArquivoId = arquivoId;
            NomeArquivo = nomeArquivo;
            NomeOriginal = nomeOriginal;
            Extensao = extensao;
            Tamanho = tamanho;
        }
    }
}
