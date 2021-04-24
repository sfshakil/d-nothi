using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class ConversionMethod
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string EnglishNumberToBangla(string Num)
        {
           return string.Concat(Num.ToString().Select(c => (char)('\u09E6' + c - '0')));
        }

        public static string FilterJsonResponse(string jsonResponsewithGarbageData)
        {
            try
            {
                int firstStringIndex = jsonResponsewithGarbageData.IndexOf("{\"status\":");

                var pureJsonResponse = jsonResponsewithGarbageData.Substring(firstStringIndex, jsonResponsewithGarbageData.Length - firstStringIndex);

                return pureJsonResponse;
            }
            catch
            {
                return "";
            }

        }



        public static string GetDakTypeNameBangla(string value)
        {
            if(value=="Daptorik")
            {
                return "দাপ্তরিক";
            }
            else
            {
                return "নাগরিক";
            }
           
        }
    }
}
