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

        public void AddFilling(Filling testFilling)
        {
            throw new NotImplementedException();
        }

        public void RemoveFilling(Filling testFilling)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
