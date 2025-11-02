using Week_3_Inno_PreTrainee.Data.Context;
using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Data.Repositories;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Application.Services;
using FluentValidation;
using Week_3_Inno_PreTrainee.Presentation.Validators.AuthorValidator;
using Week_3_Inno_PreTrainee.Presentation.Validators.BookValidator;

namespace Week_3_Inno_PreTrainee.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection ConfigureExtension(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddDbContext<LibraryContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            return services;
        }

        public static IServiceCollection DataExtension(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryAuthor, RepositoryAuthor>();
            services.AddScoped<IRepositoryBook, RepositoryBook>();
            return services;
        }

        public static IServiceCollection ApplicationExtension(
            this IServiceCollection services
            )
        {
            services.AddScoped<IServiceAuthor, ServiceAuthor>();
            services.AddScoped<IServiceBook, ServiceBook>();
            return services;
        }
        public static IServiceCollection AddValidation(this IServiceCollection services) 
        {
            services.AddValidatorsFromAssemblies(new[]
{
                typeof(AuthorForCreationDtoValidator).Assembly,
                typeof(AuthorForUpdateDtoValidator).Assembly,
                typeof(BookForCreationDtoValidator).Assembly,
                typeof(BookForUpdateDtoValidator).Assembly
            });
            return services;
        }

    }
}
