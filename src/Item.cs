public class Item
{
    private string name;
    private int quantity;
    private DateTime createdDate;
    public Item(string name, int quantity, DateTime? createdDate = default)
    {
        this.name = name;
        Quantity = quantity;
        CreatedDate = createdDate ?? DateTime.Now;
    }
    public string Name
    {
        get { return this.name; }
    }
    public int Quantity
    {
        get { return this.quantity; }
        set
        {
            if (value < 0) throw new ArgumentException("Amount cannot be negative");
            else this.quantity = value;
        }
    }
    public DateTime CreatedDate
    {
        get { return this.createdDate; }
        set { this.createdDate = value; }
    }

    public override string ToString()
    {
        return $"Name: {name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
    }
}
