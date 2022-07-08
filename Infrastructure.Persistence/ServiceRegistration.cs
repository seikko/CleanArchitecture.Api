using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static  class ServiceRegistration
    {
        public static void AddPersistenceInfrastructere(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(""), ServiceLifetime.Scoped);
        }
    }
}
