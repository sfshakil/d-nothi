using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class AttachmentDTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int note_onucched_id { get; set; }
        public string attachment_type { get; set; }
        public string file_name { get; set; }
        public string user_file_name { get; set; }
        public string file_dir { get; set; }
        public int digital_sign { get; set; }
        public string sign_info { get; set; }
        public string file_size_in_kb { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
        public string delete_token { get; set; }
    }
}
