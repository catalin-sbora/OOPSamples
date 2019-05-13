using DataAccess.Abstractions;
using EF.DataAccess.DataModel;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.DataAccess
{
    public class ProductsRepositoryEF : IProductsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductsRepositoryEF(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Product itemToAdd)
        {
            ProductDO dataToAdd = new ProductDO();            

            dbContext.Add<ProductDO>(dataToAdd);
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByPartialName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Product itemToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToUpdate)
        {
            throw new NotImplementedException();
        }

      
    }
}
