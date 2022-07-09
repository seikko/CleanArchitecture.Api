using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static  class ServiceRegistration
    {
        public static void AddPersistenceInfrastructer(this IServiceCollection services,IConfiguration _configuration)
        { 
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.AddTransient(typeof(IEntityReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IEntityRepository<>),typeof(BaseRepository<>));
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartDetailRepository, CartDetailRepository>();
        }
    }
}
