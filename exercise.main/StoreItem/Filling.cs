using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.StoreItem
{
    public class Filling : IStoreItem

    {
        public string Sku { get; set; }
        public string Variant { get; set; }
        public decimal Price { get; set; }

        public Filling(string sku, string variant, decimal price)
        {
            Sku = sku;
            Variant = variant;
            Price = price;
        }
    }
}

