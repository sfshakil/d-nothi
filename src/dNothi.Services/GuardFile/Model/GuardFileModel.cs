using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile.Model
{
  public class GuardFileModel
    {
        public class Attachment
        {
            public int id { get; set; }
            public int guard_file_id { get; set; }
            public string name_bng { get; set; }
            public string attachment_type { get; set; }
            public string user_file_name { get; set; }
            public string file_name { get; set; }
            public string file_custom_name { get; set; }
            public string file_dir { get; set; }
            public string file_size_in_kb { get; set; }
            public string created { get; set; }
            public string url { get; set; }
            public string download_url { get; set; }
            public string thumb_url { get; set; }

           
            public string file_url { get; set; }

            public string file_thumbnail { get; set; }
            public string thumbnail_url { get; set; }
            public string delete_token { get; set; }
            public string office_id { get; set; }
            public string designation_id { get; set; }


            public string model { get; set; }
            public string path { get; set; }
            public string content_body { get; set; }

            public int attachment_id { get { return id; } }


        }

        public class Record
        {
            public string name_bng { get; set; }
            public string name_eng { get; set; }
            public int id { get; set; }
            public int file_number { get; set; }
            public string office_name { get; set; }
            public string office_unit_name { get; set; }
            public int office_unit_organogram_id { get; set; }
            public int guard_file_category_id { get; set; }
            public string guard_file_category_name_bng { get; set; }
           // public object attachment { get; set; }
            public Attachment attachment { get; set; }
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

       
            public string status { get; set; }
            public Data data { get; set; }
       
    }
}
