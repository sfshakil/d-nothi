using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
    public class DakAttachmentDTO
    {
       
        public int id { get; set; }
        public int is_main { get; set; }
        public string attachment_type { get; set; }
        public string dak_description { get; set; }
        public string img_base64 { get; set; }
        public string attachment_description { get; set; }
        public string content_cover { get; set; }
        public string content_body { get; set; }
        public string meta_data { get; set; }
        public int is_summary_nothi { get; set; }
        public string created { get; set; }
        public string file_name { get; set; }
        public string user_file_name { get; set; }
        public string file_dir { get; set; }
        public string file_size_in_kb { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
       


      
        public string file_url { get; set; }
        
        public string file_thumbnail { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_token { get; set; }
        public string designation_id { get; set; }
        public string office_id { get; set; }
        public string path { get; set; }
   


       
      
        public string file_custom_name { get; set; }
    
        public int dak_type { get; set; }
        public int dak_id { get; set; }
   
        public string modified { get; set; }
        public string delete_url { get; set; }
        

        public int attachment_id
        { get
            {
                return id;
            }
              
                
        }




    }
}
