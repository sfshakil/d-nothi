using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KasaraPatraDashBoardService.Models
{
    public class KasaraPotro
    {
        /*
        public class Basic
        {
            public int id { get; set; }
            public int potro_type { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int note_onucched_id { get; set; }
            public int nothi_potro_attachment_id { get; set; }
            public int nothi_potro_id { get; set; }
            public int dak_id { get; set; }
            public string is_endorsed { get; set; }
            public string sarok_no { get; set; }
            public string potrojari_date { get; set; }
            public string potro_subject { get; set; }
            public string potro_security_level { get; set; }
            public string potro_priority_level { get; set; }
            public string meta_data { get; set; }
            public string potro_status { get; set; }
            public int receiver_sent { get; set; }
            public int onulipi_sent { get; set; }
            public int is_summary_nothi { get; set; }
            public int digital_sign { get; set; }
            public string sign_info { get; set; }
            public int cloned_potrojari_id { get; set; }
            public int potrojari_internal { get; set; }
            public string potrojari_language { get; set; }
            public int draft_office_id { get; set; }
            public string draft_office_name { get; set; }
            public int draft_unit_id { get; set; }
            public string draft_unit_name { get; set; }
            public int draft_designation_id { get; set; }
            public string draft_designation_name { get; set; }
            public int draft_officer_id { get; set; }
            public string draft_officer_name { get; set; }
            public int shared_nothi_id { get; set; }
            public string noter_potro_json { get; set; }
            public string note_json { get; set; }
            public int attachment_count { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string page_numbers { get; set; }
            public int potro_pages { get; set; }
            public string dak_json { get; set; }
            public string last_update_date { get; set; }
            public string potro_type_name { get; set; }

           
        }

        public class Mulpotro
        {
            public string potro_description { get; set; }
            public string potro_cover { get; set; }
            public int id { get; set; }
            public List<string> buttons { get; set; }

        }

        public class NoteOwner
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
            public string nothi_subject { get; set; }
        }

        public class NoteOnucched
        {
            public int id { get; set; }
            public int decision_id { get; set; }
            public string subject { get; set; }
            public string onucched_no { get; set; }
        }

        public class EndorsePotro
        {
        }

        public class Onulipi
        {
            public int id { get; set; }
            public string task_response { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int group_id { get; set; }
            public string group_name { get; set; }
            public int group_member { get; set; }
            public string group_display { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public string visible_name { get; set; }
            public int office_head { get; set; }
            public string label { get; set; }
        }

        public class Approver
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }


        }

        public class Attention
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }


        }

        public class Sender
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }


        }
        public class Drafter
        {
            public string label { get; set; }
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int designation_id { get; set; }
            public string designation_name { get; set; }
            public int officer_id { get; set; }
            public string officer_name { get; set; }
        }
        public class Recipient
        {
            public List<Drafter> drafter { get; set; }
            public object receiver { get; set; }
            public List<Onulipi> onulipi { get; set; }
            public List<Approver> approver { get; set; }
            public List<Attention> attention { get; set; }
            public List<Sender> sender { get; set; }
            public int sent_status { get; set; }


        }
       
        public class Record
        {
            public Basic basic { get; set; }
            public Mulpotro mulpotro { get; set; }
            public NoteOwner note_owner { get; set; }
            public NoteOnucched note_onucched { get; set; }
            public EndorsePotro endorse_potro { get; set; }
            public Recipient recipient { get; set; }



        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }


        }
        public string status { get; set; }
        public Data data { get; set; }
        public List<object> options { get; set; }
        */


        
        public class Basic
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("potro_type")]
            public int PotroType { get; set; }

            [JsonProperty("nothi_master_id")]
            public int NothiMasterId { get; set; }

            [JsonProperty("nothi_note_id")]
            public int NothiNoteId { get; set; }

            [JsonProperty("note_onucched_id")]
            public int NoteOnucchedId { get; set; }

            [JsonProperty("nothi_potro_attachment_id")]
            public int NothiPotroAttachmentId { get; set; }

            [JsonProperty("nothi_potro_id")]
            public int NothiPotroId { get; set; }

            [JsonProperty("dak_id")]
            public int DakId { get; set; }

            [JsonProperty("is_endorsed")]
            public string IsEndorsed { get; set; }

            [JsonProperty("sarok_no")]
            public string SarokNo { get; set; }

            [JsonProperty("potrojari_date")]
            public string PotrojariDate { get; set; }

            [JsonProperty("potro_subject")]
            public string PotroSubject { get; set; }

            [JsonProperty("potro_security_level")]
            public string PotroSecurityLevel { get; set; }

            [JsonProperty("potro_priority_level")]
            public string PotroPriorityLevel { get; set; }

            [JsonProperty("meta_data")]
            public string MetaData { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("receiver_sent")]
            public int ReceiverSent { get; set; }

            [JsonProperty("onulipi_sent")]
            public int OnulipiSent { get; set; }

            [JsonProperty("is_summary_nothi")]
            public int IsSummaryNothi { get; set; }

            [JsonProperty("digital_sign")]
            public int DigitalSign { get; set; }

            [JsonProperty("sign_info")]
            public string SignInfo { get; set; }

            [JsonProperty("cloned_potrojari_id")]
            public int ClonedPotrojariId { get; set; }

            [JsonProperty("potrojari_internal")]
            public int PotrojariInternal { get; set; }

            [JsonProperty("potrojari_language")]
            public string PotrojariLanguage { get; set; }

            [JsonProperty("draft_office_id")]
            public int DraftOfficeId { get; set; }

            [JsonProperty("draft_office_name")]
            public string DraftOfficeName { get; set; }

            [JsonProperty("draft_unit_id")]
            public int DraftUnitId { get; set; }

            [JsonProperty("draft_unit_name")]
            public string DraftUnitName { get; set; }

            [JsonProperty("draft_designation_id")]
            public int DraftDesignationId { get; set; }

            [JsonProperty("draft_designation_name")]
            public string DraftDesignationName { get; set; }

            [JsonProperty("draft_officer_id")]
            public int DraftOfficerId { get; set; }

            [JsonProperty("draft_officer_name")]
            public string DraftOfficerName { get; set; }

            [JsonProperty("shared_nothi_id")]
            public int SharedNothiId { get; set; }

            [JsonProperty("noter_potro_json")]
            public string NoterPotroJson { get; set; }

            [JsonProperty("note_json")]
            public string NoteJson { get; set; }

            [JsonProperty("attachment_count")]
            public int AttachmentCount { get; set; }

            [JsonProperty("created")]
            public string Created { get; set; }

            [JsonProperty("modified")]
            public string Modified { get; set; }

            [JsonProperty("page_numbers")]
            public string PageNumbers { get; set; }

            [JsonProperty("potro_pages")]
            public int PotroPages { get; set; }

            [JsonProperty("dak_json")]
            public string DakJson { get; set; }

            [JsonProperty("last_update_date")]
            public string LastUpdateDate { get; set; }

            [JsonProperty("potro_type_name")]
            public string PotroTypeName { get; set; }

        }

        public class Mulpotro
        {
            [JsonProperty("potro_description")]
            public string PotroDescription { get; set; }

            [JsonProperty("potro_cover")]
            public string PotroCover { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("buttons")]
            public List<string> Buttons { get; set; }





            
            
        }

        public class NoteOwner
        {
            [JsonProperty("nothi_master_id")]
            public int NothiMasterId { get; set; }

            [JsonProperty("nothi_note_id")]
            public int NothiNoteId { get; set; }

            [JsonProperty("nothi_office")]
            public int NothiOffice { get; set; }

            [JsonProperty("note_no")]
            public int NoteNo { get; set; }

            [JsonProperty("note_subject")]
            public string NoteSubject { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("issue_date")]
            public string IssueDate { get; set; }

            [JsonProperty("note_current_status")]
            public string NoteCurrentStatus { get; set; }

            [JsonProperty("priority")]
            public int Priority { get; set; }

            [JsonProperty("onucched_count")]
            public int OnucchedCount { get; set; }

            [JsonProperty("attachment_count")]
            public int AttachmentCount { get; set; }

            [JsonProperty("khoshra_potro")]
            public int KhoshraPotro { get; set; }

            [JsonProperty("khoshra_waiting_for_approval")]
            public int KhoshraWaitingForApproval { get; set; }

            [JsonProperty("approved_potro")]
            public int ApprovedPotro { get; set; }

            [JsonProperty("potrojari")]
            public int Potrojari { get; set; }

            [JsonProperty("nothivukto_potro")]
            public int NothivuktoPotro { get; set; }

            [JsonProperty("is_migrated")]
            public int IsMigrated { get; set; }

            [JsonProperty("shared_nothi_count")]
            public int SharedNothiCount { get; set; }

            [JsonProperty("nothi_subject")]
            public string NothiSubject { get; set; }

              
           
        }

        public class NoteOnucched
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("decision_id")]
            public int DecisionId { get; set; }

            [JsonProperty("subject")]
            public string Subject { get; set; }

            [JsonProperty("onucched_no")]
            public string OnucchedNo { get; set; }

        }

        public class EndorsePotro
        {
        }
        public class Drafter
        {
            [JsonProperty("label")]
            public string Label { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office_name")]
            public string OfficeName { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit_name")]
            public string OfficeUnitName { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation_name")]
            public string DesignationName { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("officer_name")]
            public string OfficerName { get; set; }

        }

        public class Receiver
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("task_response")]
            public string TaskResponse { get; set; }

            [JsonProperty("potrojari_id")]
            public int PotrojariId { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("is_sent")]
            public int IsSent { get; set; }

            [JsonProperty("group_id")]
            public int GroupId { get; set; }

            [JsonProperty("group_name")]
            public string GroupName { get; set; }

            [JsonProperty("group_member")]
            public int GroupMember { get; set; }

            [JsonProperty("group_display")]
            public string GroupDisplay { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("officer_email")]
            public string OfficerEmail { get; set; }

            [JsonProperty("visible_name")]
            public string VisibleName { get; set; }

            [JsonProperty("office_head")]
            public int OfficeHead { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }
        }

        public class Onulipi
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("task_response")]
            public string TaskResponse { get; set; }

            [JsonProperty("potrojari_id")]
            public int PotrojariId { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("is_sent")]
            public int IsSent { get; set; }

            [JsonProperty("group_id")]
            public int GroupId { get; set; }

            [JsonProperty("group_name")]
            public string GroupName { get; set; }

            [JsonProperty("group_member")]
            public int GroupMember { get; set; }

            [JsonProperty("group_display")]
            public string GroupDisplay { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("officer_email")]
            public string OfficerEmail { get; set; }

            [JsonProperty("visible_name")]
            public string VisibleName { get; set; }

            [JsonProperty("office_head")]
            public int OfficeHead { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }

        }

        public class Approver
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("potrojari_id")]
            public int PotrojariId { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("is_sent")]
            public int IsSent { get; set; }

            [JsonProperty("potro_type")]
            public int PotroType { get; set; }

            [JsonProperty("recipient_type")]
            public string RecipientType { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("officer_email")]
            public string OfficerEmail { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("visible_name")]
            public string VisibleName { get; set; }

            [JsonProperty("visible_designation")]
            public string VisibleDesignation { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }

            
        }

        public class Attention
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("potrojari_id")]
            public int PotrojariId { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("is_sent")]
            public int IsSent { get; set; }

            [JsonProperty("potro_type")]
            public int PotroType { get; set; }

            [JsonProperty("recipient_type")]
            public string RecipientType { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("officer_email")]
            public string OfficerEmail { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("visible_name")]
            public string VisibleName { get; set; }

            [JsonProperty("visible_designation")]
            public string VisibleDesignation { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }
        }

        public class Sender
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("potrojari_id")]
            public int PotrojariId { get; set; }

            [JsonProperty("potro_status")]
            public string PotroStatus { get; set; }

            [JsonProperty("is_sent")]
            public int IsSent { get; set; }

            [JsonProperty("potro_type")]
            public int PotroType { get; set; }

            [JsonProperty("recipient_type")]
            public string RecipientType { get; set; }

            [JsonProperty("office_id")]
            public int OfficeId { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("office_unit_id")]
            public int OfficeUnitId { get; set; }

            [JsonProperty("office_unit")]
            public string OfficeUnit { get; set; }

            [JsonProperty("officer_id")]
            public int OfficerId { get; set; }

            [JsonProperty("officer")]
            public string Officer { get; set; }

            [JsonProperty("officer_email")]
            public string OfficerEmail { get; set; }

            [JsonProperty("designation_id")]
            public int DesignationId { get; set; }

            [JsonProperty("designation")]
            public string Designation { get; set; }

            [JsonProperty("visible_name")]
            public string VisibleName { get; set; }

            [JsonProperty("visible_designation")]
            public string VisibleDesignation { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }
        }

        public class Recipient
        {
            [JsonProperty("drafter")]
            public List<Drafter> Drafter { get; set; }

            [JsonProperty("receiver")]
            // public List<Receiver> Receiver { get; set;  }
            public object Receiver { get; set; }
            [JsonProperty("onulipi")]
            /// public List<Onulipi> Onulipi { get; set; }
            public object Onulipi { get; set; }
            [JsonProperty("approver")]
            public List<Approver> Approver { get; set; }

            [JsonProperty("attention")]
            public List<Attention> Attention { get; set; }

            [JsonProperty("sender")]
            public List<Sender> Sender { get; set; }

            [JsonProperty("sent_status")]
            public int SentStatus { get; set; }
        }

        public class Record
        {
            [JsonProperty("basic")]
            public Basic Basic { get; set; }

            [JsonProperty("mulpotro")]
            public Mulpotro Mulpotro { get; set; }

            [JsonProperty("note_owner")]
            public NoteOwner NoteOwner { get; set; }

            [JsonProperty("note_onucched")]
            public NoteOnucched NoteOnucched { get; set; }

            [JsonProperty("endorse_potro")]
            public EndorsePotro EndorsePotro { get; set; }

            [JsonProperty("recipient")]
            public Recipient Recipient { get; set; }

            public bool isLocal { get; set; }

        }

        public class Data
        {
            [JsonProperty("records")]
            public List<Record> Records { get; set; }

            [JsonProperty("total_records")]
            public int TotalRecords { get; set; }
        }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("data")]
            public Data data { get; set; }

            [JsonProperty("options")]
            public List<object> Options { get; set; }

       

    }
}
