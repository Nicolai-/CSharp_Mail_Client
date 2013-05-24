using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = OpenPop.Mime.Message;
using System.Diagnostics;
using Setting = EmailClient.Properties.Settings;

namespace EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DBHandler dbHandler = new DBHandler();

        }
        
        private void inbox_btn_Click(object sender, EventArgs e)
        {
            List<Message> mails = new List<Message>();
            mails = POPClient.GetAllMails(Setting.Default.pop3_server, Setting.Default.pop3_port, Setting.Default.ssl, Setting.Default.username, Setting.Default.password);
            DataTable table = new DataTable();
            table.Columns.Add("From", typeof(string));
            table.Columns.Add("Subject", typeof(string));
            foreach (Message mail in mails)
            {                
                table.Rows.Add();
                table.Rows[table.Rows.Count - 1]["From"] = mail.Headers.From;
                table.Rows[table.Rows.Count - 1]["Subject"] = mail.Headers.Subject;
            }
            inboxDataGridView.DataSource = table;
            
        }


    }
}
