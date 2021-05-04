using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FinalProject.Data
{
    public class EmailHelper
    {
        private MailMessage msg;
        private SmtpClient smtp;

        public EmailHelper(String host, bool enableSSL, bool useDefaultCredentials, int port)
        {
            this.smtp = new SmtpClient();
            this.smtp.Host = host;
            this.smtp.EnableSsl = enableSSL;
            this.smtp.UseDefaultCredentials = useDefaultCredentials;
            this.smtp.Port = port;

            msg = new MailMessage();
        }

        public EmailHelper()
        {
            this.smtp = new SmtpClient();
            this.smtp.Host = "smtp.gmail.com";
            this.smtp.EnableSsl = true;
            this.smtp.UseDefaultCredentials = true;
            this.smtp.Port = 587;

            msg = new MailMessage();
        }

        public void setCredential(String senderEmail, String password)
        {
            NetworkCredential credential = new NetworkCredential(senderEmail, password);
            this.smtp.Credentials = credential;
        }

        public void setCredential()
        {
            string senderEmail = "";
            string password = "";
            NetworkCredential credential = new NetworkCredential(senderEmail, password);
            this.smtp.Credentials = credential;
        }


        public void setMessage(String sender, String receiver, String subject, String body, bool isBodyHTML)
        {
            this.msg = new MailMessage(sender, receiver, subject, body);
            this.msg.IsBodyHtml = isBodyHTML;
        }

        public void sendMessage()
        {
            try
            {
                smtp.Send(this.msg);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


    }
}