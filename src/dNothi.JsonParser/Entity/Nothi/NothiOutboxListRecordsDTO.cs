﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiOutboxListRecordsDTO
    {
        public NothiOutboxDTO nothi { get; set; }
        public ToOutboxDTO to { get; set; }
        public DeskOutboxDTO desk { get; set; }
    }
}
