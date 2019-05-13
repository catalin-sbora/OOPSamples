using DataAccess.Abstractions;
using Services.Abstractions;
using Store.Domain;
using System;
using System.Collections.Generic;

namespace Services.LocalImpl
{
    public class ProductsService : IProductsService
    {
        private IPersistenceContext dataContext;
        public ProductsService(IPersistenceContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            var prodRepo = dataContext.GetProductsRepository();
            return prodRepo.GetAll();
        }
    }
}
