
using LangTrainerDAL.Services;
using LangTrainerServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangTrainerDAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPersistence(
            this IServiceCollection services, IConfiguration conf)
        {
            
            var connStr = conf["DbConnection"];

            services.AddSingleton<IAppRepository, AppRepository>();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(connStr);
            });

            return services;
        }

    }
}
