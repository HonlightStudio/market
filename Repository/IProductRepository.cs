using CW10B.Model;

namespace CW10B.Repository;

public interface IProductRepository
{
    public void Create(string name , int quantity);
    public void Update(string name, int quantity);
    public void DeleteByName(string name);
    public void DeleteById(Guid id);
    public IReadOnlyList<Product> GetAll();
    public Product GetById(Guid id);
    public Product GetByName(string name);
    public bool ContainsName(string name);
}