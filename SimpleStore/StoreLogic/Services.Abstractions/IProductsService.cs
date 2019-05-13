using Store.Domain;
using System;
using System.Collections.Generic;

namespace Services.Abstractions
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }
}
