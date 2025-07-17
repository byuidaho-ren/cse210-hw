using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public bool ReduceStock(int quantity)
    {
        if (quantity <= Stock)
        {
            Stock -= quantity;
            return true;
        }
        return false;
    }

    public void Restock(int quantity)
    {
        Stock += quantity;
    }
}

public class OrderItem
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        return Product.Price * Quantity;
    }
}

public class Order
{
    private List<OrderItem> items = new List<OrderItem>();
    public string OrderID { get; private set; }
    public string Status { get; private set; }

    public Order(string orderId)
    {
        OrderID = orderId;
        Status = "Pending";
    }

    public void AddItem(Product product, int quantity)
    {
        if (product.ReduceStock(quantity))
        {
            items.Add(new OrderItem(product, quantity));
            Console.WriteLine($"Added {quantity} of {product.Name} to order.");
        }
        else
        {
            Console.WriteLine($"Insufficient stock for {product.Name}.");
        }
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.GetTotalPrice();
        }
        return total;
    }

    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Order {OrderID} status updated to {Status}");
    }

    public void ShowOrder()
    {
        Console.WriteLine($"Order ID: {OrderID}");
        Console.WriteLine($"Status: {Status}");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Quantity} x {item.Product.Name} @ {item.Product.Price:C} each");
        }
        Console.WriteLine($"Total: {CalculateTotal():C}");
    }
}

// Entry point of the program
class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product laptop = new Product("Laptop", 1200.00m, 5);
        Product mouse = new Product("Wireless Mouse", 25.99m, 10);

        // Create an order
        Order order = new Order("ORD123");

        // Add products to the order
        order.AddItem(laptop, 1);
        order.AddItem(mouse, 2);

        // Show order details
        order.ShowOrder();

        // Update the order status
        order.UpdateStatus("Shipped");
    }
}
