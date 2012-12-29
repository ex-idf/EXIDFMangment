using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace ExIDFManagment.Mail
{
    public class MailSender
    {
        public SmtpClient SMTPClient { get; set; }

        public MailSender(string mailHost, int mailHostPort, string userName, string password)
        {
            SMTPClient = new SmtpClient
            {
                Host = mailHost,
                Port = mailHostPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(userName, password)
            };
        }

        public bool SendMail(string fromAdd, string  toAdd, string subject, string body, 
                                                        ListDictionary replacements, bool isBodyHtml = true)
        {
            MailDefinition md = new MailDefinition();
            md.From = fromAdd;
            md.IsBodyHtml = isBodyHtml;
            md.Subject = subject;

            using (var message =
                        md.CreateMailMessage(toAdd, replacements, body, new System.Web.UI.Control()))
            {
                this.SMTPClient.Send(message);
            }
            return true;
        }

        public bool SendMail(string fromAdd, string toAdd,
                                                        string subject, MailType mailType, ListDictionary replacements)
        {
            string body = LoadMailContentByMailType(mailType);
            return SendMail(fromAdd, toAdd, subject, body, replacements, true);
        }

        public static string LoadMailContentByMailType(MailType mType)
        {
            switch (mType)
            {
                case MailType.WELCOME_MAIL_CANDIDATE:
                    FileStream fs = new FileStream(@"WelcomeMail.txt", FileMode.Open);
                    byte[] buff = new byte[fs.Length];
                    fs.Read(buff, 0, (int)fs.Length);
                    return ASCIIEncoding.UTF8.GetString(buff);
                    break;
                default:
                    return String.Empty;
            }
        }

        public enum MailType
        {
            WELCOME_MAIL_CANDIDATE,
            WELCOME_MAIL_COMPANY
        }
    }
}
