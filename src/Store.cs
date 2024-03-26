using System.ComponentModel.DataAnnotations;

public class Store
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        bool itemIsExist = this.items.Any(item => item.Name == newItem.Name);
        if (!itemIsExist)
        {
            items.Add(newItem);
            Console.WriteLine("Item added successfully");
        }
        else
        {
            Console.WriteLine("Item is already exists");
        }
    }
    public void DeleteItem(Item delItem)
    {
        Item? foundedItem = this.items.FirstOrDefault(item => item.Name == delItem.Name);
        if (foundedItem != null)
        {
            items.Remove(delItem);
            Console.WriteLine("Item deleted successfully");

        }
        else
        {
            Console.WriteLine("Item is not exists");
        }
    }
    public int GetCurrentVolume()
    {
        return items.Sum(item => item.Quantity);
    }
    public Item? FindItemByName(string itemName)
    {
        Item? foundedItem = items.Find(item => item.Name == itemName);
        if (foundedItem != null)
        {
            Console.WriteLine($"Item {itemName} is founded successfully");
        }
        else
        {
            Console.WriteLine("Item is not exists");

        }
        return foundedItem;

    }
    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(item => item.Name).ToList();
    }

    public void DisplayItems()
    {
        Console.WriteLine(items.Count() > 0 ? string.Join("\n", items) : "No items in the store");
    }
}