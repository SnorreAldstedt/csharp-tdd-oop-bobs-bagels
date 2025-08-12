using exercise.main.StoreItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<IStoreItem> storeItems = new List<IStoreItem>();
        public int ItemCount { get { return storeItems.Count; } }

        public Basket(int capacity = 20)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public void Add(IStoreItem storeItem)
        {
            storeItems.Add(storeItem);
        }

        public bool BasketHas(IStoreItem storeItem)
        {
            return storeItems.Contains(storeItem);
        }

        public bool IsFull()
        {
            return storeItems.Count >= Capacity;
        }

        public void Remove(IStoreItem storeItem)
        {
            if (storeItems.Contains(storeItem)) 
            { 
                storeItems.Remove(storeItem);
            }
        }

        public int CountOccurences(string sku)
        {
            int count = 0;
            foreach(IStoreItem item in storeItems)
            {
                if (item.Sku == sku) count++;
            }
            return count;
        }

        public decimal TotalCost()
        {
            decimal totalPrice = 0;
            foreach(IStoreItem storeItem in storeItems)
            {
                totalPrice += storeItem.Price;
            }
            return totalPrice;
        }

        public void ClearBasket()
        {
            storeItems.Clear();
        }
    }
}
