using System;
using System.Linq;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository repository = new DataRepository();            
            Order newOrder = new Order(repository.ProductsStock);
            try
            {
                var selectedProd = repository.Products
                            .Where(product => product.Id == 1)
                            .Single();

                newOrder.AddItem(selectedProd, 10);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("The item that you are trying to add has an invalid value." + e.Message );    
            }
            
        }
    }
}
