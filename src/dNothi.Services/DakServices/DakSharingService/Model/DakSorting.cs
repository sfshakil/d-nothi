using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService.Model
{
    
    public class Recipient
    {
        public List<OnulipiPrapok> onulipi { get; set; }
        public MulPrapok mul_prapok { get; set; }
    }
    public class DakSorting
    {
        public Recipient recipients { get; set; }
        public int dak_inbox_designation_id { get; set; }
        public int id { get; set; }
        public string dak_type { get; set; }
        public byte is_copied_dak { get; set; }
        public string dak_subject { get; set; }
        public string sender { get; set; } 
        public string sending_date { get; set; }
        public string decision { get; set; }
        public int priority { get; set; }
        public int security { get; set; }
    }
}
