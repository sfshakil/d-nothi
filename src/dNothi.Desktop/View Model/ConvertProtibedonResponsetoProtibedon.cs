using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
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
        public static List<Protibedon> GetProtibedons(ProtibedonResponse protibedonResponse)
        {


            List<Protibedon> protibedonList = new List<Protibedon>();

            try
            {
                int count = 1;
                foreach (ProtibedonResponseRecordDTO protibedonResponseRecordDTO in protibedonResponse.data.records)
                {
                    Protibedon protibedon = new Protibedon();
                    protibedon.sl = ConversionMethod.EnglishNumberToBangla(count.ToString());
                    count++;
                    
                    protibedon.acceptNum = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.dak_received_no);

                   protibedon.docketingNo = ConversionMethod.EnglishNumberToBangla(protibedonResponseRecordDTO.docketing_no.ToString());
                   protibedon.sub = protibedonResponseRecordDTO.dak_subject;
                   

                    protibedon.sharokNo = protibedonResponseRecordDTO.sender_sarok_no;

                    protibedon.applyDate = protibedonResponseRecordDTO.dakcreted;

                    protibedon.mainPrapok = protibedonResponseRecordDTO.receiving_officer_name + ", " + protibedonResponseRecordDTO.receiving_officer_designation_label + "," + protibedonResponseRecordDTO.receiving_office_unit_name;
                    protibedon.applicant = protibedonResponseRecordDTO.sender_name + ", " + protibedonResponseRecordDTO.sender_officer_designation_label + "," + protibedonResponseRecordDTO.sender_office_unit_name + "," + protibedonResponseRecordDTO.sender_office_name;

                    protibedon.pendingTime = protibedonResponseRecordDTO.pending_time;
                  
                   
                    DakPriorityList dakPriorityList = new DakPriorityList();
                    DakSecurityList dakSecurityList = new DakSecurityList();




                    protibedon.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(protibedonResponseRecordDTO.dak_priority));
                    //  registerReport.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(registerReportRecordDTO));
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


                    protibedon.sharokNo = dakListRecords.dak_origin.sender_sarok_no;

                    protibedon.applyDate = dakListRecords.dak_origin.created;

                   // protibedon.mainPrapok = dakListRecords.dak_user.to_officer_name + ", " + dakListRecords.dak_user.to_officer_designation_label + "," + dakListRecords.dak_user.to_office_unit_name+","+dakListRecords.dak_user.to_office_name;
                    protibedon.applicant = dakListRecords.dak_origin.sender_name + ", " + dakListRecords.dak_origin.sender_officer_designation_label + "," + dakListRecords.dak_origin.sender_office_unit_name + "," + dakListRecords.dak_origin.sender_office_name;

                    //protibedon.pendingTime = protibedonResponseRecordDTO.pending_time;


                    DakPriorityList dakPriorityList = new DakPriorityList();
                    DakSecurityList dakSecurityList = new DakSecurityList();




                    protibedon.priority = dakPriorityList.GetDakPriorityName(Convert.ToString(dakListRecords.dak_user.dak_priority));
                    protibedon.security = dakSecurityList.GetDakSecuritiesName(Convert.ToString(dakListRecords.dak_user.dak_security));

                    protibedon.Date = dakListRecords.dak_user.last_movement_date;


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
