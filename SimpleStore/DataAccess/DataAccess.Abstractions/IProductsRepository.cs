using System;
using System.Collections.Generic;
using Store.Domain;
namespace DataAccess.Abstractions
{
    public interface IProductsRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetByPartialName(string name);
        IEnumerable<Product> GetAll();
        void Add(Product itemToAdd);
        void Update(Product itemToUpdate);
    } 
}
