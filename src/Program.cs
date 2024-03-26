public class InventoryManagementApp
{
    public static void Main(string[] args)
    {
        Item item = new Item("shampoo", 2);
        Console.WriteLine(item.Name);
        Console.WriteLine(item.Quantity);
        Console.WriteLine(item.CreatedDate);
        Store store = new Store();
        store.AddItem(item);
        store.DisplayItems();
        store.DeleteItem(item);
        store.DisplayItems();


    }
}