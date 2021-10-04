using dNothi.JsonParser.Entity;
using dNothi.Services.BasicService.Models;
using dNothi.Services.DakServices.DakReports;
using dNothi.Services.NothiReportService.Model;
using dNothi.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.View_Model
{
    public class ConvertNothiReport
    {
        public static int lastCount = 0;
      
        public static List<NothiReport> GetNothiRegisterReports(NothiRegisterReport registerReportResponse)
        {
            int count = 1;

            List<NothiReport> registerReportLis = new List<NothiReport>();

            
                count += lastCount;
                foreach (NothiRegisterReport.Record registerReportRecordDTO in registerReportResponse.data.records)
                {

                    NothiReport registerReport = new NothiReport();
                    registerReport.sln = count;
                    registerReport.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;
                
                registerReport.nothiNo = registerReportRecordDTO.nothi!=null? registerReportRecordDTO.nothi.nothi_no:string.Empty;
                registerReport.subject = registerReportRecordDTO.nothi != null ? registerReportRecordDTO.nothi.subject:string.Empty;
                //nothi nibandan

                registerReport.previousNothiNo = string.Empty;
                registerReport.nothiVuktirDate = registerReportRecordDTO.nothi != null ? (ConversionMethod.numberToConsonet(registerReportRecordDTO.nothi.nothi_class.ToString()) + ", " + registerReportRecordDTO.created):string.Empty;
                //end

                //nothi preron
              
                registerReport.office_shaka = registerReportRecordDTO.from_office_unit_name;
                registerReport.preronDate = registerReportRecordDTO.created;
                registerReport.previousSender = registerReportRecordDTO.from_officer_name + "," + registerReportRecordDTO.from_officer_designation_label;
                registerReport.nextReceiver = registerReportRecordDTO.to_officer_name + "," + registerReportRecordDTO.to_officer_designation_label;

                //end

                //nothi grahon

             
                registerReport.office_shaka = registerReportRecordDTO.to_office_name;
                registerReport.receivedDate = registerReportRecordDTO.created;
                registerReport.previousSender = registerReportRecordDTO.to_officer_name + "," + registerReportRecordDTO.to_office_name;

                //end

                //nothi potrojari
                registerReport.subject = registerReportRecordDTO.potrojari!=null? registerReportRecordDTO.potrojari.potro_subject:string.Empty;
                registerReport.sharokNo = registerReportRecordDTO.potrojari != null ? registerReportRecordDTO.potrojari.sarok_no : string.Empty;
                registerReport.potroType = registerReportRecordDTO.potrojari != null ? (registerReportRecordDTO.potrojari.potro_type == 1 ? "অফিস স্বারক" : (registerReportRecordDTO.potrojari.potro_type == 2 ? "সরকারি পত্র" : "আধা সরকারি পত্র")):string.Empty;
                registerReport.preronDate = registerReportRecordDTO.basic != null ? registerReportRecordDTO.basic.issue_date : string.Empty;
                registerReport.sender = registerReportRecordDTO.potrojari != null ? (getPrerok(registerReportRecordDTO.potrojari.recipient.sender)):string.Empty;
                registerReport.receivers = registerReportRecordDTO.potrojari != null ? (getPrapok( registerReportRecordDTO.potrojari.recipient.receiver)):string.Empty;
                registerReport.onulipis = registerReportRecordDTO.potrojari != null ? (getOnulipi(registerReportRecordDTO.potrojari.recipient.onulipi)):string.Empty ;
               
                //end

               
                  registerReportLis.Add(registerReport);
                }
           

            return registerReportLis;

        }

        private static string getOnulipi(object onulipiObject)
        {

            string onulipidata = string.Empty;
            if (onulipiObject != null)
            {
                List<NothiRegisterReport.Onulipi> onulipi = JsonConvert.DeserializeObject<List<NothiRegisterReport.Onulipi>>(onulipiObject.ToString());

                foreach (var item in onulipi)
                {
                    onulipidata += item.office_unit + "," + item.office;
                }
            }
            return onulipidata;
        }
        private static string getPrapok(object receiverObject)
        {

            string receiverdata = string.Empty;
            if (receiverObject != null)
            {
                List<NothiRegisterReport.Receiver> receiver = JsonConvert.DeserializeObject<List<NothiRegisterReport.Receiver>>(receiverObject.ToString());

                foreach (var item in receiver)
                {
                    receiverdata += item.office_unit + "," + item.office;
                }
            }

            return receiverdata;
        }
        private static string getPrerok(object senderObject)
        {
            string senderdata = string.Empty;
            if (senderObject != null)
            {
                List<NothiRegisterReport.Sender> sender = JsonConvert.DeserializeObject<List<NothiRegisterReport.Sender>>(senderObject.ToString());

                foreach (var item in sender)
                {
                    senderdata += item.office_unit + "," + item.office;
                }
            }

            return senderdata;
        }
    }
}
