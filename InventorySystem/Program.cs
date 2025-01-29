using System;

namespace InventorySystem
{
    internal class Program
    {
        const int NUMOFPRODUCT = 100;
        static int productCount = 0;
        static string[,] inventory = new string[NUMOFPRODUCT, 3];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Inventory System");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            AddProduct();
                            break;

                        case 2:
                            UpdateProduct();
                            break;

                        case 3:
                            ViewProducts();
                            break;

                        case 4:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static void AddProduct()
        {
            if (productCount >= NUMOFPRODUCT)
            {
                Console.WriteLine("Inventory is full. Cannot add more products.");
                return;
            }

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine()?.Trim();

            Console.Write("Enter Product Quantity: ");
            string productQuantity = Console.ReadLine()?.Trim();

            Console.Write("Enter Product Price: ");
            string productPrice = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(productQuantity) || string.IsNullOrWhiteSpace(productPrice))
            {
                Console.WriteLine("Invalid input. All fields are required.");
                return;
            }

            inventory[productCount, 0] = productName;
            inventory[productCount, 1] = productQuantity;
            inventory[productCount, 2] = productPrice;
            productCount++;

            Console.WriteLine("Product added successfully!");
        }

        static void UpdateProduct()
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products available to update.");
                return;
            }

            Console.Write("Enter the Product ID to update ", productCount);
            if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0 && productId <= productCount)
            {
                int index = productId - 1;

                Console.WriteLine("Updating Product: ", inventory[index, 0]);
                Console.Write("Enter New Product Name (or press Enter to keep " + inventory[index, 0] + "): ");
                string productName = Console.ReadLine()?.Trim();

                Console.Write("Enter New Product Quantity (or press Enter to keep " + inventory[index, 1] + "): ");
                string productQuantity = Console.ReadLine()?.Trim();

                Console.Write("Enter New Product Price (or press Enter to keep " + inventory[index, 2] + "): ");
                string productPrice = Console.ReadLine()?.Trim();

                inventory[index, 0] = string.IsNullOrWhiteSpace(productName) ? inventory[index, 0] : productName;
                inventory[index, 1] = string.IsNullOrWhiteSpace(productQuantity) ? inventory[index, 1] : productQuantity;
                inventory[index, 2] = string.IsNullOrWhiteSpace(productPrice) ? inventory[index, 2] : productPrice;

                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }

        static void ViewProducts()
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products available in the inventory.");
                return;
            }

            Console.WriteLine("\nProduct List:");
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"Product ID: {i + 1}, Name: {inventory[i, 0]}, Quantity: {inventory[i, 1]}, Price: {inventory[i, 2]}");
            }
        }
    }
}
