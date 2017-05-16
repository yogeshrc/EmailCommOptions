namespace GmailClient
{
    partial class MailboxContainer
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
            this.btnRetrieveMails = new System.Windows.Forms.Button();
            this.lbxInbox = new System.Windows.Forms.ListBox();
            this.btnReply = new System.Windows.Forms.Button();
            this.tbxCompose = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRetrieveMails
            // 
            this.btnRetrieveMails.Location = new System.Drawing.Point(0, 0);
            this.btnRetrieveMails.Name = "btnRetrieveMails";
            this.btnRetrieveMails.Size = new System.Drawing.Size(108, 23);
            this.btnRetrieveMails.TabIndex = 0;
            this.btnRetrieveMails.Text = "Retrieve mails";
            this.btnRetrieveMails.UseVisualStyleBackColor = true;
            this.btnRetrieveMails.Click += new System.EventHandler(this.btnRetrieveMails_Click);
            // 
            // lbxInbox
            // 
            this.lbxInbox.FormattingEnabled = true;
            this.lbxInbox.Location = new System.Drawing.Point(0, 29);
            this.lbxInbox.Name = "lbxInbox";
            this.lbxInbox.Size = new System.Drawing.Size(244, 186);
            this.lbxInbox.TabIndex = 1;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(261, 0);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(161, 23);
            this.btnReply.TabIndex = 2;
            this.btnReply.Text = "Reply to selected mail";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // tbxCompose
            // 
            this.tbxCompose.Location = new System.Drawing.Point(261, 29);
            this.tbxCompose.Multiline = true;
            this.tbxCompose.Name = "tbxCompose";
            this.tbxCompose.Size = new System.Drawing.Size(274, 184);
            this.tbxCompose.TabIndex = 3;
            // 
            // MailboxContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 225);
            this.Controls.Add(this.tbxCompose);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.lbxInbox);
            this.Controls.Add(this.btnRetrieveMails);
            this.Name = "MailboxContainer";
            this.Text = "Simple Gmail client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieveMails;
        private System.Windows.Forms.ListBox lbxInbox;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.TextBox tbxCompose;
    }
}

