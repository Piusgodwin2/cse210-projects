using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTrackingSystem
{
    // Address Class
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }

        public Address(string street, string city, string stateOrProvince, string country)
        {
            Street = street;
            City = city;
            StateOrProvince = stateOrProvince;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country.Trim().ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
        }
    }

    // Customer Class
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    // Product Class
    public class Product
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    // Order Class
    public class Order
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Customer Customer { get; set; }

        public Order(Customer customer)
        {
            Customer = customer;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.GetTotalCost();
            }

            // Shipping cost
            total += Customer.IsInUSA() ? 5 : 35;

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("Packing Label:");
            foreach (var product in Products)
            {
                label.AppendLine($"- {product.Name} (ID: {product.ProductId})");
            }
            return label.ToString();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
            // Address and Customer
            Address address1 = new Address("123 Main St", "Lagos", "Lagos State", "Nigeria");
            Customer customer1 = new Customer("Sapale", address1);

            Address address2 = new Address("456 Maple Ave", "New York", "NY", "USA");
            Customer customer2 = new Customer("Sarah Thompson", address2);

            // Products
            Product p1 = new Product("Bluetooth Speaker", "SPK123", 45.99m, 2);
            Product p2 = new Product("phone cord", "CHR456", 15.50m, 3);
            Product p3 = new Product("Laptop Bag", "BAG789", 60.00m, 1);

            // Orders
            Order order1 = new Order(customer1);
            order1.AddProduct(p1);
            order1.AddProduct(p2);

            Order order2 = new Order(customer2);
            order2.AddProduct(p3);
            order2.AddProduct(p2);

            // Display Order 1
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");
            Console.WriteLine(new string('-', 40));

            // Display Order 2
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}\n");
        }
    }
}
