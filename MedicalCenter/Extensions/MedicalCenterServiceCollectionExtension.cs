using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MedicalCenterServiceCollectionExtension
    {
        /// <summary>
        /// Service collection exension
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>services</returns>
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository,Repository>();
            services.AddScoped<IGlobalService, GlobalService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ILaborantService, LaborantService>();
            services.AddScoped<ILaboratoryPatient, LaboratoryPatientService>();

            return services;
        }
    }
}
