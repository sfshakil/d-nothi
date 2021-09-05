using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiListOutboxResponse
    {
        public string status { get; set; }
        public NothiListOutboxDTO data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OtherOfficeNothi
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public int nothi_class { get; set; }
        public string modified { get; set; }
        public string last_note_date { get; set; }
    }

    public class OtherOfficeTo
    {
        public int office_id { get; set; }
        public string office { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit { get; set; }
        public int designation_id { get; set; }
        public string designation { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public int view_status { get; set; }
        public string issue_date { get; set; }
        public int priority { get; set; }
    }

    public class OtherOfficeDesk
    {
        public string note_subject { get; set; }
        public int note_no { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_office { get; set; }
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
        public int is_archive { get; set; }
        public int is_finished { get; set; }
        public int is_migrated { get; set; }
        public int shared_nothi_count { get; set; }
    }

    public class OtherOfficeNothiListOutboxDataRecord
    {
        public OtherOfficeNothi nothi { get; set; }
        public OtherOfficeTo to { get; set; }
        public OtherOfficeDesk desk { get; set; }
    }

    public class OtherOfficeNothiListOutboxData
    {
        public List<OtherOfficeNothiListOutboxDataRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class OtherOfficeNothiListOutboxResponse
    {
        public string status { get; set; }
        public OtherOfficeNothiListOutboxData data { get; set; }
        public List<object> options { get; set; }
    }


}
