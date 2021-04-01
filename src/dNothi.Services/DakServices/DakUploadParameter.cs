using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.DakServices
{
   public class DakUploadParameter
    {
        public string sender_info { get; set; }
        public string CSharpObjtoJson(object obj)
        {

            var jsonString = new JavaScriptSerializer().Serialize(obj);
            return jsonString;
        }
        public string receiver_info { get; set; }
        public string content { get; set; }
        public string dak_info { get; set; }
       
        public string others { get; set; }
        public string uploader { get; set; }
        public string path { get; set; }
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public DakInfo dak_Info_Obj { get; set; }
        public  DakUploadParameter()
        {
            path = "Dak";
            content = "Daak";
        }

       public List<DakUploadAttachment> remoteAttachments = new List<DakUploadAttachment>();
        public List<DakUploadAttachment> localAttachments = new List<DakUploadAttachment>();


    }


    public class DakInfo
    {
        public int id { get; set; }
        public string dak_type { get; set; }
      
        public string sarok_no { get; set; }
        public string sending_date { get; set; }
        public string sending_media { get; set; }
        public string dak_subject { get; set; }
        public string dak_description { get; set; }
        public string priority { get; set; }
        public string security { get; set; }



        //New Change
        public Dictionary<string, DakUploadAttachment> attachment { get; set; }
        public string dak_priority { get; set; }
        public string dak_security { get; set; }



        public string national_idendity_no { get; set; }
        public string birth_registration_number { get; set; }
        public string passport { get; set; }
        public string name_bng { get; set; }
        public string name_eng { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string address { get; set; }
        public string parmanent_address { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
     



        public DakInfo(bool IsNagorik)
        {
            //attachment = new List<Lookup<string, DakUploadAttachment>>();
            if (!IsNagorik)
            {
                this.dak_type = "Daptorik";
            }
            else
            {
                this.dak_type = "Nagorik";
            }
        }


        }


    public class DakInfoNagorik
    {
        public int id { get; set; }
        public string dak_type { get; set; }

        public string sarok_no { get; set; }
        public string sending_date { get; set; }
        public string sending_media { get; set; }
        public string dak_subject { get; set; }
        public string dak_description { get; set; }
        public string priority { get; set; }
        public string security { get; set; }



        //New Change
        public Dictionary<string, DakUploadAttachment> attachment { get; set; }
        public string dak_priority { get; set; }
        public string dak_security { get; set; }



        public string national_idendity_no { get; set; }
        public string birth_registration_number { get; set; }
        public string passport { get; set; }
        public string name_bng { get; set; }
        public string name_eng { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string address { get; set; }
        public string parmanent_address { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }




        public DakInfoNagorik()
        {

            this.dak_type = "Nagorik";
        }


    }




    public class DakUploadAttachment
    {
        public int mulpotro { get; set; }
        public DakAttachmentDTO file_infoModel { get; set; }
        public string file_info { get; set; }

       

    }
  
     
  

    public class DakUploadReceiver
    {
        public PrapokDTO mul_prapok { get; set; }

        public Dictionary<string, PrapokDTO> onulipi { get; set; }

        //public string receiverJson{ get; set; }
        //public string receiverJson{ get; set; }

        //public string CSharpObjtoJsonOnulipi(List<PrapokDTO> prapokDTOs)
        //{
        //    string jsonString = "";
        //    int count=0;
        //    foreach (PrapokDTO p in prapokDTOs)
        //    {
        //        if (count != 0)jsonString += ",";

        //        var jsonStringConverted = new JavaScriptSerializer().Serialize(p);

        //        jsonString += "{\"" + p.designation_id + "\":" + jsonStringConverted+"}";
        //        count += 1;
        //    }

        //    jsonString = "\"onulipi\":" + jsonString;
        //    return jsonString;
        //}
        //public string CSharpObjtoJsonmul_prapoki(PrapokDTO prapokDTOs)
        //{
        //    string jsonString = "";

        //        var jsonStringConverted = new JavaScriptSerializer().Serialize(p);

        //        jsonString += "{\"mul_prapok\":" + jsonStringConverted+",";



        //    return jsonString;
        //}
    }
    
    public class FileInfo
    {
        public int id { get; set; }
        public int dak_id { get; set; }
        public int dak_type { get; set; }
        public int is_main { get; set; }
        public string attachment_type { get; set; }
        public string file_size_in_kb { get; set; }
        public string user_file_name { get; set; }
        public string file_name { get; set; }
        public string file_dir { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
        public string delete_token { get; set; }
    
    }

    public class DakUploadRequestSenderInfo
    {


        public string designation { get; set; }
        public string office_unit { get; set; }
        public string office_name { get; set; }
        public string officer_name { get; set; }
        public string incharge_label { get; set; }
        public int employee_record_id { get; set; }


        public int designation_id { get; set; }
        public int unit_id { get; set; }


        public int office_id { get; set; }
        public int officer_id { get; set; }
        public int office_unit_id { get; set; }
     

    }

}
