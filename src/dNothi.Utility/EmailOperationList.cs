using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class EmailOperation
    {
        public string eng_name { get; set; }
        public string bng_name { get; set; }
    }

    public static class EmailOperationList
    {
      
        public static List<EmailOperation> emailOperations() {

            List<EmailOperation> _emailOperations = new List<EmailOperation>();
                _emailOperations.Add(new EmailOperation { bng_name = "ডাক প্রেরণ", eng_name = "dak_send" });
                _emailOperations.Add(new EmailOperation { bng_name = "নথি অনুমতি", eng_name = "nothi_permission_send" });
                _emailOperations.Add(new EmailOperation { bng_name = "নোটের অনুমতি", eng_name = "note_permission_send" });
                _emailOperations.Add(new EmailOperation { bng_name = "নোট প্রেরণ", eng_name = "note_send" });
                _emailOperations.Add(new EmailOperation { bng_name = "পত্রজারি প্রেরণ", eng_name = "potrojari_send" });
            return _emailOperations;


          }

        public static string GetBanglaOperationNameByEng(string name)
        {
           return emailOperations().FirstOrDefault(a => a.eng_name == name).bng_name;
        }

        public static string GetEnglishOperationNameByNBng(string name)
        {
            return emailOperations().FirstOrDefault(a => a.bng_name == name).eng_name;
        }

    }
}
