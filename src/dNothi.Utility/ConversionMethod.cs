using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class ConversionMethod
    {
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
