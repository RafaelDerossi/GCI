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
        List<string> Cabecalho { get; set; }
        List<T> Lista { get; set; }
        string Titulo { get; set; }
        MemoryStream Ms { get; set; }

        public ValidationResult ValidationResult { get; set; }
        
        public GeradorDeExcel(List<string> cabecalho, List<T> lista, string titulo, MemoryStream ms)
        {
            ValidationResult = new ValidationResult();
            Cabecalho = cabecalho;
            Lista = lista;            
            Titulo = titulo;            
            Ms = ms;
        }

        public ValidationResult GerarExcel()
        {
            if (Lista.Count == 0)
            {
                AdicionarErrosDeProcessamento("Não há itens");
                return ValidationResult;
            }
            
            try
            {
                using (ExcelPackage package = new ExcelPackage(Ms))
                {
                    // Cria um worksheet num workbook vazio
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(Titulo.Replace(" ", "-"));
                    
                    //Cabeçalho
                    var x = 0;
                    Cabecalho.ForEach(t =>
                    {
                        x++;
                        worksheet.Cells[1, x].Value = t;
                    });
                    
                    //formatação do cabeçalho
                    using (var range = worksheet.Cells[1, 1, 1, Cabecalho.Count])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                        range.Style.Font.Color.SetColor(Color.White);
                    }
                    
                    // inserindo os registros na planilha
                    for (var i = 0; i < Lista.Count(); i++)
                    {
                        PropertyInfo[] propriedades = typeof(T).GetProperties();
                        
                        var j = 0;
                        foreach (var prop in propriedades)
                        {
                            j++;
                            worksheet.Cells[(i + 2), j].Value = Lista[i].GetType().GetProperty(prop.Name).GetValue(Lista[i], null);
                        }
                    }
                    
                    worksheet.HeaderFooter.OddFooter.RightAlignedText =
                        string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                        worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
                        worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
                        worksheet.View.PageLayoutView = false;
                        package.Workbook.Properties.Title = Titulo;
                        package.Save();
                }
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
