using System;

namespace DataAccess.Abstractions
{
    public interface IProductsRepository
    {
        object GetById(int id);
        IEnumerable<object> GetByPartialName(string name);
        IEnumerable<object> GetAll();
        void Add(object itemToAdd);
        void Update(object itemToUpdate);
    } 
}
