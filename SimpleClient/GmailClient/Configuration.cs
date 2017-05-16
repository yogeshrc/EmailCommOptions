using System;
using System.Windows.Forms;

namespace GmailClient
{
    public partial class Configuration : Form
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Configuration()
        {
            InitializeComponent();
            btnCancel.Click += (sender, e) => Close();
            tbxPassword.Text = string.Empty;
            tbxEmailAddress.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmailAddress = tbxEmailAddress.Text;
            Password = tbxPassword.Text;
            Close();
        }
    }
}
