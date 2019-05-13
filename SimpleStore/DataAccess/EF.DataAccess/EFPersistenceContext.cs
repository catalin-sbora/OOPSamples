using DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EF.DataAccess
{
    public class EFPersistenceContext : IPersistenceContext
    {
        private IServiceCollection localServices;

        public IProductsRepository GetProductsRepository()
        {
            var serviceProvider = localServices.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            return new ProductsRepositoryEF(dbContext);
        }

        public void Initialize(IServiceCollection services, string connectionString)
        {
            localServices = services;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
