using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KasaraPatraDashBoardService.Models
{
   public class PrapakerTalika
    {
        public string status { get; set; }
        public Data data { get; set; }
        public class Receiver
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
        public class Onulipi
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

        public class Data
        {
            public List<Drafter> drafter { get; set; }
            public List<Receiver> receiver { get; set; }
            public List<Onulipi> onulipi { get; set; }
            public List<Approver> approver { get; set; }
            public List<Attention> attention { get; set; }
            public List<Sender> sender { get; set; }
        }

        public class Root
        {
           
        }


    }
}
