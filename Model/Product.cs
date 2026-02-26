using System.Text.Json.Serialization;

namespace CW10B.Model;

public class Product
{
    public Guid SKU { get; private set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public Product(string name, int quantity)
    {
        SKU = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
    }
    [JsonConstructor]
    public Product(Guid sKU, string name, int quantity)
    {
        SKU = sKU;
        Name = name;
        Quantity = quantity;
    }


    public override string ToString()
    {
        return $"name: {Name}, quantity: {Quantity}";
    }
}