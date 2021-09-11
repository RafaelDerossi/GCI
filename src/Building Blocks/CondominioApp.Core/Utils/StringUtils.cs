using System.Linq;

namespace CondominioApp.Core.Utils
{
    public static class StringUtils
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remover o parâmetro não utilizado", Justification = "<Pendente>")]
        public static string ApenasNumeros(this string str, string input)        
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}