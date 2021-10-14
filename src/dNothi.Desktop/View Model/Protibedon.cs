using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.View_Model
{
   public class Protibedon
    {
        public int sln { get; set; }
        public string sl { get; set; }
        public string acceptNum { get; set; }
        public string docketingNo { get; set; }
        public string nothiNo { get; set; }
        public string sharokNo { get; set; }
        public string applyDate { get; set; }
       // public string type { get; set; }
        public string sub { get; set; }
        public string applicant { get; set; }
       // public string previousPrapok { get; set; }
        public string mainPrapok { get; set; }
        //public string receivedDate { get; set; }
        public string security { get; set; }
        public string priority { get; set; }
        public string finalState { get; set; }
        public string pendingTime { get; set; }

        public string Date { get; set; }

        public string NothiJatoDate { get { return Date; } }
        public string NothiteUposthapitoDate { get { return Date; } }
        public string PotrojariDate { get { return Date; } }

    }
}
