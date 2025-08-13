using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.StoreItem;

namespace exercise.main
{
    public class Receipt : IReceipt
    {
        private BasketCheckout _checkout;
        private DateTime dateTime;
        private Dictionary<string, int> _itemOccurences;
        private Dictionary<string, decimal> _itemsPrices;
        private string receiptString = "";


        public Receipt(BasketCheckout c)
        {
            _checkout = c;
            _itemOccurences = new Dictionary<string, int>();
            _itemsPrices = new Dictionary<string, decimal>();
            updateAttributes();
        }

        private void updateAttributes()
        {
            List<IStoreItem> items = _checkout.basket.storeItems;
            foreach (IStoreItem item in items)
            {
                string s = item.Sku;
                if (_itemOccurences.ContainsKey(s))
                {
                    _itemOccurences[s]++;
                    _itemsPrices[s] += item.Price;
                }
                else
                {
                    _itemOccurences[s] = 1;
                    _itemsPrices[s] = item.Price;
                }
            }
            }
        public string buildReceipt()
        {
            int totalLength = 30;
            List<String> alreadyAdded = new List<String>();
            List<IStoreItem> items = _checkout.basket.storeItems;
            dateTime = DateTime.Now;
            StringBuilder receipt = new StringBuilder();
            string name = _checkout.Store.Name;
            receipt.AppendLine("     ---- "+name+" ----       ");
            receipt.AppendLine();
            int dateTimePadding = (int)Math.Ceiling((double)(36 - dateTime.ToString().Length) / 2);
            receipt.Append(' ', dateTimePadding);
            receipt.Append(dateTime);
            receipt.Append(' ', dateTimePadding);
            receipt.AppendLine();
            receipt.Append('-', 40);
            receipt.AppendLine();
            foreach (IStoreItem item in items) {
                if (!alreadyAdded.Contains(item.Sku)) {
                    string itemName = _checkout.Store.InventoryDict[item.Sku].Name+" "+item.Variant;
                    int itemOcc = _itemOccurences[item.Sku];
                    decimal itemPrice = Math.Round(_itemsPrices[item.Sku], 2);
                    int namePadding = 20 - itemName.Length;
                    int digitCount = itemOcc.ToString().Length;
                    int decimalCount = itemPrice.ToString().Length;
                    int pricePadding = 10 - (digitCount - decimalCount);
                    receipt.Append(itemName);
                    receipt.Append(' ', namePadding);
                    receipt.Append(itemOcc.ToString());
                    receipt.Append(' ', pricePadding);
                    receipt.Append(itemPrice.ToString());
                    receipt.AppendLine();
                    alreadyAdded.Add(item.Sku);
                }
            }

            receipt.Append('-', 40);
            receipt.AppendLine();
            receipt.Append(' ', 38 - (_checkout.originalCost.ToString().Length));
            receipt.Append(_checkout.originalCost.ToString());
            receipt.AppendLine();
            receipt.Append("Discount:");
            receipt.Append(' ', 26 - (_checkout.discountTotal.ToString().Length));
            receipt.Append(" - "+_checkout.discountTotal.ToString());
            receipt.AppendLine();
            receipt.AppendLine();
            receipt.Append("Total");
            receipt.Append(' ', 33-(_checkout.discountCost.ToString().Length));
            receipt.Append(_checkout.discountCost.ToString());
            receipt.AppendLine();
            receipt.Append('-', 40);
            receipt.AppendLine();

            string thanks = "Thank you for your order!";
            receipt.AppendLine("      "+thanks);

            return receipt.ToString();
        }

        public void setReceipt()
        {
            receiptString = string.Empty;
        }

        public void printReceipt()
        {
            Console.Write(buildReceipt());
        }
    }
}
