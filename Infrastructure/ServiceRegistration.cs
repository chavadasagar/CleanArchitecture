using Application.Interface;
using Infrastructure.Repository;
using Infrastructure.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // Add dependency injection 
            services.RegisterService();
            services.AddTransient<DatabaseHelper>();
        }
    }
}
