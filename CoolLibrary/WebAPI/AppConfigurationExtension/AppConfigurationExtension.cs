using CoolLibrary.BLL.MappingProfiles;
using CoolLibrary.BLL.Service;
using System.Text.Json.Serialization;

namespace CoolLibrary.WebAPI.AppConfigurationExtension
{
    public static class AppConfigurationExtension
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMapper();

            services.AddScoped<BookService>();
        }
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookProfile).Assembly, typeof(ReviewProfile).Assembly);
            return services;
        }


    }
}
