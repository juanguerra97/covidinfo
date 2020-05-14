using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidInfoWebService.Utils
{
    public static class UrlExtractor
    {

        /// <summary>
        /// Metodo para extraer el dominio del servidor de una url
        /// </summary>
        /// <param name="url">url de la que se extraera el dominio</param>
        /// <returns></returns>
        public static string ExtractBaseUrl(string url)
        {

            var regex = new Regex(@"^(https?://[^/\:\\]+(\:\d+)?).*$", RegexOptions.IgnoreCase);
            var match = regex.Match(url);

            if (!match.Success)
            {
                return null;
            }

            return match.Groups[1].Value;

        }

    }
}
