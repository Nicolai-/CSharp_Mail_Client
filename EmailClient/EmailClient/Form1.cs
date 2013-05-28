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
using OpenPop;
using System.Diagnostics;
using Setting = EmailClient.Properties.Settings;

namespace EmailClient
{
    public partial class Form1 : Form
    {
        string ActiveWindow;
        DataTable table;
        DBHandler dbHandler;
        ShowMail ShowMailWindow;
        Dictionary<string, string> MailContent;

        public Form1()
        {
            this.Load += Form1_Load;
            InitializeComponent();

        }
        void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Super Mail Klient by Mathias & Nicolai";

        }
        
        private void inbox_btn_Click(object sender, EventArgs e)
        {
            Newmail_groupBox.Visible = false;
            inboxDataGridView.Visible = true;

            ActiveWindow = "inbox";
            /* Load empty table and do UI optimization*/
            table = new DataTable();
            table.Columns.Add("Mail-ID", typeof(int));
            table.Columns.Add("From", typeof(string));
            table.Columns.Add("Subject", typeof(string));
            inboxDataGridView.DataSource = table;
            inboxDataGridView.RowHeadersVisible = false;
            inboxDataGridView.Columns["Mail-ID"].Visible = false;
            inboxDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            /* Get all Subjects and Senders from DB */
            dbHandler = new DBHandler();
            inboxDataGridView.DataSource = dbHandler.GetAllSendersSubjects();
        }

        private void sendReceive_btn_Click(object sender, EventArgs e)
        {
            dbHandler = new DBHandler();

            List<Message> mails = new List<Message>();
            mails = POPClient.GetAllMails(Setting.Default.pop3_server, Setting.Default.pop3_port, Setting.Default.ssl, Setting.Default.username, Setting.Default.password);
            foreach (Message mail in mails)
            {
                dbHandler.InsertMail(mail);
            }
        }

        private void inboxDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                return;
            }
            Debug.WriteLine("Current Row: " + e.RowIndex.ToString());
            Debug.WriteLine("Mail-ID: " + inboxDataGridView.Rows[e.RowIndex].Cells["Mail-ID"].FormattedValue.ToString());
            string mail_id = inboxDataGridView.Rows[e.RowIndex].Cells["Mail-ID"].FormattedValue.ToString();
            
            MailContent = new Dictionary<string,string>();
            dbHandler = new DBHandler();

            MailContent = dbHandler.GetFullMailFromMailID(mail_id);
            ShowMailWindow = new ShowMail(MailContent["recipient"],MailContent["sender"], MailContent["subject"],MailContent["message"]);
            ShowMailWindow.Show();
            
        }

        private void newMail_btn_Click(object sender, EventArgs e)
        {
            Newmail_groupBox.Visible = true;
            inboxDataGridView.Visible = false;
        }

        private void Send_Button_Click(object sender, EventArgs e)
        }

        private void newMail_btn_Click(object sender, EventArgs e)
        {
            Newmail_groupBox.Visible = true;
            inboxDataGridView.Visible = false;
        }

        private void Send_Button_Click(object sender, EventArgs e)
            string mail_id = inboxDataGridView.Rows[e.RowIndex].Cells["Mail-ID"].FormattedValue.ToString();
            
            MailContent = new Dictionary<string,string>();
            dbHandler = new DBHandler();

            MailContent = dbHandler.GetFullMailFromMailID(mail_id);
            ShowMailWindow = new ShowMail(MailContent["recipient"],MailContent["sender"], MailContent["subject"],MailContent["message"]);
            ShowMailWindow.Show();

        {         
           bool flag = SMTPClient.Send(To_Textbox.Text, Subject_Textbox.Text, Message_textbox.Text);
           if (flag == true)
           {
               Status_textBox.Text = "Sucess ! 1 Email send from the nr 1 email client";
               To_Textbox.Text = string.Empty;
               Subject_Textbox.Text = string.Empty;
               Message_textbox.Text = string.Empty;
           }
           else
           {
               Status_textBox.Text = "Error ! you fucked up.. sorry...";
           }

        }

        private void Textbox_MouseClick(object sender, MouseEventArgs e)
        {
            Status_textBox.Text = string.Empty;
        }           
    }
}
