using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothivuktoPotroDataRecordMulpotroDTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int nothijato { get; set; }
        public int nothi_potro_page { get; set; }
        public string sarok_no { get; set; }
        public string attachment_type { get; set; }
        public string attachment_description { get; set; }
        public string file_name { get; set; }
        public string user_file_name { get; set; }
        public string file_dir { get; set; }
        public string potro_cover { get; set; }
        public string content_body { get; set; }
        public string meta_data { get; set; }
        public string application_origin { get; set; }
        public int is_main { get; set; }
        public int potrojari_id { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
        public object buttons { get; set; }
        public List<String> buttonsDTOList { get; set; }
    }
}
