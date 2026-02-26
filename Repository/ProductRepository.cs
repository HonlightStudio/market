using System.Text.Json;
using CW10B.Consts;
using CW10B.Model;

namespace CW10B.Repository;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        Load();
    }

    public void Create(string name, int quantity,int min)
    {
        if (!ContainsName(name))
        {
            _products.Add(new Product(name, quantity,min));
            Save();
        }
        
        throw new Exception("Product already exists");
        
        
    }

    public void Update(string name, int quantity)
    {
        if (ContainsName(name))
        {
            _products.First(p => p.Name == name).Quantity = quantity;
            Save();
            return;
        }
        throw new Exception("Product does not exist");
    }

    public void DeleteByName(string name)
    {
        if(_products.RemoveAll(p => p.Name == name) <= 0)
            throw new Exception("Product does not exist");
        
        Save();
    }

    public void DeleteById(Guid id)
    {
        if(_products.RemoveAll(p => p.SKU == id) <= 0)
            throw new Exception("Product does not exist");
        
        Save();
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products;
    }

    public Product GetById(Guid id)
    {
        return _products.First(p => p.SKU == id);
    }

    public Product GetByName(string name)
    {
        //return _products.FirstOrDefault(p => p.Name == name , null) ?? throw new Exception("Product does not exist");

        foreach (var product in _products)
        {
            if (product.Name == name)
                return product;
        }
        throw new Exception("Product does not exist");
    }

    public bool ContainsName(string name)
    {
        return _products.Any(p => p.Name == name);
    }

    private void Save()
    {
        string listJson = JsonSerializer.Serialize(_products);
        File.WriteAllText(FilePath.ProductPath, listJson);
    }

    private void Load()
    {
        if (File.Exists(FilePath.ProductPath))
        {
            string listJson = File.ReadAllText(FilePath.ProductPath);

            try
            {
                _products = JsonSerializer.Deserialize<List<Product>>(listJson) ?? new List<Product>();
            }
            catch (Exception e)
            {
                _products = new List<Product>();
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            _products = new List<Product>();
            Save();
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}