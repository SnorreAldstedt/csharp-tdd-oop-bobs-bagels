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
            InventoryDict = new Dictionary<string, Inventory>();
        }

        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public Dictionary<string, Inventory> InventoryDict { get; set;}

        public void AddInventory(Inventory invItem)
        {
            InventoryDict[invItem.Sku] = invItem;
        }

        public void AddItemToBasket(Bagel bagel, Basket basket)
        {
            basket.Add(bagel);
        }

        public Bagel CreateBagel(string sku)
        {
            Inventory invItem = InventoryDict[sku];
            if (invItem.Name == "Bagel")
            {
                return new Bagel(sku, invItem.Variant, invItem.Price);
            }
            else {
                throw new Exception("Sku doesn't exist or isn't a Bagel");
            }
            
        }

        public Coffee CreateCoffee(string sku)
        {
            Inventory invItem = InventoryDict[sku];
            if (invItem.Name == "Coffee")
            {
                return new Coffee(sku, invItem.Variant, invItem.Price);
            }
            else
            {
                throw new Exception("Sku doesn't exist or isn't a Coffee");
            }

        }


        public Filling CreateFilling(string sku)
        {
            Inventory invItem = InventoryDict[sku];
            if (invItem.Name == "Filling")
            {
                return new Filling(sku, invItem.Variant, invItem.Price);
            }
            else
            {
                throw new Exception("Sku doesn't exist or isn't a Filling");
            }

        }


        public bool StoreHasItem(IStoreItem storeItem)
        {
            //bool hasItem = true;
            string sku = storeItem.Sku;
            if (InventoryDict.ContainsKey(sku))
            {
                Inventory invItem = InventoryDict[sku];
                return (storeItem.Price == invItem.Price && storeItem.Variant == invItem.Variant);
            }
            return false;
        }

        public Basket CreateBasket()
        {
            return new Basket(MaxCapacity);
        }

        public void AddFillToBagel(Bagel bagel, Filling fill)
        {
            bagel.AddFilling(fill);
        }
    }
}
