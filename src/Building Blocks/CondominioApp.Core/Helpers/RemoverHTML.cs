using System.Text.RegularExpressions;
using System.Net;

namespace CondominioApp.Core.Helpers
{    public static class RemoverHTML
    {
        public static string RemoverHTMLdeString(string value)
        {
            var passo1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var passo2 = Regex.Replace(passo1, @"\s{2,}", " ");
            var passo3 = WebUtility.HtmlDecode(passo2);
            return passo3;
        }
    }
}
