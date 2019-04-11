using System;
using System.Linq;

namespace Lesson1
{

    public class Seller
    {
        private Stock currentStock;
        private Order currentOrder = null;
         
        public decimal TotalIncome
        {
            get;
            private set;
        }

        private void VerifyCurrentOrderExists()
        {
            if (currentOrder == null)
            {
                throw new InvalidOperationException("Order not started");
            }
        }

        public Seller(Stock stock)
        {
            this.currentStock = stock;
        }
        
        public void StartNewOrder()
        {
            if (currentOrder != null)
            {
                throw new InvalidOperationException("Cannot start a new order while another is still in progress");
            }     
            currentOrder = new Order(currentStock);
        }
        public void AddItemToOrder(Product productToAdd, ulong qty)
        {            
            VerifyCurrentOrderExists();
            currentOrder.AddItem(productToAdd, qty);                          

        }

        public void RemoveEntryFromOrder(int entryIndex)
        {
            VerifyCurrentOrderExists();
            
            try
            {
               currentOrder.RemoveEntryWithIndex(entryIndex);     
            }
            catch(IndexOutOfRangeException ex)
            {
                   throw new InvalidOperationException("This entry does not exist in the order.", ex);

            }              
        }

        public void RemoveItemFromOrder(int productId, ulong qtyToRemove)
        {
            VerifyCurrentOrderExists();
            var currentEntry = currentOrder.OrderEntries.Where(entry => entry.ProductId == productId)
                                                        .SingleOrDefault();
            if (qtyToRemove > currentEntry.Qty)
            {
                throw new ArgumentException("Too many products to remove.", "qtyToRemove");
            }

            currentOrder.UpdateProductQty(productId, currentEntry.Qty - qtyToRemove);
        }

        public void FinalizeOrder()
        {
            VerifyCurrentOrderExists();
            var orderEntries = currentOrder.OrderEntries;
            
            foreach(var orderEntry in orderEntries)
            {
                currentStock.GetFromStock(orderEntry.ProductId, orderEntry.Qty);                
            }

            TotalIncome += currentOrder.TotalValue;
            currentOrder = null;
        }

        public void CancelOrder()
        {
            currentOrder = null;
        }

    }
}