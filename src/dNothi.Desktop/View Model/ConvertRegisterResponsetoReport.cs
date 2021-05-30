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
                    DakSecurityList dakSecurityList = new DakSecurityList(true);
                    try
                    {
                        if (registerReportRecordDTO.DakDaptoriks.dak_received_no != null)
                        {
                            registerReport.acceptNum = ConversionMethod.EnglishNumberToBangla(registerReportRecordDTO.DakDaptoriks.dak_received_no);

                            registerReport.docketingNo = ConversionMethod.EngDigittoBanDigit(registerReportRecordDTO.DakDaptoriks.docketing_no);
                            registerReport.sub = registerReportRecordDTO.DakDaptoriks.dak_subject;
                            registerReport.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(registerReportRecordDTO.DakDaptoriks.dak_security_level));
                            registerReport.previousPrapok = registerReportRecordDTO.DakDaptoriks.sender_name + ", " + registerReportRecordDTO.DakDaptoriks.sender_officer_designation_label + "," + registerReportRecordDTO.DakDaptoriks.sender_office_unit_name + "," + registerReportRecordDTO.DakDaptoriks.sender_office_name;
                            registerReport.sharokNo = ConversionMethod.EngDigittoBanDigit(registerReportRecordDTO.DakDaptoriks.sender_sarok_no);
                            registerReport.applyDate = ConversionMethod.EngDigittoBanDigit(registerReportRecordDTO.daptorikCreated);

                        }
                        else
                        {
                            registerReport.acceptNum = ConversionMethod.EnglishNumberToBangla(registerReportRecordDTO.DakDaptoriks.dak_received_no);

                            registerReport.docketingNo = registerReportRecordDTO.DakNagoriks.docketing_no;
                            registerReport.sub = registerReportRecordDTO.DakNagoriks.dak_subject;
                            registerReport.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(registerReportRecordDTO.DakNagoriks.dak_security_level));
                            registerReport.previousPrapok = registerReportRecordDTO.DakNagoriks.sender_name;
                            

                        }

                    }
                    catch
                    {

                    }
                    try
                    {
                       
                        string applyDate = ConversionMethod.BanglaDigittoEngDigit(registerReportRecordDTO.created);
                        DateTime dateTime2 = Convert.ToDateTime(applyDate);
                        registerReport.receivedDate = ConversionMethod.EngDigittoBanDigit(dateTime2.ToString("dd-MM-yyyy HH:mm:ss"));

                    }
                    catch
                    {

                    }

                   
                    registerReport.type = ConversionMethod.GetDakTypeNameBangla(registerReportRecordDTO.dak_type);

                    if(registerReportRecordDTO.mainPrapok != null && registerReportRecordDTO.mainPrapok.Count>0)
                    {
                        registerReport.mainPrapok = registerReportRecordDTO.mainPrapok[0].from_officer_name + ", " + registerReportRecordDTO.mainPrapok[0].to_officer_designation_label + "," + registerReportRecordDTO.mainPrapok[0].to_office_unit_name + "," + registerReportRecordDTO.mainPrapok[0].to_office_name;

                    }
                    registerReport.applicant = registerReportRecordDTO.from_officer_name + ", " + registerReportRecordDTO.from_officer_designation_label + "," + registerReportRecordDTO.from_office_unit_name + "," + registerReportRecordDTO.from_office_name;

                   
                    DakPriorityList dakPriorityList = new DakPriorityList(true);
                   

                    registerReport.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(registerReportRecordDTO.dak_priority));
                
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
