using System;
using System.Linq;

namespace Lesson1.UI
{
    public class ConsoleMenuController
    {

        private Seller seller;
        private string currentError = "";
        private readonly DataRepository repository;

        private void RenderError()
        {
            if (!string.IsNullOrEmpty(currentError))
            {
                Console.WriteLine($"\n\nError: {currentError}\n\n");
            }
        }
        private void RenderMainMenu()
        {
            Console.Clear();

            Console.WriteLine("**Seller APP**\n\n");
            Console.WriteLine("1. New Order");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. View Existing Stock");
            Console.WriteLine("0. Exit");
            RenderError();
        }

        private void RenderNewOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("**Seller APP**\n\n");
            Console.WriteLine("1. Add New Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Finalize");
            Console.WriteLine("0. Cancel");
            RenderError();
        }

        private byte ReadMainMenu()
        {
            byte option = 0;
            do
            {
                RenderMainMenu();
                Console.Write("Your Option: ");
                
                var keyInfo = Console.ReadKey();            
                option = (byte)(keyInfo.KeyChar - '0');
                if (option > 3)
                {
                    currentError = "Invalid option. Please choose somehting from the list.";
                }
                else
                {
                    currentError = "";
                }

            }while(option > 3);

            return option;
        }

        private byte ReadNewOrderMenu()
        {
            byte option = 0;
            do
            {
                RenderNewOrderMenu();
                Console.Write("Your Option: ");
                
                var keyInfo = Console.ReadKey();            
                option = (byte)(keyInfo.KeyChar - '0');
                if (option > 3)
                {
                    currentError = "Invalid option. Please choose somehting from the list.";
                }
                else
                {
                    currentError = "";
                }

            }while(option > 3);

            return option;
        }

        private void ListProductsInStock()
        {
            Console.WriteLine("PRODUCTS ");
            Stock currentStock = repository.ProductsStock;
            Console.WriteLine("{0,4}|{1,60}|{2,10}", "Id", "Name", "Qty");
            foreach(var stockEntry in currentStock.StockEntries)
            {
                Console.WriteLine("{0,4}|{1,60}|{2,10}", stockEntry.Product.Id, stockEntry.Product.Name, stockEntry.Qty);
            }
        }

        public Product GetProductToAdd()
        {            
            int productId = 0;
            var readId = "";
            do 
            {
                Console.Write("Product Id: ");
                readId = Console.ReadLine();     

            } while (!Int32.TryParse(readId, out productId));   
            
            var currentStock = repository.ProductsStock;
            var stockEntry = currentStock.StockEntries.Where(entry => entry.Product.Id == productId)
                                     .SingleOrDefault();
            Product retVal = null;
            if (stockEntry != null)
            {   
                retVal = stockEntry.Product;
            }

            return retVal;
        }

        public int GetQtyToAdd()
        {
            var readString = "";
            int qty = 0;
            do 
            {
                Console.Write("Qty (valid number): ");
                readString = Console.ReadLine();     

            } while (!Int32.TryParse(readString, out qty));

            return qty;
        }

        private void HandleFinalizeOrder()
        {
            
        }

        private void HandleRemoveProduct()
        {
            
        }

        private void HandleAddNewProduct()
        {
            
            Console.Clear();
            ListProductsInStock();
            var productToAdd = GetProductToAdd();
            var qty = GetQtyToAdd();
            try
            {    
                seller.AddItemToOrder(productToAdd, (ulong)qty);            
                Console.WriteLine($"Product {productToAdd.Name} {qty} pcs added to the order");
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to add product to order. " + e.Message);
            }
            
            Console.ReadLine();
        }

        private void HandleNewOrder()
        {
            bool stayInMenu = true;
            byte option = 0;

            seller.StartNewOrder();
            while(stayInMenu)
            {
                option = ReadNewOrderMenu();
                switch(option)
                {
                    case 0:
                        stayInMenu = false;
                    break;
                    case 1:
                        HandleAddNewProduct();
                    break;
                    
                    case 2:
                        HandleRemoveProduct();    
                    break;

                    case 3:
                        HandleFinalizeOrder();
                    break;
                }
            }

        }

        

        private void HandleViewAllProducts()
        {

        }

        private void HandleViewStock()
        {


        }

        public ConsoleMenuController(DataRepository repository)
        {
            this.repository = repository;
            seller = new Seller(this.repository.ProductsStock);
        }

        public void EnterMainMenu()
        {
            bool continueApplication = true;
            byte option = 0;
            while(continueApplication)
            {
                option = ReadMainMenu();
                switch(option)
                {
                    case 0:
                        continueApplication = false;
                    break;
                    case 1:
                        HandleNewOrder();
                    break;
                    
                    case 2:
                        HandleViewAllProducts();
                    break;

                    case 3:
                        HandleViewStock();
                    break;
                }
            }
        } 
        

    }
}