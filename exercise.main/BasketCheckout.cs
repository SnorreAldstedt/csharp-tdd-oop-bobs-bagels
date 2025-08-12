using exercise.main.StoreItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BasketCheckout
    {
        private Basket _basket;
        private decimal _originalCost;
        private decimal _discountCost;
        public decimal discountTotal{ get { return _originalCost - _discountCost; } }
        public Store Store { get; set; }

        public BasketCheckout(Basket basket, Store store)
        {
            _basket = basket;
            _originalCost = _basket.TotalCost();
            Store = store;
        }

        private bool hasTwelveOfSameBagel(string sku)
        {
            bool isBagel = Store.InventoryDict[sku].Name == "Bagel";
            int occurences = _basket.CountOccurences(sku);
            return (isBagel && occurences >= 12);
        }
        private bool hasSixOfSameBagel(string sku)
        {
            bool isBagel = Store.InventoryDict[sku].Name == "Bagel";
            int occurences = _basket.CountOccurences(sku);
            return (isBagel && occurences >= 6);
        }

        private bool hasCoffeeAndBagel()
        {
            bool hasBagel = _basket.storeItems.Any(i => Store.InventoryDict.ContainsKey(i.Sku) && Store.InventoryDict[i.Sku].Name == "Bagel");
            bool hasCoffee = _basket.storeItems.Any(i => Store.InventoryDict.ContainsKey(i.Sku) && Store.InventoryDict[i.Sku].Name == "Coffee");

            return (hasBagel && hasCoffee);
        }



        
        public List<IStoreItem> coffeeSorted()
        {
            List<IStoreItem> onlyCoffee = _basket.storeItems.FindAll(i => Store.InventoryDict[i.Sku].Name == "Coffee");
            List<IStoreItem> coffeeSorted = onlyCoffee.OrderByDescending(i => i.Price).ToList();
            return coffeeSorted;
        }
        public List<IStoreItem> bagelSorted()
        {
            List<IStoreItem> onlyBagel = _basket.storeItems.FindAll(i => Store.InventoryDict[i.Sku].Name == "Bagel");
            List<IStoreItem> bagelSorted = onlyBagel.OrderByDescending(i => i.Price).ToList();
            return bagelSorted;
        }

        
        public decimal calculateDiscountCAndB()
        {
            decimal discount = 0;
            if (hasCoffeeAndBagel())
            {
                decimal maxCoffeePrice = coffeeSorted().First().Price;
                decimal maxBagelPrice = bagelSorted().First().Price;
                discount = (maxCoffeePrice + maxBagelPrice) - 1.25m ;
            }
            return discount;
        }

        public decimal calculateDiscountBagels()
        {
            decimal discount = 0;
            List<IStoreItem> bagelSort = bagelSorted();
            foreach(IStoreItem bagel in bagelSort)
            {
                if (hasTwelveOfSameBagel(bagel.Sku))
                {
                    if(discount < (bagel.Price*12) - 3.99m)
                    {
                        discount = (bagel.Price * 12) - 3.99m;
                    }
                }
                else if (hasSixOfSameBagel(bagel.Sku))
                {
                    if (discount < (bagel.Price * 6) - 2.49m)
                    {
                        discount = (bagel.Price * 6) - 2.49m;
                    }
                }
            }
            return discount;
        }

        public void applyDiscount()
        {
            decimal maxDiscount = 0;
            if (hasCoffeeAndBagel())
            {
                decimal currentDiscount = calculateDiscountCAndB();
                if (currentDiscount > maxDiscount)
                {
                    maxDiscount = currentDiscount;
                }
            }
            decimal bagelDiscount = calculateDiscountBagels();
            if(bagelDiscount > maxDiscount)
            {
                maxDiscount = bagelDiscount;
            }
            _discountCost = _originalCost - maxDiscount;
        }
    }
}
