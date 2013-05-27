using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Setting = EmailClient.Properties.Settings;
using System.Diagnostics;
using Message = OpenPop.Mime.Message;

namespace EmailClient
{
    class DBHandler
    {
        public static SQLiteConnection DbConn = new SQLiteConnection("Data source=" + Setting.Default.db_file_name + ";Version=3;");

        public DBHandler()
        {
            // Sql string to create database with a table to store inbox emails.
            string sql = "CREATE TABLE IF NOT EXISTS mailInbox ('mail-id' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                "'sender' NVARCHAR(100) NOT NULL, " +
                "'recipient' NVARCHAR(100) NOT NULL, " +
                "bc NVARCHAR(100), " +
                "cc NVARCHAR(100), " +
                "subject NVARCHAR(500), " +
                "message NVARCHAR(500), " +
                "attachment blob);";
            Debug.WriteLine(sql);
           
            try
            {
                DbConn.Open();
                Debug.WriteLine("Trying to connect to DB");
                SQLiteCommand cmd = new SQLiteCommand(sql, DbConn);
                cmd.ExecuteNonQuery();
    
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception");
                Debug.WriteLine(ex.Message);
            }   
                       
        }

        public void InsertMail(Message mail)
        {
            Debug.WriteLine("Insert mail to DB");
            string sql = "INSERT INTO mailInbox (sender,recipient,bc,cc,subject,message) " +
                "VALUES (@sender,@recipient,@bc,@cc,@subject,@message)";

            string message;
            string sender = mail.Headers.From.ToString();
            string recipient = String.Join(",", mail.Headers.To);
            string bc = String.Join(",", mail.Headers.Bcc);
            string cc = String.Join(",", mail.Headers.Cc);
            string subject =  mail.Headers.Subject;
            if (!mail.MessagePart.IsMultiPart)
            {
                message = mail.MessagePart.GetBodyAsText();
            }
            else
            {
                OpenPop.Mime.MessagePart plainText = mail.FindFirstPlainTextVersion();
                message = plainText.GetBodyAsText();
            }

            /* Debug output */
            //Debug.WriteLine("Sender: " + sender);
            //Debug.WriteLine("Recipient: " + recipient);
            //Debug.WriteLine("Bc: " + bc);
            //Debug.WriteLine("Cc: " + cc);
            //Debug.WriteLine("Subject: " + subject);
            //Debug.WriteLine("Message: " + message);

            SQLiteCommand cmd = new SQLiteCommand(sql, DbConn);
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@sender", sender);
            cmd.Parameters.AddWithValue("@recipient", recipient);
            cmd.Parameters.AddWithValue("@bc", bc);
            cmd.Parameters.AddWithValue("@cc", cc);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@message", message);
            //cmd.Parameters.AddWithValue("@attachment", mail.MessagePart.FileName);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAllSendersSubjects()
        {
            DataTable SenderSubject = new DataTable();
            SenderSubject.Columns.Add("Mail-ID",typeof(int));
            SenderSubject.Columns.Add("From", typeof(string));
            SenderSubject.Columns.Add("Subject", typeof(string));
            string sql = "SELECT [mail-id],sender,subject from mailInbox";
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SenderSubject.Rows.Add();
                SenderSubject.Rows[SenderSubject.Rows.Count - 1]["Mail-ID"] = reader.GetInt32(0);  // Mail-ID
                SenderSubject.Rows[SenderSubject.Rows.Count - 1]["From"] = reader.GetString(1);    // Sender
                SenderSubject.Rows[SenderSubject.Rows.Count - 1]["Subject"] = reader.GetString(2); // Subject
            }
            return SenderSubject;
        }

        public Dictionary<string, string> GetFullMailFromMailID(int mail_id)
        {
            Dictionary<string, string> FullMail = new Dictionary<string, string>();

            string sql = "SELECT sender,recipient,subject,message FROM mailInbox WHERE [mail-id]=@mail-id";
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConn);
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@mail-id", mail_id);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FullMail.Add("sender", reader.GetString(0));
                FullMail.Add("recipient", reader.GetString(1));
                FullMail.Add("subject", reader.GetString(2));
                FullMail.Add("message", reader.GetString(3));
            }
            return FullMail;
        }
    }
}
