using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentValidation.Results;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CondominioApp.Core.Helpers
{
   public class GeradorDeExcel<T>
    {
        List<string> cabecalho { get; set; }
        List<T> lista { get; set; }
        string nomeArquivo { get; set; }
        string titulo { get; set; }
        string pastaDestino { get; set; }

        string caminhoRaiz { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public GeradorDeExcel(List<string> cabecalho, List<T> lista, string nomeArquivo, string titulo, string caminhoRaiz, string pastaDestino = "Temp")
        {
            ValidationResult = new ValidationResult();
            this.cabecalho = cabecalho;
            this.lista = lista;
            this.nomeArquivo = nomeArquivo;
            this.titulo = titulo;
            this.pastaDestino = pastaDestino;
            this.caminhoRaiz = caminhoRaiz;
        }

        public ValidationResult GerarExcel()
        {
            if (lista.Count == 0)
            {
                AdicionarErrosDeProcessamento("Não há itens");
                return ValidationResult;
            }
            
            try
            {
                string nomeDoArquivo = @"/" + nomeArquivo + ".xlsx";               
                string outputDir = caminhoRaiz + @"/Download/" + pastaDestino;
                
                List<string> usuarioNaoInformado = new List<string>();
                usuarioNaoInformado.Add("N/I");

                    if (!Directory.Exists(outputDir))
                        Directory.CreateDirectory(outputDir);


                    FileInfo newFile = new FileInfo(outputDir + nomeDoArquivo);
                    if (newFile.Exists)
                    {
                        newFile.Delete();
                        newFile = new FileInfo(outputDir + nomeDoArquivo);
                    }
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        // Cria um worksheet num workbook vazio
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(titulo.Replace(" ", "-"));

                        //Cabeçalho
                        var x = 0;
                        cabecalho.ForEach(t =>
                        {
                            x++;
                            worksheet.Cells[1, x].Value = t;
                        });


                        //formatação do cabeçalho
                        using (var range = worksheet.Cells[1, 1, 1, cabecalho.Count])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                            range.Style.Font.Color.SetColor(Color.White);
                        }

                        // inserindo os registros na planilha
                        for (var i = 0; i < lista.Count(); i++)
                        {


                            PropertyInfo[] propriedades = typeof(T).GetProperties();

                            var j = 0;
                            foreach (var prop in propriedades)
                            {
                                j++;

                                worksheet.Cells[(i + 2), j].Value = lista[i].GetType().GetProperty(prop.Name).GetValue(lista[i], null);
                            }

                        }

                        worksheet.HeaderFooter.OddFooter.RightAlignedText =
                        string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                        worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
                        worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
                        worksheet.View.PageLayoutView = false;
                        package.Workbook.Properties.Title = titulo;
                        package.Save();

                    }


                    //return new ServerStatus { status = 0, mensagem = nomeDoArquivo };
                    return ValidationResult;
               
                

            }
            catch (Exception ex)
            {
                AdicionarErrosDeProcessamento(ex.ToString());
                return ValidationResult;                
            }
        }

        public void AdicionarErrosDeProcessamento(string mensagemDeErro)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagemDeErro));
        }
    }
}
