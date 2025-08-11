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
        private List<IStoreItem> _storeItems = new List<IStoreItem>();
        public int ItemCount { get { return _storeItems.Count; } }

        public Basket(int capacity = 5)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public void Add(IStoreItem storeItem)
        {
            _storeItems.Add(storeItem);
        }

        public bool BasketHas(IStoreItem storeItem)
        {
            return _storeItems.Contains(storeItem);
        }

        public bool IsFull()
        {
            return _storeItems.Count >= Capacity;
        }

        public void Remove(IStoreItem storeItem)
        {
            if (_storeItems.Contains(storeItem)) 
            { 
                _storeItems.Remove(storeItem);
            }
        }

        public decimal TotalCost()
        {
            decimal totalPrice = 0;
            foreach(IStoreItem storeItem in _storeItems)
            {
                totalPrice += storeItem.Price;
            }
            return totalPrice;
        }
    }
}
