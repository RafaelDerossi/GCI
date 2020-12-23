using System.IO;
using System.Threading.Tasks;
using CondominioApp.BS.App.Model;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CondominioApp.Api.Controllers.BaseSoftware
{
    [Route("api/bs/balancete")]
    public class BalanceteController : MainController
    {
        private readonly IWebHostEnvironment _env;
        public BalanceteController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // [HttpGet("Analitico")]
        // public async Task<IActionResult> Analitico(int Id, string Administradora)
        // {
        //     var Caminho = _env.ContentRootPath;

        //     Caminho = Caminho.Replace("\\backend", "");

        //     var CaminhoDoArquivo = $"{Caminho}\\Basesoftware\\balancetes\\{Administradora}\\BalanceteAnalitico\\{Id}.htm";

        //     if (Id == 0) return NotFound();

        //     var memory = new MemoryStream();
        //     using var stream = new FileStream(CaminhoDoArquivo, FileMode.Open);
        //     await stream.CopyToAsync(memory);

        //     memory.Position = 0;
        //     return File(memory, GetContentType(CaminhoDoArquivo), Path.GetFileName(CaminhoDoArquivo));
        // }

        [HttpGet("BuscarLinkBalanceteAnalitico")]
        public BalanceteAnaliticoModel BuscarLinkBalanceteAnalitico(int condominioCodigo, string Administradora)
        {
            return new BalanceteAnaliticoModel(0, $"http://techdog-003-site7.dtempurl.com/balancetes/{Administradora}/BalanceteAnalitico/{condominioCodigo}.htm" );
        }

        // private string GetContentType(string fileName)
        // {
        //     string strcontentType = "application/octetstream";
        //     string ext = System.IO.Path.GetExtension(fileName).ToLower();
        //     Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        //     if (registryKey != null && registryKey.GetValue("Content Type") != null)
        //         strcontentType = registryKey.GetValue("Content Type").ToString();
        //     return strcontentType;
        // }
    }
}