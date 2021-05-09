using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakItemAction : BaseEntity
    {


        public bool isForwarded { get; set; }
        public bool isForwardReverted { get; set; }
      
        public bool isDakTagged { get; set; }
       
        public bool isNothijato { get; set; }
        public bool isNothijatoReverted { get; set; }
   
        public bool isArchived { get; set; }
        public bool isArchiveReverted { get; set; }
    
        public bool isNothivukto { get; set; }
        public bool isNothivuktoReverted { get; set; }

        public long localNoteId { get; set; }


       
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
       
        public int designation_id { get; set; }
        public int office_id { get; set; }
        public string dak_folder_name { get; set; }
        

        [MaxLength]
        public string dak_Action_Json { get; set; }
        [MaxLength]
        public string dak_Folder_Id_Json { get; set; }

        public void MakeAllfalse()
        {
            isForwarded = false;
             isDakTagged = false;

            isNothijato = false;
             isArchived = false;
             isNothivukto = false;
    }

    }
}
