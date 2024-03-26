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
            throw new ArgumentException("Item is already exists");
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
            throw new ArgumentException("Item is not exists");
        }
    }
    public void DisplayItems()
    {
        Console.WriteLine(items.Count() > 0 ? string.Join(", ", items) : "No items in the store");
    }
}