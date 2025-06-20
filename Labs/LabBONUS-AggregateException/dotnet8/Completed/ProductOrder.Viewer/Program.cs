﻿using ProductOrder.Library;

namespace ProductOrder.Viewer;

internal class Program
{
    static async Task Main(string[] args)
    {
        int orderId = 8;

        Console.Clear();
        Console.WriteLine($"Getting Order ID: {orderId}");

        ConsoleExceptionLogger logger = new();
        OrderReader orderReader = new(logger);
        Order order = await orderReader.GetOrderAsync(orderId);
        if (order.Id == orderId)
        {
            OutputOrder(order);
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void OutputOrder(Order order)
    {
        Console.WriteLine("Details for Order");
        Console.WriteLine($"Order ID: {order.Id}");
        Console.WriteLine($"Order Date: {order.DateOrdered:d}");
        Console.WriteLine($"Customer: {order.Customer?.CustomerName}");
        Console.WriteLine("Products: ");
        foreach (var product in order.Products!)
        {
            Console.WriteLine($"  {product.ProductName}: {product.ProductDescription}");
        }
    }
}
