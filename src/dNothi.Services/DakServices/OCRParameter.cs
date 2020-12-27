using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.DakServices
{
   public class OCRParameter
    {
       

        public string data { get; set; }
           
        public string language { get; set; }
        public string Extension { get; set; }
   

        public string image()
        {

            return "data:image/"+ Extension + ";base64," + data;




        }
    

        public OCRParameter()
        {
            this.language="ben+eng";
        }

       
    }
}
