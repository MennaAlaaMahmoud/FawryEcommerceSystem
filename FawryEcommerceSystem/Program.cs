namespace FawryEcommerceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // مثال على استخدام النظام
            Customer customer = new Customer("Menna Tullah", 1000);

            // إنشاء بعض المنتجات
                var cheese = new ShippableProduct("Cheese", 100, 5, 0.2);
                var tv = new ShippableProduct("TV", 500, 2, 1.0);
                var scratchCard = new Product("ScratchCard", 50, 10);
                var biscuits = new ExpirableProduct("Biscuits", 150, 3, new DateTime(2025, 7, 6));

            // إضافة المنتجات إلى السلة
                Cart cart = new Cart();
                cart.Add(cheese, 2);
                cart.Add(tv, 1);
                cart.Add(scratchCard, 1);
                cart.Add(biscuits, 1);

                CheckoutService.Checkout(customer, cart);
    }
}
}
