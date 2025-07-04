using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryEcommerceSystem
{
    public class Cart
    {
        private Dictionary<Product, int> items = new Dictionary<Product, int>();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                Console.WriteLine("Not enough quantity (:");
                return;
            }
            items[product] = quantity;
        }

        public Dictionary<Product, int> GetItems()
        {
            return items;
        }

        public bool IsEmpty() => items.Count == 0;

    }
}
