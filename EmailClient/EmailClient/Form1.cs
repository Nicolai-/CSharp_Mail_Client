﻿using System;
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


        public Form1()
        {
            this.Load += Form1_Load;
            InitializeComponent();

        }
        void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void inbox_btn_Click(object sender, EventArgs e)
        {
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
        }           
    }
}
