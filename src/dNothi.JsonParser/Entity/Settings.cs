using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
    public class Settings
    {
        public int nothiInboxPagination { get; set; }
        public int nothiSentPagination { get; set; }
        public int nothiAllPagination { get; set; }
        public int othersOfficeNothiInboxPagination { get; set; }
        public int othersOfficeNothiSentPagination { get; set; }
        public int dakInboxPagination { get; set; }
        public int dakSentPagination { get; set; }
        public int dakNothiteUposthapitoPagination { get; set; }
        public int dakNothijatoPagination { get; set; }
        public int dakArchaivePagination { get; set; }
        public int dakKhoshraPagination { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EmailActions
    {
        public string dak_receive { get; set; }
        public string nothi_permission { get; set; }
        public string note_permission { get; set; }
        public int note_receive { get; set; }
        public int potrojari_receive { get; set; }
    }

    public class PushActions
    {
        public string dak_receive { get; set; }
        public string nothi_permission { get; set; }
        public string note_permission { get; set; }
        public string note_receive { get; set; }
        public string potrojari_receive { get; set; }
    }

    public class SmsActions
    {
        public int dak_receive { get; set; }
        public int nothi_permission { get; set; }
        public int note_permission { get; set; }
        public int note_receive { get; set; }
        public int potrojari_receive { get; set; }
    }

    public class NotificationSettingsData
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int officer_id { get; set; }
        public string officer_name { get; set; }
        public int designation_id { get; set; }
        public int user_id { get; set; }
        public string designation { get; set; }
        public EmailActions email_actions { get; set; }
        public PushActions push_actions { get; set; }
        public SmsActions sms_actions { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
    }

    public class NotificationSettingsResponse
    {
        public string status { get; set; }
        public NotificationSettingsData data { get; set; }
        public List<object> options { get; set; }
    }

    public class NotificationSettingsSaveResponse
    {
        public string status { get; set; }
        public string data { get; set; }
        public List<object> options { get; set; }
    }

}
