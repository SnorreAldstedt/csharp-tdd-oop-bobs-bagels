using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.StoreItem
{
    public class Bagel : IStoreItem

    {
        public string Sku { get; set; }
        public string Variant { get; set; }
        public decimal Price { get; set; }

        public List<Filling> Fillings = new List<Filling>();

        public Bagel(string sku, string variant, decimal price) 
        {
            Sku = sku;
            Variant = variant;
            Price = price;
        }

        public void AddFilling(Filling filling)
        {
            Fillings.Add(filling);
        }

        public void RemoveFilling(Filling filling)
        {
            if (Fillings.Contains(filling))
            {
                Fillings.Remove(filling);
            }
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = Price;
            foreach (Filling filling in Fillings) { 
                totalPrice += filling.Price;
            }
            return totalPrice;
        }
    }
}
