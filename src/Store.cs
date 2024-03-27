using System;

public class Store
{
    // Constructor to initialize store with capacity
    public Store(int capacity)
    {
        Capacity = capacity;
        Items = new List<Item>();
    }

    // Capacity property to get store capacity
    public int Capacity { get; private set; }
    // List to store items in the store
    public List<Item> Items { get; private set; }

    // Method to add an item to the store
    public void AddItem(Item newItem)
    {
        // Check if adding the new item exceeds store capacity
        if (GetCurrentVolume() + newItem.Quantity <= Capacity)
        {
            // Check if the item already exists in the store
            bool itemIsExist = this.Items.Any(item => item.Name.ToLower() == newItem.Name.ToLower());
            if (!itemIsExist)
            {
                Items.Add(newItem);
                Console.WriteLine("Item added successfully");
            }
            else
            {
                throw new ArgumentException("Item already exists");
            }
        }
        else
        {
            throw new ArgumentException("You have reached the maximum store capacity");
        }
    }

    // Method to delete an item from the store
    public void DeleteItem(string itemName)
    {
        // Find the item by name in the store
        Item? foundedItem = this.Items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());
        if (foundedItem != null)
        {
            // Remove the item from the store
            Items.Remove(foundedItem);
            Console.WriteLine("Item deleted successfully");
        }
        else
        {
            throw new ArgumentException("Item does not exist");
        }
    }

    // Method to get the current volume of the store
    public int GetCurrentVolume()
    {
        return Items.Sum(item => item.Quantity);
    }

    // Method to find an item by its name in the store
    public Item? FindItemByName(string itemName)
    {
        Item? foundedItem = Items.Find(item => item.Name.ToLower() == itemName.ToLower());
        if (foundedItem != null)
        {
            Console.WriteLine($"Item '{itemName}' found successfully");
        }
        else
        {
            throw new ArgumentException("Item does not exist");
        }
        return foundedItem;
    }

    // Method to sort items in the store by name in ascending order
    public List<Item> SortByName(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
            return Items.OrderBy(item => item.Name).ToList();
        else
            return Items.OrderByDescending(item => item.Name).ToList();
    }

    // Method to sort items in the store by date
    public List<Item> SortByDate(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
            return Items.OrderBy(item => item.CreatedDate).ToList();
        else
            return Items.OrderByDescending(item => item.CreatedDate).ToList();
    }

    // Method to group items in the store by date
    public (List<Item>, List<Item>) GroupByDate()
    {
        var groups = Items.GroupBy(item => (DateTime.Now - item.CreatedDate).TotalDays <= 3 * 30 ? "New Arrival" : "Old")
                          .ToList();

        var newArrival = groups.FirstOrDefault(group => group.Key == "New Arrival")?.ToList() ?? new List<Item>();
        var oldItems = groups.FirstOrDefault(group => group.Key == "Old")?.ToList() ?? new List<Item>();

        return (newArrival, oldItems);
    }
}
