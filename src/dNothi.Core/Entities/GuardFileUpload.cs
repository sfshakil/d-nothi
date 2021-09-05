using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class GuardFileUpload : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public string model { get; set; }
        public string file_size_in_kb { get; set; }
        public string user_file_name { get; set; }
        public string content { get; set; }
        public long GuardFileId { get; set; }

        [MaxLength]
        public string data { get; set; }
    }
}
