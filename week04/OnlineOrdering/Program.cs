using System;

class Program
{
    static void Main(string[] args)
    {
    
        Address address1 = new Address("123 Elm St", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Ezra Rivera", address1);
        Customer customer2 = new Customer("Marie Dupont", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "NB100", 4.99, 3));
        order1.AddProduct(new Product("Pen", "PN200", 1.49, 5));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Stapler", "ST300", 12.99, 1));
        order2.AddProduct(new Product("Paper", "PP400", 7.50, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
            Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
            Console.WriteLine("Total Price: $" + order.GetTotalCost());
            Console.WriteLine("--------------------------");
        }
    }
}
