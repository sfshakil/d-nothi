﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiReviewerDTO
    {
        public Nothi nothi { get; set; }
        public List<User> users { get; set; }
    }
    public class Nothi
    {
        public int id { get; set; }
        public string shared_status { get; set; }
    }

    public class User
    {
        public string recipient_type { get; set; }
        public string sms_message { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public string group_member { get; set; }
        public string group_display { get; set; }
        public string office_id { get; set; }
        public string office_unit_id { get; set; }
        public string designation_id { get; set; }
        public string officer_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string officer { get; set; }
        public string officer_email { get; set; }
        public string officer_mobile { get; set; }
        public string review_mode { get; set; }
        public string user_id { get; set; }
        public string designation_level { get; set; }
        public string designation_sequence { get; set; }
    }
    public class NothiSharedData
    {
        public List<object> data { get; set; }
    }

    public class NothiSharedOffDTO
    {
        public string status { get; set; }
        public NothiSharedData data { get; set; }
        public List<object> options { get; set; }
    }
    public class NothiSharedSaveData
    {
        public int data { get; set; }
    }

    public class NothiSharedSaveDTO
    {
        public string status { get; set; }
        public NothiSharedSaveData data { get; set; }
        public List<object> options { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class NothiShaeredByMeRecordUser
    {
        public int shared_nothi_id { get; set; }
        public string review_mode { get; set; }
        public string modified { get; set; }
    }

    public class NothiDetail
    {
        public string share_module { get; set; }
        public string nothi_no { get; set; }
        public string nothi_subject { get; set; }
        public string note_no { get; set; }
        public string note_subject { get; set; }
        public string onucched_no { get; set; }
        public string potro_subject { get; set; }
        public string potro_type { get; set; }
        public string sarok_no { get; set; }
    }

    public class NothiShaeredByMeRecordNothi
    {
        public NothiDetail nothi_detail { get; set; }
        public List<object> committed_by_designation_detail { get; set; }
        public int id { get; set; }
        public string shared_status { get; set; }
        public int onucched_id { get; set; }
        public int potrojari_id { get; set; }
        public string type { get; set; }
    }

    public class NothiShaeredByMeRecord
    {
        public NothiShaeredByMeRecordUser user { get; set; }
        public NothiShaeredByMeRecordNothi nothi { get; set; }
    }

    public class NothiShaeredByMeDTO
    {
        public int total_records { get; set; }
        public List<NothiShaeredByMeRecord> records { get; set; }
    }


}
