using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MailboxContainer()
        {
            InitializeComponent();
        }

        private void btnRetrieveMails_Click(object sender, EventArgs e)
        {
            using (var client = new Pop3Client())
            {
                client.ServerCertificateValidationCallback = CertificateValidationCallback;
                client.Connect(Pop3Uri, Pop3Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("recent:yogesh.choudhary.samples@gmail.com", "GeekY0g!");
                int maxMessages = 3; int i = 0;
                foreach (var message in client.GetMessages(0, client.Count))
                {
                    AddMessage(message.Subject);
                    i++;
                    if (i > maxMessages) break;
                }
                //for (int i = 0; i < 3; i++)
                //{
                //    var message = client.GetMessage(i);
                //    AddMessage(message.Subject);
                //}
                client.Disconnect(true);
            }
        }

        private void AddMessage(string subject)
        {
            lbxInbox.Items.Add(subject);
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
                client.Authenticate("recent:yogesh.choudhary.samples@gmail.com", "GeekY0g!");
                var message = client.GetMessage(lbxInbox.SelectedIndex);

                reply.To.Add(message.From[0]);
                reply.Subject = "Re: " + message.Subject;
                reply.Body = new TextPart("plain") { Text = tbxCompose.Text };
                reply.Sender = new MailboxAddress("yogesh.choudhary.sample@gmail.com");
                client.Disconnect(true);
            }

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = CertificateValidationCallback;
                client.Connect(SmtpUri, SmtpPort, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("yogesh.choudhary.samples@gmail.com", "GeekY0g!");
                client.Send(reply);
                client.Disconnect(true);
            }
        }
    }
}
