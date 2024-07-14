using System;

//Program 2 of 4 - Online Ordering
//Jeremy Untch

//This is the main program.
class Program {
    static void Main(string[] args) {
        //Order 1
        Address address1 = new Address("534 Happy Dr.", "Los Angeles", "CA", "USA");
        Customer customer1 = new Customer("Jimmy Boy", address1);

        Product product1 = new Product("Computer Key Board", "P24", 24.0, 1);
        Product product2 = new Product("Mouse Pad", "P2", 10.0, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        //Order 2
        Address address2 = new Address("204 Billy St.", "Ontario", "ON", "Canada");
        Customer customer2 = new Customer("Jill Jones", address2);

        Product product3 = new Product("Foot Massager", "P3", 50, 1);
        Product product4 = new Product("Bananas", "P1", 2.0, 15);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        //This is where the program will read off all of the information that has been collected.
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalCost());

        Console.WriteLine("\nOrder 2 Details:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.CalculateTotalCost());
    }
}