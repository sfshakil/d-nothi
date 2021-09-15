using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public class DakFileUploadParam
    {
        public string model { get; set; }
        public string path { get; set; }
        public string file_size_in_kb { get; set; }
        public string user_file_name { get; set; }
        public string content { get; set; }
        public string attachmentType { get; set; }

      public  DakFileUploadParam()
        {
            this.path = "Dak";
            this.model = "NothiOnucchedAttachments";
        }
    }
}
