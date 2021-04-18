using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class DakItem : BaseEntity
    {
        public bool is_dak_inbox_Search { get; set; }

        public bool is_dak_inbox { get; set; }
        public bool is_dak_outbox { get; set; }
        public bool is_dak_outbox_Search { get; set; }
        public bool is_dak_khosra { get; set; }
        public bool is_dak_khosra_Search { get; set; }
        public bool is_dak_sorted { get; set; }
        public bool is_dak_sorted_Search { get; set; }
        public bool is_dak_Nothijato { get; set; }
        public bool is_dak_Nothijato_Search { get; set; }
        public bool is_dak_Nothivukto { get; set; }
        public bool is_dak_Nothivukto_Search { get; set; }

        public bool is_dak_Archived { get; set; }
        public bool is_dak_Archived_Search { get; set; }
        public bool is_dak_All_Search { get; set; }

        [MaxLength]
        public string jsonResponse { get; set; }

   
        public string searchParameter { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }




        public long dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string dak_category { get; set; }
        public string dak_hash { get; set; }
        public int page { get; set; }
       
       
    }
    public class DakItemDetails : BaseEntity
    {

        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public bool is_KhosraDetails { get; set; }
        [MaxLength]

        public string dak_details_Json { get; set; }
        [MaxLength]

        public string dak_attachment_Json { get; set; }
        [MaxLength]

        public string dak_movement_status_Json { get; set; }

    }
}
