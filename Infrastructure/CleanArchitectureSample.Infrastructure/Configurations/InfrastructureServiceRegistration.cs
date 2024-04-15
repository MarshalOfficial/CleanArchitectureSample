using AutoMapper;
using CleanArchitectureSample.Application.Contracts.Email;
using CleanArchitectureSample.Application.Models.Email;
using CleanArchitectureSample.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure.Configurations
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfiguration>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            return services;
        }
    }
}
