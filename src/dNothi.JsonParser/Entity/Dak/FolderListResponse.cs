using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public  class FolderListResponse
    {
        public string status { get; set; }
        public FolderListDataDTO data { get; set; }
    }

    

    public class FolderDTO
    {
        public int id { get; set; }
        public int parent { get; set; }
        public string custom_name { get; set; }
        public int open_for_all { get; set; }
        public int dak_count { get; set; }
    }

    public class FolderListDataDTO
    {
        [JsonProperty("private")]
        public List<FolderDTO> _privateFolder { get; set; }


        [JsonProperty("public")]

        public List<FolderDTO> publicFOlder { get; set; }
    }

  
        
    
}
