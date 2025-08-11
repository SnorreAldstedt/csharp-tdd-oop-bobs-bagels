using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.StoreItem
{
    public interface IStoreItem
    {
        string Sku { get; set; }
        decimal Price { get; }
        string Variant { get; set;  }

        //bool Equivalent(IStoreItem item);

        IStoreItem Copy();
    }
}
