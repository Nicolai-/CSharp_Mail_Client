using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class ShowMail : Form
    {
        public ShowMail(string to, string from, string subject, string message)
        {
            InitializeComponent();
            ToLblText.Text = to;
            FromLblText.Text = from;
            SubjectLblText.Text = subject;
            ShowMailTextBox.BackColor = Color.White;
            ShowMailTextBox.Text = message;
            /* Set title of window */
            this.Text = subject;
        }
    }
}
