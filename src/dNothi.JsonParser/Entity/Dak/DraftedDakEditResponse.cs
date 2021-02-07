using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
  public  class DraftedDakEditResponse
    {
        public string status { get; set; }
        public DraftedDakEditDataDTO data { get; set; }
    }
    public class DraftedDakEditDataDTO
    {
        public Receiver receiver { get; set; }
        public DakInfoDTO dak { get; set; }
    }

    public class Receiver
    {
        public PrapokDTO mul_prapok { get; set; }
        public Dictionary<string, PrapokDTO> Onulipi { get; set; }
    }
    public class DakInfoDTO
    {
        public int id { get; set; }
        public string sender_sarok_no { get; set; }
        public int sender_office_id { get; set; }
        public int sender_officer_id { get; set; }
        public string sender_office_name { get; set; }
        public int sender_office_unit_id { get; set; }
        public string sender_office_unit_name { get; set; }
        public int sender_officer_designation_id { get; set; }
        public string sender_officer_designation_label { get; set; }
        public string sending_date { get; set; }
        public string sender_name { get; set; }
        public string sender_address { get; set; }
        public string sender_email { get; set; }
        public string sender_phone { get; set; }
        public string sender_mobile { get; set; }
        public string dak_sending_media { get; set; }
        public string dak_received_no { get; set; }
        public int docketing_no { get; set; }
        public string receiving_date { get; set; }
        public string dak_subject { get; set; }
        public string dak_security_level { get; set; }
        public string dak_priority_level { get; set; }
        public string dak_cover { get; set; }
        public string dak_description { get; set; }
        public string meta_data { get; set; }
        public int receiving_office_id { get; set; }
        public string receiving_office_name { get; set; }
        public int receiving_office_unit_id { get; set; }
        public string receiving_office_unit_name { get; set; }
        public int receiving_officer_id { get; set; }
        public int receiving_officer_designation_id { get; set; }
        public string receiving_officer_designation_label { get; set; }
        public string receiving_officer_name { get; set; }
        public string dak_status { get; set; }
        public int is_summary_nothi { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public int uploader_designation_id { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string previous_receipt_no { get; set; }
        public string previous_docketing_no { get; set; }
        public int is_rollback_to_dak { get; set; }
        public bool from_potrojari { get; set; }
        public int potrojari_id { get; set; }



        public int dak_type_id { get; set; }
        public string name_eng { get; set; }
        public string name_bng { get; set; }
        public string national_idendity_no { get; set; }
        public string birth_registration_number { get; set; }
        public string passport { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string address { get; set; }
        public string parmanent_address { get; set; }
        public string email { get; set; }
        public string phone_no { get; set; }
        public string mobile_no { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string religion { get; set; }
        public int feedback_type { get; set; }
        public int nothi_master_id { get; set; }
        public string application_origin { get; set; }
        

        public List<DakAttachmentDTO> attachments { get; set; }
    }
}
