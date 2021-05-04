using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class KhoshraPotroWaitinDataRecordMulpotroDTO
    {
        public string potro_description { get; set; }
        public string potro_cover { get; set; }
        public int id { get; set; }
        public object buttons { get; set; }
        public List<String> buttonsDTOList { get; set; }
    }
}
