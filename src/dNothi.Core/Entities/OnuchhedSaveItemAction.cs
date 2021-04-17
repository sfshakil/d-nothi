using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class OnuchhedSaveItemAction : BaseEntity
    {
        public  string onuchhedId { get; set; }
        [MaxLength]
        public  string dakUserParamJson { get; set; }
        [MaxLength]
        public  string onuchhedSaveWithAttachmentsJson { get; set; }
        [MaxLength]
        public  string nothiListRecordsDTOJson { get; set; }
        [MaxLength]
        public  string newnotedataJson { get; set; }
        public  string editorEncodedData { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }
    }
}
