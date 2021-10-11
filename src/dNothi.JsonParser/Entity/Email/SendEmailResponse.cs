using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Email
{
   public class SendEmailResponse
    {
        public string status { get; set; }
        public SendEmailResponseData data { get; set; }
        public List<object> options { get; set; }
    }

    public class Resource
    {
        public string nothi_id { get; set; }
        public int note_id { get; set; }
        public int? dak_id { get; set; }
        public string dak_type { get; set; }
        public int? is_copied_dak { get; set; }
    }

    public class SendEmailDataInfo
    {
        public int nothi_id { get; set; }
        public string nothi_no { get; set; }
        public string nothi_subject { get; set; }
        public int? id { get; set; }
        public int? receiving_office_id { get; set; }
        public string dak_description { get; set; }
        public string receipt_no { get; set; }
        public int? docketing_no { get; set; }
        public string dak_subject { get; set; }
        public bool? from_potrojari { get; set; }
        public int? is_rollback_dak { get; set; }
        public string application_meta_data { get; set; }
        public int? is_summary_nothi { get; set; }
        public string dak_type { get; set; }
        public string dak_origin { get; set; }
        public int? origin_dak_id { get; set; }
        public int? parent_dak_id { get; set; }
        public int? is_copied_dak { get; set; }
        public string sarok_no { get; set; }
    }

    public class SendEmailReceiver
    {
        public string officer_id { get; set; }
        public string designation_id { get; set; }
        public string office_id { get; set; }
        public string officer { get; set; }
        public string office_unit { get; set; }
        public string office_unit_id { get; set; }
        public string office { get; set; }
        public string designation { get; set; }
        public string officer_email { get; set; }
    }

    public class SendEmailSender
    {
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public int officer_id { get; set; }
        public int user_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string officer { get; set; }
        public int designation_level { get; set; }
        public int designation_sequence { get; set; }
        public string officer_email { get; set; }
        public string officer_mobile { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string incharge_label { get; set; }
        public int? attention_type { get; set; }
        public string officer_phone { get; set; }
    }

    public class SendEmailRecipients
    {
        public List<SendEmailReceiver> receiver { get; set; }
        public List<object> onulipi { get; set; }
        public SendEmailSender sender { get; set; }
        public List<object> uploader { get; set; }
    }

    public class SendEmailRecord
    {
        public int id { get; set; }
        public string module { get; set; }
        public string operation_type { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int officer_id { get; set; }
        public string officer_name { get; set; }
        public int designation_id { get; set; }
        public int user_id { get; set; }
        public string designation { get; set; }
        public object created_by { get; set; }
        public object modified_by { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public Resource resource { get; set; }
        public SendEmailDataInfo data_info { get; set; }
        public SendEmailRecipients recipients { get; set; }
    }

    public class SendEmailResponseData
    {
        public List<SendEmailRecord> records { get; set; }
        public int total_records { get; set; }
    }

   
}
