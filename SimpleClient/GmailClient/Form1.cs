using System;
using System.Windows.Forms;

namespace GmailClient
{
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using MailKit.Net.Pop3;
    using MimeKit;
    using MailKit.Net.Smtp;

    public partial class MailboxContainer : Form
    {
        private readonly string Pop3Uri = "pop.gmail.com";
        private readonly int Pop3Port = 995;
        private readonly string SmtpUri = "smtp.gmail.com";
        private readonly int SmtpPort = 587;
        private string EmailAddress = string.Empty;
        private string Password = string.Empty;
        private int maxMessageCount = 10;

        public MailboxContainer()
        {
            InitializeComponent();
        }

        private void btnRetrieveMails_Click(object sender, EventArgs e)
        {
            using (var client = new Pop3Client())
            {
                try
                {
                    client.ServerCertificateValidationCallback = CertificateValidationCallback;
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Connect(Pop3Uri, Pop3Port, true);
                    client.Authenticate("recent:" + EmailAddress, Password);
                    int totalMessages = client.Count;
                    if (totalMessages > maxMessageCount) totalMessages = maxMessageCount;
                    for (int i = 0; i < totalMessages; i++)
                        AddMessage(client.GetMessage(i));
                    client.Disconnect(true);

                }
                catch (MailKit.ProtocolException pe)
                {
                    Console.WriteLine(pe.Message);
                }
            }
        }

        private void AddMessage(MimeMessage mimeMessage)
        {
            lbxInbox.Items.Add(mimeMessage);
        }

        private bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //accept all certificates
            return true;
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            var reply = new MimeMessage();
            using (var client = new Pop3Client())
            {
                client.ServerCertificateValidationCallback = CertificateValidationCallback;
                client.Connect(Pop3Uri, Pop3Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("recent:" + EmailAddress, Password);
                var message = client.GetMessage(lbxInbox.SelectedIndex);

                reply.To.Add(message.From[0]);
                reply.Subject = "Re: " + message.Subject;
                reply.Body = new TextPart("plain") { Text = tbxCompose.Text };
                reply.Sender = new MailboxAddress(EmailAddress);
                client.Disconnect(true);
            }

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = CertificateValidationCallback;
                client.Connect(SmtpUri, SmtpPort, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(EmailAddress, Password);
                client.Send(reply);
                client.Disconnect(true);
            }
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            var c = new Configuration()
            {
                EmailAddress = this.EmailAddress,
                Password = this.Password
            };
            if (c.ShowDialog()== DialogResult.OK)
            {
                EmailAddress = c.EmailAddress;
                Password = c.Password;
            }
            c.Dispose();
        }
    }
}
