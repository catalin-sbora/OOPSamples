using System;

namespace DataAccess.Abstractions
{
    public interface IPersistenceContext
    {
        void Initialize(string connectionString);
        
        IProductsRepository GetProductsRepository();
    } 
}
