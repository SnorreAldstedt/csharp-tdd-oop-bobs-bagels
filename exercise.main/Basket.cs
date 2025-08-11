using exercise.main.StoreItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int ItemCount;

        public Basket(int v = 5)
        {
            V = v;
        }

        public int V { get; }

        public void Add(Bagel bagel1)
        {
            throw new NotImplementedException();
        }

        public bool BasketHas(Bagel bagel1)
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public void Remove(Bagel bagel2)
        {
            throw new NotImplementedException();
        }

        public decimal TotalCost()
        {
            throw new NotImplementedException();
        }
    }
}
