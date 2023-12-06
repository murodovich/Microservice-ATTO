using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transport.Application.Absreactions;
using Transport.Infrastructure.Persistance;

namespace Transport.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ITransportDBContext, TransportDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefoultConnectionstring"));
            });

            return services;
        }
    }
}
