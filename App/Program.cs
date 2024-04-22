using App.Entities;
using App.Entities.Enum;
using System;
using System.Globalization;

namespace App // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client Data");
            Console.Write("Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            Client client = new(name, email, date);

            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()!);

            Order order = new(DateTime.Now, status, client);


            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product name: ");
                string productName = Console.ReadLine()!;
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine()!);

                Product product = new(productName, productPrice);
                OrderItem item = new(quantity, productPrice, product);
                order.AddItem(item);
                Console.WriteLine();
            }

            Console.WriteLine("Order Sumary:");
            Console.WriteLine(order);

        }
    }
}