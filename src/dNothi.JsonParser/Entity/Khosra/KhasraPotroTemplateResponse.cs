using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Khosra
{
   public class KhasraPotroTemplateResponse
    {
        public string status { get; set; }
        public List<KhasraPotroTemplateDataDTO> data { get; set; }
    }

    public class KhasraPotroTemplateDataDTO
    {
        public int id { get; set; }
        public string template_name { get; set; }
        public string field_list { get; set; }
        public string html_content { get; set; }
        public int status { get; set; }
        public int template_id { get; set; }
        public string version { get; set; }
        public int office_id { get; set; }
        public string office { get; set; }
        public int designation_id { get; set; }
        public string designation { get; set; }
        public string recipient_type { get; set; }
        public string participant_length { get; set; }
        public int created_by { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public int? modified_by { get; set; }
    }
}
