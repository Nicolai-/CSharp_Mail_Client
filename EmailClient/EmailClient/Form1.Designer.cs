namespace EmailClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.newMail_btn = new System.Windows.Forms.Button();
            this.inbox_btn = new System.Windows.Forms.Button();
            this.outbot_btn = new System.Windows.Forms.Button();
            this.sendReceive_btn = new System.Windows.Forms.Button();
            this.inboxDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.inboxDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // newMail_btn
            // 
            resources.ApplyResources(this.newMail_btn, "newMail_btn");
            this.newMail_btn.Name = "newMail_btn";
            this.newMail_btn.UseVisualStyleBackColor = true;
            // 
            // inbox_btn
            // 
            resources.ApplyResources(this.inbox_btn, "inbox_btn");
            this.inbox_btn.Name = "inbox_btn";
            this.inbox_btn.UseVisualStyleBackColor = true;
            this.inbox_btn.Click += new System.EventHandler(this.inbox_btn_Click);
            // 
            // outbot_btn
            // 
            resources.ApplyResources(this.outbot_btn, "outbot_btn");
            this.outbot_btn.Name = "outbot_btn";
            this.outbot_btn.UseVisualStyleBackColor = true;
            // 
            // sendReceive_btn
            // 
            resources.ApplyResources(this.sendReceive_btn, "sendReceive_btn");
            this.sendReceive_btn.Name = "sendReceive_btn";
            this.sendReceive_btn.UseVisualStyleBackColor = true;
            this.sendReceive_btn.Click += new System.EventHandler(this.sendReceive_btn_Click);
            // 
            // inboxDataGridView
            // 
            this.inboxDataGridView.AllowUserToAddRows = false;
            this.inboxDataGridView.AllowUserToDeleteRows = false;
            this.inboxDataGridView.AllowUserToOrderColumns = true;
            this.inboxDataGridView.AllowUserToResizeRows = false;
            this.inboxDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inboxDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.inboxDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inboxDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.inboxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inboxDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.inboxDataGridView, "inboxDataGridView");
            this.inboxDataGridView.MultiSelect = false;
            this.inboxDataGridView.Name = "inboxDataGridView";
            this.inboxDataGridView.ReadOnly = true;
            this.inboxDataGridView.ShowEditingIcon = false;
            this.inboxDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inboxDataGridView_CellContentDoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inboxDataGridView);
            this.Controls.Add(this.sendReceive_btn);
            this.Controls.Add(this.outbot_btn);
            this.Controls.Add(this.inbox_btn);
            this.Controls.Add(this.newMail_btn);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inboxDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newMail_btn;
        private System.Windows.Forms.Button inbox_btn;
        private System.Windows.Forms.Button outbot_btn;
        private System.Windows.Forms.Button sendReceive_btn;
        private System.Windows.Forms.DataGridView inboxDataGridView;
    }
}

