using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class KhoshraTemplateHtmlStringChange
    {
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
