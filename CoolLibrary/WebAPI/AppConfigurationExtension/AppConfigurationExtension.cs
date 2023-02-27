using CoolLibrary.BLL.MappingProfiles;
using CoolLibrary.BLL.Service;
using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Text.Json.Serialization;

namespace CoolLibrary.WebAPI.AppConfigurationExtension
{
    public static class AppConfigurationExtension
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMapper();
            services.AddScoped<BookService>();

            services.AddCors();

            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<RatingDto>, RatingDtoValidator>();
            services.AddScoped<IValidator<NewReviewDto>, NewReviewDtoValidator>();
            services.AddScoped<IValidator<NewBookDto>, NewBookDtoValidator>();
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(BookProfile).Assembly,
                typeof(ReviewProfile).Assembly,
                typeof(RatingProfile).Assembly);
            return services;
        }
    }
}