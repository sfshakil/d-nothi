using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class SingleOnucchedRecordDTO
    {
        public SingleOnucchedRecordOnucchedDTO onucched { get; set; }
        public List<object> potrojari { get; set; }
        public List<object> attachment { get; set; }
        public List<SingleOnucchedRecordSignatureDTO> signature { get; set; }
        public List<object> potrojari_onucched { get; set; }
    }
}
