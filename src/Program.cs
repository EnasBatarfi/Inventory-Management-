using System;

public class InventoryManagementApp
{
    // Main method to run the inventory management system
    public static void Main(string[] args)
    {
        // Display welcome message
        Console.WriteLine("╔═════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║           Welcome to the Inventory Management System!           ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════╝");

        // Ask user to enter store capacity
        int capacity;
        Console.Write("\nPlease Enter your store capacity: ");

        // Validate and initialize store capacity
        while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
        {
            Console.Write("\nInvalid capacity. Please enter a positive integer: ");
        }

        // Create a new store instance with given capacity
        Store store = new Store(capacity);

        // Main loop for user actions
        while (true)
        {
            try
            {
                // Display action menu
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Initialize the store");
                Console.WriteLine("3. Delete Item");
                Console.WriteLine("4. Display Items");
                Console.WriteLine("5. Find Item by Name");
                Console.WriteLine("6. Sort Items by Name (Ascending or Descending)");
                Console.WriteLine("7. Sort Items by Date (Ascending or Descending)");
                Console.WriteLine("8. Group Items by Date");
                Console.WriteLine("9. Display Current Volume and Capacity");
                Console.WriteLine("10. Exit");
                Console.Write("\nEnter your choice (1-10): ");
                int choice;
                // Get user choice
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 10)
                {
                    Console.Write("\nInvalid input. Please enter a number between 1 and 10: ");
                }

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        AddItem(store);
                        break;
                    case 2:
                        AddInitialValues(store);
                        break;
                    case 3:
                        DeleteItem(store);
                        break;
                    case 4:
                        DisplayItems(store.Items);
                        break;
                    case 5:
                        FindItem(store);
                        break;
                    case 6:
                        SortItemsByName(store);
                        break;
                    case 7:
                        SortItemsByDate(store);
                        break;
                    case 8:
                        GroupItemsByDate(store);
                        break;
                    case 9:
                        GetStoreCurrentVolume(store);
                        break;
                    case 10:
                        Console.WriteLine("\nThank you for using the Inventory Management System!");
                        return;
                }
            }
            catch (Exception e)
            {
                // Handle exceptions
                Console.WriteLine($"\nAn error occurred: {e.Message}");
            }
        }
    }

    // Method to return the current volume of the store to the user
    private static void GetStoreCurrentVolume(Store store)
    {
        // Call the method to return the current volume
        int currentVolume = store.GetCurrentVolume();

        // Get the maximum capacity of the store.
        int maxCapacity = store.Capacity;

        Console.WriteLine($"Current volume of items in the store: {currentVolume} out of {maxCapacity}");
    }

    // Method to initialize store with initial values
    public static void AddInitialValues(Store store)
    {
        // Initialize items
        store.AddItem(new Item("Water Bottle", 10, new DateTime(2023, 1, 1)));
        store.AddItem(new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1)));
        store.AddItem(new Item("Notebook", 5, new DateTime(2023, 3, 1)));
        store.AddItem(new Item("Pen", 20, new DateTime(2023, 4, 1)));
        store.AddItem(new Item("Tissue Pack", 30, new DateTime(2023, 5, 1)));
        store.AddItem(new Item("Chips Bag", 25, new DateTime(2023, 6, 1)));
        store.AddItem(new Item("Soda Can", 8, new DateTime(2023, 7, 1)));
        store.AddItem(new Item("Soap", 12, new DateTime(2023, 8, 1)));
        store.AddItem(new Item("Shampoo", 40, new DateTime(2023, 9, 1)));
        store.AddItem(new Item("Toothbrush", 50, new DateTime(2023, 10, 1)));
        store.AddItem(new Item("Coffee", 20));
        store.AddItem(new Item("Sandwich", 15));
        store.AddItem(new Item("Batteries", 10));
        store.AddItem(new Item("Umbrella", 5));
        store.AddItem(new Item("Sunscreen", 8));
    }

    // Method to add a new item to the store
    public static void AddItem(Store store)
    {
        // Ask user to input item details
        Console.WriteLine("\nAdd Item:");
        Console.Write("Enter item name: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        // Read and validate quantity
        Console.Write("Enter quantity: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.Write("Invalid quantity. Please enter a number: ");
        }

        DateTime creationDate = DateTime.Now;

        // Ask user to specify creation date
        Console.Write("Do you want to specify the creation date? (Y/N): ");
        string specifyDateInput = Console.ReadLine()?.Trim().ToUpper() ?? "";
        if (specifyDateInput == "Y")
        {
            // Read and validate creation date 
            Console.Write("Enter creation date (yyyy-MM-dd) or leave empty for today's date: ");
            while (true)
            {
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(input) && !DateTime.TryParse(input, out creationDate))
                {
                    Console.Write("Invalid date format. Please enter a valid date or leave it empty: ");
                }
                else
                {
                    break;
                }
            }
        }

        // Add item to the store
        store.AddItem(new Item(name, quantity, creationDate));
    }

    // Method to delete an item from the store
    public static void DeleteItem(Store store)
    {
        // Ask user to input item name for deletion
        Console.Write("\nEnter item name to delete: ");
        string name = Console.ReadLine() ?? "";
        // Delete item from the store
        store.DeleteItem(name);
    }

    // Method to find an item by its name
    public static void FindItem(Store store)
    {
        // Ask user to input item name for search
        Console.Write("\nEnter item name to find: ");
        string name = Console.ReadLine() ?? "";
        // Find and display item details
        store.FindItemByName(name);
    }

    // Method to sort items by name
    public static void SortItemsByName(Store store)
    {
        // Ask user for sort order
        Console.WriteLine("\nSort by name:");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");
        Console.Write("Enter your choice (1 or 2): ");

        int sortOrderInput;
        while (!int.TryParse(Console.ReadLine(), out sortOrderInput) || (sortOrderInput != 1 && sortOrderInput != 2))
        {
            Console.Write("Invalid input. Please enter 1 for Ascending or 2 for Descending: ");
        }

        // Determine sort order
        var sortOrder = sortOrderInput == 1 ? SortOrder.ASC : SortOrder.DESC;
        var orderedItems = store.SortByName(sortOrder);
        // Display sorted items
        DisplayItems(orderedItems);
    }

    // Method to sort items by date
    public static void SortItemsByDate(Store store)
    {
        // Ask user for sort order
        Console.WriteLine("\nSort by date:");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");
        Console.Write("Enter your choice (1 or 2): ");

        int sortOrderInput;
        while (!int.TryParse(Console.ReadLine(), out sortOrderInput) || (sortOrderInput != 1 && sortOrderInput != 2))
        {
            Console.Write("Invalid input. Please enter 1 for Ascending or 2 for Descending: ");
        }

        // Determine sort order
        var sortOrder = sortOrderInput == 1 ? SortOrder.ASC : SortOrder.DESC;
        var orderedItems = store.SortByDate(sortOrder);
        // Display sorted items
        DisplayItems(orderedItems);
    }

    // Method to group items by date
    public static void GroupItemsByDate(Store store)
    {
        // Group items by date
        var (newArrivals, oldItems) = store.GroupByDate();

        // Display new arrivals
        Console.WriteLine("\nNew Arrivals:");
        DisplayItems(newArrivals);

        // Display old items
        Console.WriteLine("\nOld Items:");
        DisplayItems(oldItems);
    }

    // Method to display items
    public static void DisplayItems(List<Item> items)
    {
        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                             Store Items Table                                │");
        Console.WriteLine("├──────────────────────────────────────────────────────────────────────────────┤");

        if (items.Count > 0)
        {
            Console.WriteLine("│ Item Name                      │ Quantity   │ Created Date                   │");
            Console.WriteLine("├────────────────────────────────┼────────────┼────────────────────────────────┤");

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
        else
        {
            Console.WriteLine("│                          No items in the store                               │");
        }

        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────┘");

    }

}

