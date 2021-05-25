using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dNothi.Utility
{
    public class KhoshraTemplateHtmlStringChange
    {

       
        public static string bnDateApproverPotroOriginal = "<input id=\"approver_potro_date_bn\" style=\"border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;\" autocomplete=\"off\" type=\"text\" value=\"৫ জ্যৈষ্ঠ ১৪২৭\" />";
        public static string bnDateApproverPotroSet(DateTime dateTime)
        {

            BengaliCalendar bCal = new BengaliCalendar();

            DateTime testDate = new DateTime(dateTime.Year, 4, 14);
            if (bCal.GetDayOfMonth(testDate) != 1)
            {
                dateTime = dateTime.AddDays(-1);
            }


            string Month = ConversionMethod.GetBengaliMonthFromEnglishMonthNo(bCal.GetMonth(dateTime));
            string Day = ConversionMethod.EnglishNumberToBangla(bCal.GetDayOfMonth(dateTime).ToString());
            string Year = ConversionMethod.EnglishNumberToBangla(bCal.GetYear(dateTime).ToString());

            return bnDateApproverPotroOriginal + "<span id=\"approver_bn_date_text\" style=\"position: absolute; top: 0;left: 0; right: 0;\">" + Day + " " + Month + " " + Year + "</span>";
        }


        public static string enDateApproverPotroOriginal = "<input id=\"approver_potro_date_en\" style=\"border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;\" autocomplete=\"off\" type=\"text\" value=\"১৯ মে ২০২০\" />";
        public static string enDateApproverPotroSet(DateTime dateTime)
        {
            BengaliCalendar bCal = new BengaliCalendar();
            string Month = ConversionMethod.GetEngMonthNameinBengali(dateTime.Month);
            string Day = ConversionMethod.EnglishNumberToBangla(dateTime.Day.ToString());
            string Year = ConversionMethod.EnglishNumberToBangla(dateTime.Year.ToString());

            return enDateApproverPotroOriginal + "<span id=\"approver_en_date_text\" style=\"position: absolute; top: 0;left: 0; right: 0;\">" + Day + " " + Month + " " + Year + "</span>";
        }




        public static string bnDatePotroOriginal = "<input id=\"potro_date_bn\" style=\"border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;\" autocomplete=\"off\" type=\"text\" value=\"৫ জ্যৈষ্ঠ ১৪২৭\" />";
        public static string bnDatePotroSet(DateTime dateTime)
        {
            BengaliCalendar bCal = new BengaliCalendar();

            DateTime testDate = new DateTime (dateTime.Year,4,14);
          


            if(bCal.GetDayOfMonth(testDate)!=1)
            {
               dateTime = dateTime.AddDays(-1);
            }

            string Month = ConversionMethod.GetBengaliMonthFromEnglishMonthNo(bCal.GetMonth(dateTime));
            string Day = ConversionMethod.EnglishNumberToBangla(bCal.GetDayOfMonth(dateTime).ToString());
            string Year = ConversionMethod.EnglishNumberToBangla(bCal.GetYear(dateTime).ToString());

            return bnDatePotroOriginal + "<span id=\"bn_date_text\" style=\"position: absolute; top: 0;left: 0; right: 0;\">"+Day+" "+Month+" "+Year+"</span>";
        }

        public static string BanglaDateFromEngDate(DateTime dateTime)
        {
            BengaliCalendar bCal = new BengaliCalendar();

            DateTime testDate = new DateTime(dateTime.Year, 4, 14);



            if (bCal.GetDayOfMonth(testDate) != 1)
            {
                dateTime = dateTime.AddDays(-1);
            }

            string Month = ConversionMethod.GetBengaliMonthFromEnglishMonthNo(bCal.GetMonth(dateTime));
            string Day = ConversionMethod.EnglishNumberToBangla(bCal.GetDayOfMonth(dateTime).ToString());
            string Year = ConversionMethod.EnglishNumberToBangla(bCal.GetYear(dateTime).ToString());

            return Day + " " + Month + " " + Year;

        }


        public static string enDatePotroOriginal = "<input id=\"potro_date_en\" style=\"border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;\" autocomplete=\"off\" type=\"text\" value=\"১৯ মে ২০২০\" />";
        public static string enDatePotroSet(DateTime dateTime)
        {
            BengaliCalendar bCal = new BengaliCalendar();
            string Month = ConversionMethod.GetEngMonthNameinBengali(dateTime.Month);
            string Day = ConversionMethod.EnglishNumberToBangla(dateTime.Day.ToString());
            string Year = ConversionMethod.EnglishNumberToBangla(dateTime.Year.ToString());
           
            return enDatePotroOriginal + "<span id=\"en_date_text\" style=\"position: absolute; top: 0;left: 0; right: 0;\">" + Day + " " + Month + " " + Year + "</span>";
        }




        public static string dateSharokTitleOriginal = "<p class=\"dateSarokTitle write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"true\">----</p>";
        public static string dateSharokTitleReplace = "<p class=\"dateSarokTitle write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"true\"></p>";

        public static string subjectOriginal = "<td class=\"khoshra_subject\" style=\"font-family: 'nikosh' !important;\" contenteditable=\"true\" valign=\"middle\">...................</td>";
        public static string subjectNew(string sub)
        {

          return   "<td class=\"khoshra_subject\" style=\"font-family: 'nikosh' !important;\" contenteditable=\"true\" valign=\"middle\">"+sub+"</td>";

        }


        public static string OnulipiNumAndDateHive = "<table id=\"sarokBottomWrapper\" style=\"width: 100%; opacity: 0;\" cellspacing=\"0\" cellpadding=\"0\">";
        public static string OnulipiNumAndDateShow = "<table id=\"sarokBottomWrapper\" style=\"width: 100%; opacity: 1;\" cellspacing=\"0\" cellpadding=\"0\">";

        public static string OnulipiDivHive = "<table id=\"khoshraOnulipiList\" style=\"width: 100%; opacity: 0;\" cellspacing=\"0\" cellpadding=\"0\">";
        public static string OnulipiDivShow = "<table id=\"khoshraOnulipiList\" style=\"width: 100%; opacity: 1;\" cellspacing=\"0\" cellpadding=\"0\">";

        public static string OnulipiListOriginal = "<li><span class=\"remove_item\">(১) </span></li>";

        public static string AddOnulipiOfficerintheList(List<string> receivers)
        {
            string receiverString ="";

            int i = 0;
            foreach (string r in receivers)
            {
                i = i + 1;


                receiverString += "<li contenteditable=\"true\"><span class=\"serialnumber\" contenteditable=\"true\">(" + ConversionMethod.EnglishNumberToBangla(i.ToString()) + ") </span><span contenteditable=\"true\" class=\"item_text\">" + r+"</span> <i class=\"la la-times border-0 bg-transparent p-0 text-danger ml-2\"></i></li>";

            }

           

            return receiverString;
        }




        public static string AttentionOfficerDivHide = "<div id=\"khoshraAttentionList\" class=\"khoshra_attention_list option_placeholder\" style=\"display: none; margin-top: 40px;\">";
        public static string AttentionOfficerDivShow = "<div id=\"khoshraAttentionList\" class=\"khoshra_attention_list option_placeholder\" style=\" margin-top: 40px;\">";

        public static string AttentionOfficerPOriginal = "<p class=\"write_here khoshraAttentionTitle\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"false\">দৃষ্টি আকর্ষণ:</p>";
        public static string AddAttentionOfficerintheList(List<string> receivers)
        {
            string receiverString = "<ul class=\"list-style-bengali listed_items khoshra_attention\" data-viewer=\"attention\" contenteditable=\"true\" style=\"margin: 0; padding-left:0;counter-reset: section; list-style: none; font-family: 'nikosh' !important; \">";

            int i = 0;
            foreach (string r in receivers)
            {
                i = i + 1;


                receiverString += "<li contenteditable=\"true\"><span class=\"serialnumber\" contenteditable=\"true\">(" + ConversionMethod.EnglishNumberToBangla(i.ToString()) + ") </span><span contenteditable=\"true\" class=\"item_text\">" + r+"</span><i class=\"la la-times border-0 bg-transparent p-0 text-danger ml-2\"></i></li><li contenteditable=\"true\">";

            }

            receiverString += "</ul>";

            return receiverString;
        }


        public static string KhoshraReceivingdivHide = "class=\"khoshra_receiver_list option_placeholder\" style=\"display: none;";
        public static string KhoshraReceivingdivShow = "class=\"khoshra_receiver_list option_placeholder\" style=\"";


        public static string KhoshraReceivingTitleHide = "<p class=\"write_here khoshraReceiversTitle\" style=\"margin: 0; font-family: 'nikosh' !important; display: none;\" contenteditable=\"false\">বিতরণ :</p>";
        public static string KhoshraReceivingTitleShow = "<p class=\"write_here khoshraReceiversTitle\" style=\"margin: 0; font-family: 'nikosh' !important; contenteditable=\"false\">বিতরণ :</p>";



        public static string AddReceiverintheList(List<string> receivers)
        {
            string receiverString = "<ul class=\"list-style-bengali listed_items khoshra_receiver\" data-viewer=\"receiver\" contenteditable=\"true\" style=\"margin: 0; padding-left:0;counter-reset: section; list-style: none; font-family: 'nikosh' !important; \">";

            int i = 0;
            foreach(string r in receivers)
            {
                i = i + 1;


                receiverString += "<li contenteditable=\"true\"><span class=\"serialnumber\" contenteditable=\"true\">("+ConversionMethod.EnglishNumberToBangla(i.ToString())+") </span><span contenteditable =\"true\" class=\"item_text\">"+r+"</span><i class=\"la la-times border-0 bg-transparent p-0 text-danger ml-2\"></i></li>";

            }

            receiverString += "</ul>";

            return receiverString; 
        }


        public static string PrerokHide = "<table id=\"senderWrapper\" style=\"width: 100%; opacity: 0;\" cellspacing=\"0\" cellpadding=\"0\">";
        public static string PrerokShow = "<table id=\"senderWrapper\" style=\"width: 100%; opacity: 1;\" cellspacing=\"0\" cellpadding=\"0\">";
        public static string PrerokOfficerOriginal = "<p class=\"khoshra_sender write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"false\">(প্রেরক)</p>";
        public static string PrerokOfficerNew(string officerName)
        {
            return "<p class=\"khoshra_sender write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+officerName+"</p>";

        }



        public static string PrerokDesignationOriginal = "<p class=\"khoshra_sender_designation write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"false\">(প্রেরক পদবী)</p>";
        public static string PrerokDesignationNew(string designationName)
        {
            return "<p class=\"khoshra_sender_designation write_here\" style=\"margin: 0; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+designationName+"</p>";

        }




        public static string onumodonkariOfficerOriginal = "<p class=\"write_here khoshra_approver_text\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">অনুমোদনকারী</p>";
        public static string onumodonkariOfficerNew(string officerName)
        {
            return "<p class=\"write_here khoshra_approver_text\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+ officerName + "</p>";

        }


        public static string onumodonkariDesignationOriginal = "<p class=\"write_here khoshra_approver_designation\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">অনুমোদনকারী পদবী</p>";
        public static string onumodonkariDesignationNew(string designationName)
        {
            return "<p class=\"write_here khoshra_approver_designation\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+designationName+"</p>";

        }


        public static string onumodonkariPhoneOriginal = "<p class=\"write_here khoshra_approver_phone\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">অনুমোদনকারী ফোন</p>";
        public static string onumodonkariPhoneNew(string Phone)
        {
            return "<p class=\"write_here khoshra_approver_phone\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+Phone+"</p>";

        }

        public static string onumodonkariFaxOriginal = "<p class=\"write_here khoshra_approver_fax\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">অনুমোদনকারী ফ্যাক্স</p>";
        public static string onumodonkariFaxNew(string Fax)
        {
            return "<p class=\"write_here khoshra_approver_fax\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+Fax+"</p>";

        }
        public static string onumodonkariEmailOriginal = "<p class=\"write_here khoshra_approver_email\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">অনুমোদনকারী ইমেইল</p>";
        public static string onumodonkariEmailNew(string EmailName)
        {
            return "<p class=\"write_here khoshra_approver_email\" style=\"margin: 0; line-height: initial; font-family: 'nikosh' !important;\" contenteditable=\"false\">"+EmailName+"</p>";

        }






    }
}
