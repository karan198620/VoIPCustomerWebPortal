using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu;
using VoipProjectEntities.Persistence.Repositories;

namespace VoipProjectEntities.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IDeviceAgentRepository, DeviceAgentRepository>();
            services.AddScoped<ITrailBalanceCustomerRepository, TrailBalanceCustomerRepository>();
            services.AddScoped<IAgentCustomerRepository, AgentCustomerRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISubscriptionCustomerRepository, SubscriptionCustomerRepository>();
            services.AddScoped<IBalanceCustomerRepository, BalanceCustomerRepository>();
            services.AddScoped<ICallRecordingAgentRepository, CallRecordingAgentRepository>();
            services.AddScoped<ITrailBalanceCustomerRepository, TrailBalanceCustomerRepository>();
            services.AddScoped<IMenuRequestHandler, CreateMenuCommandHandler>();

            return services;
        }
    }
}
