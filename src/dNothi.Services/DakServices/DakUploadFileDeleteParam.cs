using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public class DakUploadFileDeleteParam
    {
        public string file_name{get;set;}
        public string delete_token { get;set;}

        public long Id { get; set; }
    }
}
