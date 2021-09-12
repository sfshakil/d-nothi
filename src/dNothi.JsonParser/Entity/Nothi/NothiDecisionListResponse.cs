using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    
    public class NothiDecisionListResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public DataDTO Data { get; set; }

        [JsonProperty("options")]
        public object[] Options { get; set; }
    }
    public class NothiDecisionListAddResponse
    {
        public string status { get; set; }
        public string data { get; set; }
        public List<object> options { get; set; }
    }
    public class DataDTO
    {
        public List<RecordsDTO> records { get; set; }
        public int total_records { get; set; }
    }
    public class RecordsDTO
    {
        public int id { get; set; }
        public string decisions { get; set; }
        public int officer_id { get; set; }
        public int status { get; set; }
        public int decisions_employee { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class GaurdFileAttachment
    {
        public int id { get; set; }
        public int guard_file_id { get; set; }
        public string name_bng { get; set; }
        public string attachment_type { get; set; }
        public string user_file_name { get; set; }
        public string file_name { get; set; }
        public string file_custom_name { get; set; }
        public string file_dir { get; set; }
        public double file_size_in_kb { get; set; }
        public string created { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
    }

    public class GaurdFileRecord
    {
        public string name_bng { get; set; }
        public int id { get; set; }
        public int file_number { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public int guard_file_category_id { get; set; }
        public string guard_file_category_name_bng { get; set; }
        public int includedGuardFileCount { get; set; }
        public GaurdFileAttachment attachment { get; set; }
    }

    public class GaurdFileData
    {
        public List<GaurdFileRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class NothiGaurdFileListResponse
    {
        public string status { get; set; }
        public GaurdFileData data { get; set; }
        public List<object> options { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BibechhoPotroBasic
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

    public class BibechhoPotroMulpotro
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
        public List<string> buttons { get; set; }
    }

    public class BibechhoPotroNoteOwner
    {
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_office { get; set; }
        public int note_no { get; set; }
        public string note_subject { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public int office_id { get; set; }
        public string office { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit { get; set; }
        public int designation_id { get; set; }
        public string designation { get; set; }
        public string issue_date { get; set; }
        public string note_current_status { get; set; }
        public int priority { get; set; }
        public int onucched_count { get; set; }
        public int attachment_count { get; set; }
        public int khoshra_potro { get; set; }
        public int khoshra_waiting_for_approval { get; set; }
        public int approved_potro { get; set; }
        public int potrojari { get; set; }
        public int nothivukto_potro { get; set; }
        public int is_migrated { get; set; }
        public int shared_nothi_count { get; set; }
    }

    public class BibechhoPotroNoteOnucched
    {
        public int id { get; set; }
        public int decision_id { get; set; }
        public string subject { get; set; }
        public string onucched_no { get; set; }
    }

    public class BibechhoPotroRecord
    {
        public BibechhoPotroBasic basic { get; set; }
        public BibechhoPotroMulpotro mulpotro { get; set; }
        public BibechhoPotroNoteOwner note_owner { get; set; }
        public BibechhoPotroNoteOnucched note_onucched { get; set; }
    }

    public class BibechhoPotroData
    {
        public List<BibechhoPotroRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class NothiBibechhoPotroResponse
    {
        public string status { get; set; }
        public BibechhoPotroData data { get; set; }
        public List<object> options { get; set; }
    }

    public class OnuchhedListData
    {
        public int onucched_id { get; set; }
        public int note_id { get; set; }
        public int note_no { get; set; }
        public string note_subject { get; set; }
        public string value { get; set; }
    }

    public class NothiOnuchhedListResponse
    {
        public string status { get; set; }
        public List<OnuchhedListData> data { get; set; }
        public List<object> options { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PotakaListAttachment
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int nothijato { get; set; }
        public int is_main { get; set; }
        public int nothi_potro_page { get; set; }
        public string nothi_potro_page_bn { get; set; }
        public string sarok_no { get; set; }
        public string attachment_type { get; set; }
        public string attachment_description { get; set; }
        public string file_name { get; set; }
        public string user_file_name { get; set; }
        public double file_size_in_kb { get; set; }
        public string file_dir { get; set; }
        public string potro_cover { get; set; }
        public string content_body { get; set; }
        public string meta_data { get; set; }
        public int potrojari { get; set; }
        public int potrojari_id { get; set; }
        public string potrojari_status { get; set; }
        public int is_summary_nothi { get; set; }
        public int is_approved { get; set; }
        public int status { get; set; }
        public string application_origin { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
    }

    public class PotakaListRecord
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string color { get; set; }
        public string title { get; set; }
        public int potro_attachment_id { get; set; }
        public int page_no { get; set; }
        public string created { get; set; }
        public PotakaListAttachment attachment { get; set; }
    }

    public class PotakaListData
    {
        public List<PotakaListRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class NothiPotakaListResponse
    {
        public string status { get; set; }
        public PotakaListData data { get; set; }
        public List<object> options { get; set; }
    }

    public class NothiDecisionListDeleteData
    {
        public string status { get; set; }
        public string data { get; set; }
    }

    public class NothiDecisionListDeleteResponse
    {
        public string status { get; set; }
        public NothiDecisionListDeleteData data { get; set; }
        public List<object> options { get; set; }
    }
    public class NothiPotakaData
    {
        public string title { get; set; }
        public string color { get; set; }
        public int page_no { get; set; }
        public string page_number { get; set; }
        public int potro_attachment_id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string created { get; set; }
        public int id { get; set; }
    }

    public class NothiPotakaResponse
    {
        public string status { get; set; }
        public List<NothiPotakaData> data { get; set; }
        public List<object> options { get; set; }
    }

}
