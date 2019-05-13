using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataAccess.Abstractions
{
    public interface IPersistenceContext
    {
        void Initialize(IServiceCollection services, string connectionString);        
        IProductsRepository GetProductsRepository();
    } 
}
