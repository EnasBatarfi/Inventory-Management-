using System;

public class Item
{
    // Constructor to initialize item properties
    public Item(string name, int quantity, DateTime? createdDate = default)
    {
        // Validate quantity
        if (quantity < 0)
            throw new ArgumentException("Quantity must be a non-negative value");

        Name = name;
        Quantity = quantity;
        CreatedDate = createdDate ?? DateTime.Now;
    }

    // Property to get item name
    public string Name { get; private set; }

    // Property to get item quantity
    public int Quantity { get; private set; }

    // Property to get item creation date
    public DateTime CreatedDate { get; private set; }

    // Override ToString method to display item details
    public override string ToString()
    {
        return $"│ {Name,-30} │ {Quantity,-10} │ {CreatedDate,-30} │";
    }

}
