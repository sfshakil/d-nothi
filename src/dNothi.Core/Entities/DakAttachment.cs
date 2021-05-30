using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakAttachment : BaseEntity
    {
        [ForeignKey("dak_list")]
        public long dak_list_id { get; set; }
        public virtual DakList dak_list { get; set; }

        public long attachment_id { get; set; }
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
    }
}
