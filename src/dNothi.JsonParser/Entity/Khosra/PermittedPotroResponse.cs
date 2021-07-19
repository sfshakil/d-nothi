using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Khosra
{
   public class PermittedPotroResponse
    {
        public string status { get; set; }
        public PermittedPotroResponseDataDTO data { get; set; }
        public List<object> options { get; set; }
    }



 
    public class PermittedPotroResponseBasicDTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public string potro_media { get; set; }
        public int potro_pages { get; set; }
        public string sarok_no { get; set; }
        public string issue_date { get; set; }
        public string application_origin { get; set; }
        public string application_meta_data { get; set; }
        public string subject { get; set; }
    }

    public class PermittedPotroResponseMulpotroDTO
    {
        public long id { get; set; }
        public int nothi_potro_page { get; set; }
        public string sarok_no { get; set; }
        public string attachment_type { get; set; }
        public string attachment_description { get; set; }
        public string file_name { get; set; }
        public string user_file_name { get; set; }
        public string file_dir { get; set; }
        public double file_size_in_kb { get; set; }
        public string potro_cover { get; set; }
        public string content_body { get; set; }
        public string meta_data { get; set; }
        public string application_origin { get; set; }
        public int is_main { get; set; }
        public int potrojari_id { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
        public int cloned_potrojari_id { get; set; }


     
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int nothijato { get; set; }
    


       
      
        public List<string> buttons { get; set; }

    }

    public class PermittedPotroResponseRecordDTO
    {
        public PermittedPotroResponseBasicDTO basic { get; set; }
        public PermittedPotroResponseMulpotroDTO mulpotro { get; set; }
        public List<PermittedPotroResponseMulpotroDTO> attachment { get; set; }
    }

    public class PermittedPotroResponseDataDTO
    {
        public List<PermittedPotroResponseRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

   


}
