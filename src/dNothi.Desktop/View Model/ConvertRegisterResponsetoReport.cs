using dNothi.JsonParser.Entity;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.View_Model
{
    public class ConvertRegisterResponsetoReport
    {
        public static List<RegisterReport> GetRegisterReports(RegisterReportResponse registerReportResponse)
        {


            List<RegisterReport> registerReportLis = new List<RegisterReport>();

            try
            {
                int count = 1;
                foreach (RegisterReportRecordDTO registerReportRecordDTO in registerReportResponse.data.records)
                {
                    RegisterReport registerReport = new RegisterReport();
                    registerReport.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;
                    if (registerReportRecordDTO.DakDaptoriks.dak_received_no != null)
                    {
                        registerReport.acceptNum = ConversionMethod.EnglishNumberToBangla(registerReportRecordDTO.DakDaptoriks.dak_received_no);

                        registerReport.docketingNo = registerReportRecordDTO.DakDaptoriks.docketing_no;
                        registerReport.sub = registerReportRecordDTO.DakDaptoriks.dak_subject;
                    }
                    else
                    {
                        registerReport.acceptNum = ConversionMethod.EnglishNumberToBangla(registerReportRecordDTO.DakDaptoriks.dak_received_no);

                        registerReport.docketingNo = registerReportRecordDTO.DakNagoriks.docketing_no;
                        registerReport.sub = registerReportRecordDTO.DakNagoriks.dak_subject;
                    }


                    registerReport.sharokNo = registerReportRecordDTO.DakDaptoriks.sender_sarok_no;

                    registerReport.applyDate = registerReportRecordDTO.created;
                    registerReport.type = ConversionMethod.GetDakTypeNameBangla(registerReportRecordDTO.dak_type);

                    registerReport.mainPrapok = registerReportRecordDTO.to_officer_name + ", " + registerReportRecordDTO.to_officer_designation_label + "," + registerReportRecordDTO.to_office_unit_name + "," + registerReportRecordDTO.to_office_name;
                    registerReport.applicant = registerReportRecordDTO.from_officer_name + ", " + registerReportRecordDTO.from_officer_designation_label + "," + registerReportRecordDTO.from_office_unit_name + "," + registerReportRecordDTO.from_office_name;

                    registerReport.receivedDate = registerReportRecordDTO.created;
                    DakPriorityList dakPriorityList = new DakPriorityList();
                    DakSecurityList dakSecurityList = new DakSecurityList();




                    registerReport.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(registerReportRecordDTO.dak_priority));
                    //  registerReport.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(registerReportRecordDTO));
                    registerReport.receivedDate = registerReportRecordDTO.created;
                    registerReport.receivedDate = registerReportRecordDTO.created;
                    registerReport.finalState = registerReportRecordDTO.dak_actions;


                    registerReportLis.Add(registerReport);
                }
            }
            catch
            {

            }

            return registerReportLis;

        }

    }
}
