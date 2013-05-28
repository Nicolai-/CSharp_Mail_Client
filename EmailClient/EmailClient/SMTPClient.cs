using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Setting = EmailClient.Properties.Settings;


namespace EmailClient
{
    class SMTPClient
    {
        public static bool Send(string to, string subject, string message)
        {
             bool flag = true;
             SmtpClient Client = new SmtpClient(Setting.Default.smtp_server, Setting.Default.smtp_port);
             Client.Credentials = new NetworkCredential(Setting.Default.username, Setting.Default.password);
             MailMessage msg = new MailMessage();
             msg.From = new MailAddress(Setting.Default.username, "C#EmailClient");
             msg.To.Add(new MailAddress(to));
             msg.Subject = subject;
             msg.Body = message;
             Client.EnableSsl = true;
             try
             {
                 Client.Send(msg);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Do you know the difference between an error and a mistake " + ex.Message);
                 flag = false;
             }
             return flag;

        }
    }
}
