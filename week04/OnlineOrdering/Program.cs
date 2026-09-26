using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Phoenix", "Arizona", "USA");

        Customer customer1 = new Customer("Jhon Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Shoes", "P01", 80.00, 1 ));
        order1.AddProduct(new Product("Shirt", "P02", 30.00, 3 ));
        order1.AddProduct(new Product("Pants", "P03", 45.00, 2 ));


        Address address2 = new Address("Calle 85 # 15-30", "Bogotá", "Cundinamarca", "Colombia");

        Customer customer2 = new Customer("Jean Marco", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Laptop", "P04", 850.00, 1 ));
        order2.AddProduct(new Product("Keyboard", "P05", 55.00, 1 ));
        order2.AddProduct(new Product("Mouse", "P06", 40.00, 1 ));

        Address address3 = new Address("450 S State Street", "Salt Lake City", "Utah", "USA");

        Customer customer3 = new Customer("Mark Jhonson", address3);

        Order order3 = new Order(customer3);

        order3.AddProduct(new Product("Backpack", "P07", 100.00, 1 ));
        order3.AddProduct(new Product("Notebook", "P08", 20.90, 5 ));
        order3.AddProduct(new Product("Colored Pencil Box", "P09", 30.00, 2 ));

        List<Order> orders = new List<Order>();

        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        foreach(Order order in orders)
        {
            Console.WriteLine("PACKING LABEL:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("SHIPPING LABEL:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalPrice():0.00}");

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
        }
    }
}