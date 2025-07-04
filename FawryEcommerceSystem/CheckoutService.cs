using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryEcommerceSystem
{ 
    // خدمه الدفع 
    public static class CheckoutService
    {
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            double subtotal = 0;
            double shipping = 0;
            var shippables = new List<IShippable>();

            // التحقق من صلاحية المنتجات في السلة
            foreach (var item in cart.GetItems())
            {
                Product product = item.Key;
                int quantity = item.Value;

                if (product is ExpirableProduct exp && exp.IsExpired())
                {
                    Console.WriteLine($"{product.Name} is expired!");
                    return;
                }

                if (product is IShippable shippable)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        shippables.Add(shippable);
                        shipping += shippable.GetWeight() * 10;
                    }
                }

                subtotal += product.Price * quantity;
            }

            double total = subtotal + shipping;
            // التحقق من رصيد العميل
            if (!customer.DeductBalance(total))
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            if (shippables.Count > 0)
                ShippingService.Ship(shippables);

            Console.WriteLine("*_* Checkout receipt *_*");
            // طباعة الإيصال
            foreach (var item in cart.GetItems())
            {
                Product product = item.Key;
                int quantity = item.Value;
                Console.WriteLine($"{quantity}x {product.Name} - {product.Price * quantity}");
                product.ReduceQuantity(quantity);
            }

            Console.WriteLine("@___________________@");
            Console.WriteLine($"Subtotal: {subtotal}");
            Console.WriteLine($"Shipping: {shipping}");
            Console.WriteLine($"Amount: {total}");
            Console.WriteLine($"Balance after payment: {customer.Balance}");

           
            string invoiceId = "0001";
            // كود الفاتوره 
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // تاريخ الفاتوره

            Console.WriteLine();
            Console.WriteLine($" Invoice ID: {invoiceId}");
            Console.WriteLine($" Date: {date}");

            Console.WriteLine();
            // شكرًا لك على التسوق معنا (:
            Console.WriteLine(" Payment successful Thank you for shopping with us (:");

        }

    }
}
