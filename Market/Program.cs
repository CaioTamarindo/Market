using System;
using Market.Entities;
using Market.Entities.Enums;

namespace Market {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string nameClient = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(nameClient, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(status,client);
            for (int i=1; i <= n; i++) {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product (productName);

                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
            Console.WriteLine(order.Total());

        }
    }
}
