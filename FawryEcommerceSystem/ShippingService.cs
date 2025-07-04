using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryEcommerceSystem
{
    public static class ShippingService
    {
        // خدمه الشحن 
        public static void Ship(List<IShippable> itemsShip)
        {
            double totalWeight = 0;
            Console.WriteLine("*_* Shipment notice *_*");
            foreach (var item in itemsShip)
            {
                double weight = item.GetWeight();
                totalWeight += weight;
                Console.WriteLine($"{item.GetName()} - {weight * 1000}g");
            }
            Console.WriteLine($"Total package weight: {totalWeight}kg\n");
        }

    }
}
