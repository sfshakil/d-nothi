using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class LocalUploadedDak : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }

        [MaxLength]
        public string uploaded_Dak_Json { get; set; }
    }
}
