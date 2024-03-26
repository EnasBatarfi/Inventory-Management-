using System;

public class InventoryManagementApp
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Welcome to the Inventory Management System!");

            int capacity;
            Console.Write("Please Enter your store capacity: ");

            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.Write("Invalid capacity. Please enter a number...");

            }

            Store store = new Store(capacity);

            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Delete Item");
                Console.WriteLine("3. Display Items");
                Console.WriteLine("4. Find Item by Name");
                Console.WriteLine("5. Sort Items by Name (Ascending)");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddItem(store);
                        break;
                    case 2:
                        DeleteItem(store);
                        break;
                    case 3:
                        store.DisplayItems();
                        break;
                    case 4:
                        FindItem(store);
                        break;
                    case 5:
                        SortItems(store);
                        break;
                    case 6:
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void AddItem(Store store)
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter quantity: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid quantity. Please enter a number...");
        }

        store.AddItem(new Item(name, quantity));
    }

    static void DeleteItem(Store store)
    {
        Console.Write("Enter item name to delete: ");
        string name = Console.ReadLine() ?? "";
        store.DeleteItem(name);
    }

    static void FindItem(Store store)
    {
        Console.Write("Enter item name to find: ");
        string name = Console.ReadLine() ?? "";

        store.FindItemByName(name);
    }

    static void SortItems(Store store)
    {
        var orderedItems = store.SortByNameAsc();
        foreach (var item in orderedItems)
        {
            Console.WriteLine(item);
        }

    }
}
