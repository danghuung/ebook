using Microsoft.EntityFrameworkCore;
using MyEBook.Models;
using MyEBook.Repositories;

namespace MyEBook.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EBookDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
