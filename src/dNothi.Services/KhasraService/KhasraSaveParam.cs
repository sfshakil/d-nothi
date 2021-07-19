using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KhasraService
{
   
    public class KhosraSaveParamPotro
    {
        public KhasraSaveParamPotrojari potrojari { get; set; }
        public KhosraSaveParamRecipent recipient { get; set; }
        public List<string> attachment { get; set; }

    }

    public class KhosraSaveParamRecipent
    {
        public Dictionary<string, KhosraSaveParamOfficer> receiver { get; set; }
        public Dictionary<string, KhosraSaveParamOfficer> sender { get; set; }
        public Dictionary<string, KhosraSaveParamOfficer> onulipi { get; set; }
        public Dictionary<string, KhosraSaveParamOfficer> approver { get; set; }
        public Dictionary<string, KhosraSaveParamOfficer> attention { get; set; }

    }



    public class KhosraSaveParamOfficer
    {
        public string id { get; set; }


        public string recipient_type { get; set; }
        public string sms_message { get; set; }


        public string task_response { get; set; }
        public string potrojari_id { get; set; }
        public string potro_status { get; set; }
        public string is_sent { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public string group_member { get; set; }
        public string group_display { get; set; }
        public string office_id { get; set; }
        public string office { get; set; }
        public string office_unit_id { get; set; }
        public string office_unit { get; set; }
        public string officer_id { get; set; }
        public string designation_id { get; set; }
        public string designation { get; set; }
        public string officer { get; set; }
        public string officer_email { get; set; }
        public string visible_name { get; set; }
        public string office_head { get; set; }
        public string label { get; set; }

    }



    public class KhasraSaveParamPotrojari
    {
        public int potro_type { get; set; }
        public long id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public string note_subject { get; set; }
        public int note_onucched_id { get; set; }
        public int nothi_potro_attachment_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int cloned_potrojari_id { get; set; }
        public string operation_type { get; set; }
        public string potro_description { get; set; }
        public string potro_cover { get; set; }
        public string meta_data { get; set; }
        public string potro_subject { get; set; }
        public int potro_security_level { get; set; }
        public int potro_priority_level { get; set; }
        public string attached_potro { get; set; }
        public string sarok_no { get; set; }
        public int draft_officer_id { get; set; }
    }


    public class KhosraPotroSaveAttachment
    {
        public long id { get; set; }
        public long nothi_potro_id { get; set; }
        public long nothi_potro_attachment_id { get; set; }
        public string user_file_name { get; set; }
    }
}
