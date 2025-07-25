using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear direcciones
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

        // Crear clientes
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        // Crear productos
        Product product1 = new Product("Book", "B001", 12.99, 2);
        Product product2 = new Product("Pen", "P002", 1.50, 5);
        Product product3 = new Product("Notebook", "N003", 5.25, 3);

        Product product4 = new Product("Backpack", "B004", 45.00, 1);
        Product product5 = new Product("Water Bottle", "W005", 10.00, 2);

        // Crear órdenes y agregar productos
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Mostrar información de las órdenes
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}\n");
    }
}
