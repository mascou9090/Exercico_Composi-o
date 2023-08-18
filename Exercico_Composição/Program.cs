using Exercicio_Composição.Entites;
using Exercicio_Composição.Entites.Enums;
using System;

namespace Exercicio_Composição // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client Data:");
            
            Console.WriteLine();
            Console.Write("Name: ");
            string nameAux = Console.ReadLine();
            Console.Write("Email: ");
            string emailAux = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDateAux = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus statusAux = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int howManyOrderAux = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Client newClient = new Client(nameAux, emailAux, birthDateAux);
            
            Order Order = new Order(DateTime.Now, statusAux, newClient);
            
            Console.WriteLine();

            for (int i = 0; i < howManyOrderAux; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data:");
                Console.WriteLine();
                Console.Write("Product name: ");
                string nameItemAux = Console.ReadLine();
                Console.Write("Product price: ");
                double priceItemAux = double.Parse(Console.ReadLine());
                Console.Write("Quantity? ");
                int quantityAux = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Product itemAux = new Product(nameItemAux, priceItemAux);
                OrderItem orderAux = new OrderItem(quantityAux, priceItemAux, itemAux);

                Order.AddItem(orderAux);
            }


            Console.WriteLine();
            Console.WriteLine(Order);
            Console.Write($"Total price: ${Order.Total()}");

        }
    }
}