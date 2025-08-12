using exercise.main.StoreItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Store

    {
        public Store(string name, int cap)
        {
            Name = name;
            MaxCapacity = cap;
        }

        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public Dictionary<string, Inventory> InventoryDict { get; set;}

        public void AddFillToBagel(Bagel bagel, Filling fill)
        {
            throw new NotImplementedException();
        }

        public void AddInventory(Inventory invItem)
        {
            throw new NotImplementedException();
        }

        public void AddItemToBasket(Bagel bagel, Basket basket)
        {
            throw new NotImplementedException();
        }

        public Bagel CreateBagel(string v)
        {
            throw new NotImplementedException();
        }

        public Basket CreateBasket()
        {
            throw new NotImplementedException();
        }

        public Coffee CreateCoffee(string v)
        {
            throw new NotImplementedException();
        }

        public Filling CreateFilling(string v)
        {
            throw new NotImplementedException();
        }

        public bool StoreHasItem(IStoreItem storeItem)
        {
            throw new NotImplementedException();
        }
    }
}
