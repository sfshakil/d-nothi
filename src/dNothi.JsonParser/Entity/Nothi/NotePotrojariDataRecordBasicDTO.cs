using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NotePotrojariDataRecordBasicDTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int note_onucched_id { get; set; }
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public int nothijato { get; set; }
        public int potrojari_id { get; set; }
        public string potro_media { get; set; }
        public int potro_pages { get; set; }
        public string subject { get; set; }
        public string sarok_no { get; set; }
        public string page_numbers { get; set; }
        public string due_date { get; set; }
        public string issue_date { get; set; }
        public string potro_content { get; set; }
        public string meta_data { get; set; }
        public int is_deleted { get; set; }
        public string application_origin { get; set; }
        public string application_meta_data { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string dak_json { get; set; }
        public string noter_potro_json { get; set; }
        public string note_json { get; set; }
        public int permitted { get; set; }
        public string last_update_date { get; set; }
        public string potro_subject { get; set; }
    }
}
