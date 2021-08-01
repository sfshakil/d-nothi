using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dNothi.JsonParser.Entity
{
   public class RegisterReportResponse
    {
        public string status { get; set; }
        public RegisterReportDataDTO data { get; set; }

       
    }


    public class RegisterReportDakDaptoriksDTO
    {
        public string sender_sarok_no { get; set; }
        public string sender_office_name { get; set; }
        public string sender_office_unit_name { get; set; }
        public string sender_officer_designation_label { get; set; }
        public string sender_name { get; set; }
        public string dak_received_no { get; set; }
        public string dak_sending_media { get; set; }
        public string docketing_no { get; set; }
        public string dak_subject { get; set; }
        public string dak_security_level { get; set; }
    }

    public class RegisterReportDakNagoriksDTO
    {
        public string docketing_no { get; set; }
        public string dak_subject { get; set; }
        public string dak_received_no { get; set; }
        public string dak_security_level { get; set; }
        public string sender_name { get; set; }
    }

    public class RegisterReportMainPrapokDTO
    {
        public int id { get; set; }
        public string dak_type { get; set; }
        public string dak_origin { get; set; }
        public int dak_dagorik_type { get; set; }
        public int dak_id { get; set; }
        public int is_copied_dak { get; set; }
        public int from_office_id { get; set; }
        public string from_office_name { get; set; }
        public int from_office_unit_id { get; set; }
        public string from_office_unit_name { get; set; }
        public string from_office_address { get; set; }
        public int from_officer_id { get; set; }
        public string from_officer_name { get; set; }
        public int from_officer_designation_id { get; set; }
        public string from_officer_designation_label { get; set; }
        public int to_office_id { get; set; }
        public string to_office_name { get; set; }
        public int to_office_unit_id { get; set; }
        public string to_office_unit_name { get; set; }
        public string to_office_address { get; set; }
        public int to_officer_id { get; set; }
        public string to_officer_name { get; set; }
        public int to_officer_designation_id { get; set; }
        public string to_officer_designation_label { get; set; }
        public string attention_type { get; set; }
        public int docketing_no { get; set; }
        public string from_sarok_no { get; set; }
        public string to_sarok_no { get; set; }
        public string operation_type { get; set; }
        public string dak_actions { get; set; }
        public int from_potrojari { get; set; }
        public int is_summary_nothi { get; set; }
        public int sequence { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public int dak_priority { get; set; }
        public string dak_security_level { get; set; }
        public string last_movement_date { get; set; }
        public string device_type { get; set; }
        public string device_id { get; set; }
    }

    public class RegisterReportRecordDTO
    {
        public string daptorikCreated { get; set; }
        public string nagorikCreated { get; set; }
        public int id { get; set; }
        public string dak_type { get; set; }
        public string from_office_name { get; set; }
        public string from_office_unit_name { get; set; }
        public string from_officer_name { get; set; }
        public string from_officer_designation_label { get; set; }
        public int dak_id { get; set; }
        public string to_office_name { get; set; }
        public int to_office_unit_id { get; set; }
        public string to_office_unit_name { get; set; }
        public string to_officer_name { get; set; }
        public string to_officer_designation_label { get; set; }
        public string operation_type { get; set; }
        public int sequence { get; set; }
        public string attention_type { get; set; }
        public string dak_actions { get; set; }
        public string created { get; set; }
        public int is_summary_nothi { get; set; }
        public int dak_priority { get; set; }
        public RegisterReportDakDaptoriksDTO DakDaptoriks { get; set; }
        public RegisterReportDakNagoriksDTO DakNagoriks { get; set; }
        public List<RegisterReportMainPrapokDTO> mainPrapok { get; set; }
        public RegisterNothiPartsDTO NothiParts { get; set; }
        public RegisterNothiPotroDTO NothiPotros { get; set; }


        public int is_copied_dak { get; set; }
        public string sender_sarok_no { get; set; }
       
        public string sender_name { get; set; }
        public string sender_office_unit_name { get; set; }
        public string sender_officer_designation_label { get; set; }
        public string sender_office_name { get; set; }
        public string dak_subject { get; set; }

       

    }

    public class RegisterNothiPartsDTO
    {
        public string nothi_no { get; set; }
        public string nothi_master_id { get; set; }
    }

    public class RegisterNothiPotroDTO
    {
        public string created { get; set; }
        public string sarok_no { get; set; }
    }

    public class RegisterReportDataDTO
    {
        public List<RegisterReportRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

   


    
}
