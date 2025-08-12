using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public Inventory(string sku, decimal price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

        public string Sku { get; }
        public decimal Price { get; }
        public string Name { get; }
        public string Variant { get; }
    }
}
