using System;
using System.Net;
using System.Net.Mail;

namespace dNothi.Utility
{
    public class EmailSender : IEmailSender
    {
        //private const string Password = "f8psf2Ku";
        //private const string SmtpAddress = "smartmeter-noreply@sinepulse.net";
        private const string Password = "Xw!=9HLx";

        private const string SmtpAddress = "smartmeter.bpdb@gmail.com";
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromAddress { get; set; }
        public string[] ToList { get; set; }
        public string[] CcList { get; set; }
        public string[] BccList { get; set; }
        public Attachment[] Files { get; set; }
        public bool Sendmail()
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(FromAddress);

            if (this.ToList != null)
            {
                foreach (string toadd in this.ToList)
                {
                    if (toadd.Trim().Length > 0)
                    {
                        mailMessage.To.Add(new MailAddress(toadd));
                    }
                }
            }
            if (this.CcList != null)
            {
                foreach (string cc in this.CcList)
                {
                    if (cc.Trim().Length > 0)
                    {
                        mailMessage.CC.Add(cc);
                    }
                }
            }
            //Set additional options
            mailMessage.Priority = MailPriority.High;
            //Text/HTML
            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = this.Subject;
            mailMessage.Body = this.Body;

            if (this.Files != null)
            {
                foreach (Attachment filename in this.Files)
                {
                    mailMessage.Attachments.Add(filename);
                }
            }
            //SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net", 25);
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            NetworkCredential NetworkCred = new NetworkCredential(SmtpAddress, Password);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = NetworkCred;
            smtpClient.Port = 587;
            //smtpClient.Timeout = 20000;
            //smtpClient.Credentials = new NetworkCredential(SmtpAddress, Password);


            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtpClient.Send(mailMessage);
                mailMessage.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Attachment GetAttachment(string filename)
        {
            Attachment attachment = new Attachment(filename);

            return attachment;
        }
    }
}