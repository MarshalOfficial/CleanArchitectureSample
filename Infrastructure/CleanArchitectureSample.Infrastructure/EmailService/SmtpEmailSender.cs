using CleanArchitectureSample.Application.Contracts.Email;
using CleanArchitectureSample.Application.Models.Email;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace CleanArchitectureSample.Infrastructure.EmailService
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;

        public SmtpEmailSender(IOptions<EmailConfiguration> emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration.Value;
        }


        public async Task<bool> SendEmail(EmailMessage email)
        {
            using (var client = new SmtpClient())
            {
                var emailMessage = new MailMessage
                {
                    From = new MailAddress(emailConfiguration.FromAddress, emailConfiguration.FromName),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = true
                };

                emailMessage.To.Add(email.To);

                client.Host = emailConfiguration.SmtpServer;
                client.Port = emailConfiguration.SmtpPort;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(emailConfiguration.SmtpUserName, emailConfiguration.SmtpPassword);
                client.EnableSsl = false;

                await client.SendMailAsync(emailMessage);

                return true;
            }
        }
    }
}
//we can use smtp4dev to test locally
//docker run --rm  -it -p 3000:80 -p 2525:25 rnwood/smtp4dev
//it has a web portal on localhost:3000
//or use sendgrid.com (install nuget package SendGrid)