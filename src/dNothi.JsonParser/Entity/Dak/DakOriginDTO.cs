using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakOriginDTO
    {
        public int id { get; set; }
        public string name_eng { get; set; }
        public string name_bng { get; set; }
        public string sender_name { get; set; }
        public int receiving_office_id { get; set; }
        public string receiving_office_name { get; set; }
        public int receiving_office_unit_id { get; set; }
        public string receiving_office_unit_name { get; set; }
        public int receiving_officer_id { get; set; }
        public int receiving_officer_designation_id { get; set; }
        public string receiving_officer_designation_label { get; set; }
        public string receiving_officer_name { get; set; }
        public int docketing_no { get; set; }
        public string dak_received_no { get; set; }
        public string receiving_date { get; set; }
        public string sender_sarok_no { get; set; }
        public int sender_officer_id { get; set; }
        public string sender_office_name { get; set; }
        public int sender_office_unit_id { get; set; }
        public string sender_office_unit_name { get; set; }
        public int sender_officer_designation_id { get; set; }
        public string sender_officer_designation_label { get; set; }
    }
}
