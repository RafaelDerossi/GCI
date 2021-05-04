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

        [HttpGet("BuscarLinkBalanceteAnalitico")]
        public BalanceteAnaliticoModel BuscarLinkBalanceteAnalitico(int condominioCodigo, string Administradora)
        {
            return new BalanceteAnaliticoModel(0, $"http://techdog-003-site7.dtempurl.com/balancetes/{Administradora}/BalanceteAnalitico/{condominioCodigo}.htm" );
        }        
    }
}