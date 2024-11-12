using Blog.Domain;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class EmailUtility : IEmailUtility
    {
        private readonly SmtpSettings _settings;
        public EmailUtility(IOptions<SmtpSettings> smtpSettings) 
        {
              _settings = smtpSettings.Value; 
        }
        public void SendEmail(string receiverEmail, string receiverName, string subject, string body, bool isHtml = false)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
            message.To.Add(new MailboxAddress(receiverName, receiverEmail));
            message.Subject = subject;

            //message.Body = new TextPart("plain")
            //{
            //    Text = body
            //};
            message.Body = new TextPart(isHtml ? "html" : "plain")
            {
                Text = body
            };
            using (var client = new SmtpClient())
            {
                client.Connect(_settings.Host, _settings.Port,
               _settings.EncryptionType != SmtpEncryptionTypes.Normal);
                client.Timeout = 6000;

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(_settings.Username, _settings.Password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
