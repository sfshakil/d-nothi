﻿using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class NothiRegisterBook : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int unitId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public bool nrb { get; set; }
        public bool dnc { get; set; }
        public bool dnd { get; set; }
        public bool isNothiPreron { get; set; }
        public bool isNothiGrahon { get; set; }
        public bool isNothiReigister { get; set; }
        public bool isPotrajaribohi { get; set; }
        public bool isNothiMasterFile { get; set; }

        [MaxLength]
        public string daklist_json { get; set; }

     

    }
}
