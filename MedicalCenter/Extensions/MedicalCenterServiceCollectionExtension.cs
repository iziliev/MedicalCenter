using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MedicalCenterServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository,Repository>();
            services.AddScoped<IGlobalService, GlobalService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
