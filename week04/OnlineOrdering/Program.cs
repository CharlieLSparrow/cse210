using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Canyon Rd", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Charlie Sparrow", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Podcast Mic", "MIC-1001", 129.99, 1));
        order1.AddProduct(new Product("Boom Arm", "ARM-2040", 49.95, 2));

        // Order 2 (International)
        Address address2 = new Address("77 Tulipstraat", "Amsterdam", "NH", "Netherlands");
        Customer customer2 = new Customer("Melissa Sparrow", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Guitar Strings", "STR-9000", 9.99, 6));
        order2.AddProduct(new Product("Capo", "CAP-3002", 14.50, 1));
        order2.AddProduct(new Product("Notebook", "NOTE-1100", 6.25, 3));

        DisplayOrder(order1);
        Console.WriteLine("===================================");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order.GetTotalCost():0.00}");
    }
}
