using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.StoreItem
{
    public interface IStoreItem
    {
        public string Name { get; }
        public string Sku { get; }
        public decimal Price { get; }
        public string Variant { get; }

    }
}
