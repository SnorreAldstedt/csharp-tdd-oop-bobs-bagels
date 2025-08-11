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
        private decimal _bagelPrice { get; set; }
        public decimal Price { get { return GetTotalPrice();} }

        public List<Filling> Fillings = new List<Filling>();

        public Bagel(string sku, string variant, decimal price) 
        {
            Sku = sku;
            Variant = variant;
            _bagelPrice = price;
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
            decimal totalPrice = _bagelPrice;
            foreach (Filling filling in Fillings) { 
                totalPrice += filling.Price;
            }
            return totalPrice;
        }

        // To keep it simple a bagel is equivalent only if it has the equivalent filling in the same order
        // The fillings doesnt have to be the same Filling object, but be equivalent. This means that this function
        // doesn't consider an egg and bacon bagel to be equivalent to a bacon and egg bagel
        public bool Equivalent(Bagel item)
        {

            //HashSet<Filling> fillingSet = new HashSet<Filling>(Fillings);
            bool sameFillings = item.Fillings.Count == Fillings.Count;
            if (sameFillings)
            {
                for (int i = 0; i < Fillings.Count; i++)
                {
                    if (!item.Fillings[i].Equivalent(Fillings[i]))
                    {
                        sameFillings = false;
                    }
                }
            }
            return(
                item.GetType() == this.GetType() &&
                item.Sku == this.Sku &&
                item.Variant == this.Variant &&
                item.Price == this.Price &&
                sameFillings);
        }

        public IStoreItem Copy()
        {
            throw new NotImplementedException();
        }
    }
}
