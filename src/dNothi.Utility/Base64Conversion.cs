using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class Base64Conversion
    {
        public static string Base64ToHtmlContent(string base64Content)
        {
            string potroContent = string.Empty;
            try
            {
                string convertedString = base64Content.Replace("-", "+");
                convertedString = convertedString.Replace('_', '/');
                convertedString = convertedString.Replace(',', '=');

                var base64EncodedBytes = Convert.FromBase64String(convertedString);
                potroContent = Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                potroContent = string.Empty;
            }
            return potroContent;
        }
    }
}
