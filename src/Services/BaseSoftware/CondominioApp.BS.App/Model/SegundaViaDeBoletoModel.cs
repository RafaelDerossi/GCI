using System.Collections.Generic;

namespace CondominioApp.BS.App.Model
{
    public class SegundaViaDeBoletoModel 
    {
       public string CONDOMINIO { get; set; }
       public string BLOCO { get; set; }
       public string UNIDADE { get; set; }
       public List<BoletoModel> BOLETO { get; set; } = new List<BoletoModel>();
    }
}
