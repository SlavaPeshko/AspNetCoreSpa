using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AspNetCoreSpa.Application.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly GlobalSettings _globalSettings;

        public EmailSender(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient(_globalSettings.EmailSettings.MailServer, _globalSettings.EmailSettings.MailPort)
            {
                UseDefaultCredentials = true,
                EnableSsl = true,
                Credentials = new NetworkCredential(_globalSettings.EmailSettings.Sender, _globalSettings.EmailSettings.Password)
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_globalSettings.EmailSettings.Sender)
            };
            mailMessage.To.Add(email);
            mailMessage.Body = htmlMessage;
            mailMessage.Subject = subject;
            client.Send(mailMessage);

            await Task.CompletedTask;
        }
    }
}
