using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.StoreItem
{
    public class Coffee : IStoreItem

    {
        public string Sku { get; set; }
        public string Variant { get; set; }
        public decimal Price { get; set; }

        public Coffee(string sku, string variant, decimal price)
        {
            Sku = sku;
            Variant = variant;
            Price = price;
        }

        public bool Equivalent(IStoreItem item)
        {
            return (
                item.GetType() == this.GetType() &&
                item.Sku == this.Sku &&
                item.Variant == this.Variant &&
                item.Price == this.Price); 
        }

        public IStoreItem Copy()
        {
            return new Coffee(Sku, Variant, Price);
        }
    }
}
