using CleanArchitectureSample.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CleanArchitectureSample.Infrastructure.EmailService
{
    public class ApiEmailSender
    {
        private readonly EmailConfiguration emailSettings;

        public ApiEmailSender(IOptions<EmailConfiguration> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = emailSettings.FromAddress,
                Name = emailSettings.FromName,
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
