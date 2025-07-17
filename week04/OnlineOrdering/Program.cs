using System;                       // Import System namespace for basic classes like Console
using System.Collections.Generic;   // Import namespace for generic collections like List<T>

// Program written on 2025-07-17

// =======================
// Address Class - stores customer address details
// =======================
public class Address
{
    private string _street;          // Street part of the address (private)
    private string _city;            // City part of the address (private)
    private string _state;           // State part of the address (private)
    private string _postalCode;      // Postal code part of the address (private)

    // Constructor to initialize all address fields
    public Address(string street, string city, string state, string postalCode)
    {
        _street = street;
        _city = city;
        _state = state;
        _postalCode = postalCode;
    }

    // Method to return the full formatted address as a single string
    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_state} {_postalCode}";
    }
}

// =======================
// Customer Class - stores customer name and their address
// =======================
public class Customer
{
    private string _name;            // Customer name (private)
    private Address _address;        // Customer address object (private)

    // Constructor to initialize name and address
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter method to retrieve customer's name
    public string GetName()
    {
        return _name;
    }

    // Getter method to retrieve customer's address object
    public Address GetAddress()
    {
        return _address;
    }
}

// =======================
// Product Class - stores product details and manages stock
// =======================
public class Product
{
    private string _name;            // Product name (private)
    private decimal _price;          // Product price (private)
    private int _stock;              // Product stock quantity (private)

    // Public read-only properties for accessing private fields
    public string Name => _name;
    public decimal Price => _price;
    public int Stock => _stock;

    // Constructor to initialize product data
    public Product(string name, decimal price, int stock)
    {
        _name = name;
        _price = price;
        _stock = stock;
    }

    // Method to reduce stock if enough quantity is available, returns true if successful
    public bool ReduceStock(int quantity)
    {
        if (quantity <= _stock)
        {
            _stock -= quantity;
            return true;
        }
        return false;
    }

    // Method to add stock quantity (restock)
    public void Restock(int quantity)
    {
        _stock += quantity;
    }
}

// =======================
// OrderItem Class - represents a product and its quantity in an order
// =======================
public class OrderItem
{
    private Product _product;        // Product object (private)
    private int _quantity;           // Quantity ordered (private)

    // Public read-only properties
    public Product Product => _product;
    public int Quantity => _quantity;

    // Constructor to initialize product and quantity
    public OrderItem(Product product, int quantity)
    {
        _product = product;
        _quantity = quantity;
    }

    // Calculates total price for this order item (product price * quantity)
    public decimal GetTotalPrice()
    {
        return _product.Price * _quantity;
    }
}

// =======================
// Order Class - stores order details including customer, items, and status
// =======================
public class Order
{
    private List<OrderItem> _items = new List<OrderItem>();  // List of OrderItem objects (private)
    private string _orderId;                                  // Order ID (private)
    private string _status;                                   // Order status (private)
    private Customer _customer;                               // Customer object (private)

    // Public read-only properties
    public string OrderID => _orderId;
    public string Status => _status;

    // Constructor initializing order ID and associated customer; sets default status "Pending"
    public Order(string orderId, Customer customer)
    {
        _orderId = orderId;
        _status = "Pending";
        _customer = customer;
    }

    // Adds an item to the order if there is enough stock; prints status to console
    public void AddItem(Product product, int quantity)
    {
        if (product.ReduceStock(quantity))    // Reduce stock only if available
        {
            _items.Add(new OrderItem(product, quantity));  // Add new OrderItem to the list
            Console.WriteLine($"Added {quantity} of {product.Name} to order.");
        }
        else
        {
            Console.WriteLine($"Insufficient stock for {product.Name}.");
        }
    }

    // Calculates total price for all items in the order
    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.GetTotalPrice();
        }
        return total;
    }

    // Updates the status of the order and prints confirmation
    public void UpdateStatus(string newStatus)
    {
        _status = newStatus;
        Console.WriteLine($"Order {_orderId} status updated to {_status}");
    }

    // Prints order summary including ID, customer, address, status, items, and total cost
    public void ShowOrder()
    {
        Console.WriteLine($"\nOrder ID: {_orderId}");
        Console.WriteLine($"Customer: {_customer.GetName()}");
        Console.WriteLine($"Address: {_customer.GetAddress().GetFullAddress()}");
        Console.WriteLine($"Status: {_status}");
        foreach (var item in _items)
        {
            Console.WriteLine($"{item.Quantity} x {item.Product.Name} @ {item.Product.Price:C} each");
        }
        Console.WriteLine($"Total: {CalculateTotal():C}");
    }

    // Returns a formatted packing label with product names and quantities
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var item in _items)
        {
            label += $"{item.Quantity} x {item.Product.Name}\n";
        }
        return label;
    }

    // Returns a formatted shipping label with customer name and full address
    public string GetShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

// =======================
// Program Entry Point - main method to run the program
// =======================
class Program
{
    static void Main(string[] args)
    {
        // Create some Product objects with name, price, and stock quantity
        Product laptop = new Product("Laptop", 1200.00m, 5);
        Product mouse = new Product("Wireless Mouse", 25.99m, 10);
        Product keyboard = new Product("Mechanical Keyboard", 75.50m, 7);

        // Create Address objects for customers
        Address address1 = new Address("123 Main St", "Springfield", "IL", "62704");
        Address address2 = new Address("456 Oak Ave", "Columbus", "OH", "43085");

        // Create Customer objects with names and their addresses
        Customer customer1 = new Customer("Alice Smith", address1);
        Customer customer2 = new Customer("Bob Johnson", address2);

        // Create Order 1 for customer1 with ID "ORD001"
        Order order1 = new Order("ORD001", customer1);
        order1.AddItem(laptop, 1);    // Add 1 laptop to order1
        order1.AddItem(mouse, 2);     // Add 2 mice to order1
        order1.ShowOrder();           // Display order1 details
        Console.WriteLine(order1.GetPackingLabel());  // Show packing label
        Console.WriteLine(order1.GetShippingLabel()); // Show shipping label
        order1.UpdateStatus("Shipped");                // Update order1 status to "Shipped"

        Console.WriteLine("\n============================\n");

        // Create Order 2 for customer2 with ID "ORD002"
        Order order2 = new Order("ORD002", customer2);
        order2.AddItem(keyboard, 2);  // Add 2 keyboards to order2
        order2.AddItem(mouse, 1);     // Add 1 mouse to order2
        order2.ShowOrder();           // Display order2 details
        Console.WriteLine(order2.GetPackingLabel());  // Show packing label
        Console.WriteLine(order2.GetShippingLabel()); // Show shipping label
        order2.UpdateStatus("Processing");             // Update order2 status to "Processing"
    }
}
