using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using static dNothi.Services.GuardFile.Model.GuardFileModel;

namespace dNothi.Services.GuardFile.Model
{
   public class GuardFileAttachment
    {
            public string status { get; set; }
            public List<Attachment> data { get; set; }
       

    }
}
