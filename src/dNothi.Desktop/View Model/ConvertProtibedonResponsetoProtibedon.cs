using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.DakServices.DakReports;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.View_Model
{
   public class ConvertProtibedonResponsetoProtibedon
    {
        public static int lastCount = 0;
        public static List<Protibedon> GetProtibedons(ProtibedonResponse protibedonResponse)
        {


            List<Protibedon> protibedonList = new List<Protibedon>();

            try
            {
                int count = 1;
                count += lastCount;
                foreach (ProtibedonResponseRecordDTO protibedonResponseRecordDTO in protibedonResponse.data.records)
                {
                    Protibedon protibedon = new Protibedon();
                    protibedon.sln = count;
                    protibedon.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;
                    
                    protibedon.acceptNum = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.dak_received_no);

                    protibedon.docketingNo = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.docketing_no.ToString());
                    protibedon.sub = protibedonResponseRecordDTO.dak_subject;

                    try
                    {
                        String dateString = ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.movecreated);
                        DateTime dateTime = Convert.ToDateTime(dateString);
                        protibedon.Date = ConversionMethod.EngDigittoBanDigit(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));

                    }
                    catch
                    {

                    }

                    try
                    {
                        String dateString = ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.dakcreted);
                        DateTime dateTime2 = Convert.ToDateTime(dateString);
                        protibedon.applyDate = ConversionMethod.EngDigittoBanDigit(dateTime2.ToString("dd-MM-yyyy HH:mm:ss"));
                        //protibedon.applyDate = ConversionMethod.EngDigittoBanDigit(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));

                    }
                    catch
                    {

                    }
                   

                    protibedon.sharokNo =ConversionMethod.EngDigittoBanDigit(protibedonResponseRecordDTO.sender_sarok_no);

                   

                    protibedon.mainPrapok = protibedonResponseRecordDTO.receiving_officer_name + ", " + protibedonResponseRecordDTO.receiving_officer_designation_label + "," + protibedonResponseRecordDTO.receiving_office_unit_name;
                    protibedon.applicant = protibedonResponseRecordDTO.sender_name + ", " + protibedonResponseRecordDTO.sender_officer_designation_label + "," + protibedonResponseRecordDTO.sender_office_unit_name + "," + protibedonResponseRecordDTO.sender_office_name;

                    try
                    {
                        String pendingTime =ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.pending_time);
                        DateTime dateTime = Convert.ToDateTime(pendingTime);
                        protibedon.pendingTime = ConversionMethod.EngDigittoBanDigit(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));

                    }
                    catch
                    {

                    }
                  
                   
                    DakPriorityList dakPriorityList = new DakPriorityList(true);
                    DakSecurityList dakSecurityList = new DakSecurityList(true);




                    protibedon.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(protibedonResponseRecordDTO.dak_priority));
                    protibedon.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(protibedonResponseRecordDTO.dak_security_level));
                    if(protibedon.priority == null || protibedon.priority=="")
                    {
                        protibedon.priority = protibedonResponseRecordDTO.dak_priority;
                    }
                    if (protibedon.security == null || protibedon.security == "")
                    {
                        protibedon.security = protibedonResponseRecordDTO.dak_security_level;
                    }


                    protibedon.finalState = protibedonResponseRecordDTO.last_status_officer_name+","+ protibedonResponseRecordDTO.last_status_officer_designation_label+","+ protibedonResponseRecordDTO.last_status_office_unit_name;


                    protibedonList.Add(protibedon);
                }
            }
            catch
            {

            }

            return protibedonList;

        }

        public static List<Protibedon> GetProtibedons(DakProtibedonResponse dakDetailsResponse)
        {


            List<Protibedon> protibedonList = new List<Protibedon>();

            try
            {
                int count = 1;
                foreach (DakListRecordsDTO dakListRecords in dakDetailsResponse.data.records)
                {
                    Protibedon protibedon = new Protibedon();
                    protibedon.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;

                    protibedon.acceptNum = ConversionMethod.EnglishNumberToBangla(dakListRecords.dak_origin.dak_received_no);

                   // protibedon.docketingNo = ConversionMethod.EnglishNumberToBangla(dakListRecords.dak_user.docketing_no.ToString());
                    protibedon.sub = dakListRecords.dak_user.dak_subject;


                    protibedon.sharokNo = ConversionMethod.EngDigittoBanDigit(dakListRecords.dak_origin.sender_sarok_no);

                    protibedon.applyDate = dakListRecords.dak_origin.receiving_date;

                   // protibedon.mainPrapok = dakListRecords.dak_user.to_officer_name + ", " + dakListRecords.dak_user.to_officer_designation_label + "," + dakListRecords.dak_user.to_office_unit_name+","+dakListRecords.dak_user.to_office_name;
                    protibedon.applicant = dakListRecords.dak_origin.sender_name + ", " + dakListRecords.dak_origin.sender_officer_designation_label + "," + dakListRecords.dak_origin.sender_office_unit_name + "," + dakListRecords.dak_origin.sender_office_name;

                    //protibedon.pendingTime = protibedonResponseRecordDTO.pending_time;


                    DakPriorityList dakPriorityList = new DakPriorityList(true);
                    DakSecurityList dakSecurityList = new DakSecurityList(true);




                    protibedon.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(dakListRecords.dak_user.dak_priority));
                    protibedon.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(dakListRecords.dak_user.dak_security));
                
                    if (protibedon.priority == null || protibedon.priority == "")
                    {
                        protibedon.priority = dakListRecords.dak_user.dak_priority;
                    }
                    if (protibedon.security == null || protibedon.security == "")
                    {
                        protibedon.security = dakListRecords.dak_user.dak_security;
                    }

                    protibedon.Date = dakListRecords.dak_user.last_movement_date;


                    protibedonList.Add(protibedon);
                }
            }
            catch
            {

            }

            return protibedonList;

        }

        public static List<Protibedon> GetProtibedans(DakReportModel protibedonResponse)
        {


            List<Protibedon> protibedonList = new List<Protibedon>();

            try
            {
                int count = 1;
                count += lastCount;
                foreach (DakReportModel.Record protibedonResponseRecordDTO in protibedonResponse.data.records)
                {
                    Protibedon protibedon = new Protibedon();
                    protibedon.sln = count;
                    protibedon.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;

                    protibedon.acceptNum = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.dak_origin.dak_received_no);

                    protibedon.docketingNo = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.dak_origin.docketing_no.ToString());
                    protibedon.sharokNo = ConversionMethod.EngDigittoBanDigit(protibedonResponseRecordDTO.dak_origin.sender_sarok_no);
                    protibedon.nothiNo = protibedonResponseRecordDTO.nothi!=null? protibedonResponseRecordDTO.nothi.nothi_no:string.Empty;
                    //String dateString = ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.dak_user.created);
                    //DateTime dateTime2 = Convert.ToDateTime(dateString);
                    protibedon.applyDate = protibedonResponseRecordDTO.dak_origin.receiving_date;
                    protibedon.sub = protibedonResponseRecordDTO.dak_user.dak_subject;
                    protibedon.applicant = protibedonResponseRecordDTO.dak_origin.sender_name + ", " + protibedonResponseRecordDTO.dak_origin.sender_officer_designation_label + "," + protibedonResponseRecordDTO.dak_origin.sender_office_unit_name + "," + protibedonResponseRecordDTO.dak_origin.sender_office_name;
                    var mulprapok = protibedonResponseRecordDTO.movement_status.to.FirstOrDefault();
                    if (mulprapok != null)
                        protibedon.mainPrapok = mulprapok.officer + ", " + mulprapok.designation + "," + mulprapok.office_unit + "," + mulprapok.office;
                    else
                        protibedon.mainPrapok = string.Empty;
                    //String dateString1 = ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.dak_user.last_movement_date);
                    //DateTime dateTime = Convert.ToDateTime(dateString1);
                    //protibedon.Date = ConversionMethod.EngDigittoBanDigit(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));

                    //applyDate sub applicant mainPrapok PotrojariDate NothiJatoDate NothiteUposthapitoDate security priority finalState pendingTime

                    //PotrojariDate 
                    // NothiJatoDate 
                    protibedon.Date = protibedonResponseRecordDTO.dak_user.last_movement_date;

                    DakPriorityList dakPriorityList = new DakPriorityList(true);
                    DakSecurityList dakSecurityList = new DakSecurityList(true);

                    var priority = dakPriorityList.GetDakPriorityName(Convert.ToString(protibedonResponseRecordDTO.dak_user.dak_priority));
                    var security= dakSecurityList.GetDakSecuritiesName(Convert.ToString(protibedonResponseRecordDTO.dak_user.dak_security));
                    protibedon.priority = priority != "বাছাই করুন" ? priority : string.Empty;
                    protibedon.security = security != "বাছাই করুন" ? security : string.Empty;
                    
                    //if (protibedon.priority == null || protibedon.priority == "")
                    //{
                    //    protibedon.priority = protibedonResponseRecordDTO.dak_user.dak_priority;
                    //}
                    //if (protibedon.security == null || protibedon.security == "")
                    //{
                    //    protibedon.security = protibedonResponseRecordDTO.dak_user.dak_security;
                    //}


                    protibedon.finalState = protibedonResponseRecordDTO.dak_user.to_officer_name + "," + protibedonResponseRecordDTO.dak_user.to_officer_designation_label + "," + protibedonResponseRecordDTO.dak_origin.sender_office_unit_name;

                    //String pendingTime = ConversionMethod.BanglaDigittoEngDigit(protibedonResponseRecordDTO.dak_user.modified);
                    //DateTime dateTime1 = Convert.ToDateTime(pendingTime);
                    //protibedon.pendingTime = ConversionMethod.EngDigittoBanDigit(dateTime1.ToString("dd-MM-yyyy HH:mm:ss"));

                    protibedonList.Add(protibedon);
                }
            }
            catch
            {

            }

            return protibedonList;

        }
    }
}
