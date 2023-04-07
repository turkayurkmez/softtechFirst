using eshop.Application.Services;
using eshop.Infrastucture.Data;
using eshop.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eshop.API.Extensions
{
    public static class IoCExtensions
    {
        public static void AddIoCForThisProject(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            //var connectionString = builder.Configuration.GetConnectionString("db");
            services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
