using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakDraftedResponse
    {
        public string status { get; set; }
        public string message { get; set; }

    }
    public class DakSendResponse
    {
        public string status { get; set; }
        public DakSendResponseMessageDTO data { get; set; }


       
    }

         public class DakSendResponseMessageDTO
        {
            public string message { get; set; }
            public string dak_receipt_no { get; set; }
            public string receiving_date { get; set; }
      

    }
}
