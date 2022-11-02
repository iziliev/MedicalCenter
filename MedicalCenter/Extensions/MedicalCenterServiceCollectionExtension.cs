using MedicalCenter.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MedicalCenterServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository,Repository>();

            return services;
        }
    }
}
