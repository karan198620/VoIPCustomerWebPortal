using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Models.Mail;
using VoipProjectEntities.Infrastructure.Mail;

namespace VoipProjectEntities.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
