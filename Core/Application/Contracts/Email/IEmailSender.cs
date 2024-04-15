using CleanArchitectureSample.Application.Models.Email;

namespace CleanArchitectureSample.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
