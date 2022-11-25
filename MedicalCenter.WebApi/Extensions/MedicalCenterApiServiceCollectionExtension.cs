using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data;
using MedicalCenter.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.WebApi.Extensions
{
    public static class MedicalCenterApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
            return services;
        }

        public static IServiceCollection AddMedicalCenterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MedicalCenterDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
