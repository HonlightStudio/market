using CW10B.Logger;
using CW10B.Model;
using CW10B.Repository;
using CW10B.Extensions;
namespace CW10B.Service;

public class ProductService(ILogger logger, IProductRepository productRepository)
{
    ILogger _logger = logger;
    IProductRepository _productRepository = productRepository;


    public void AddProduct( string name, int quantity,int min)
    {
        _productRepository.Create(name, quantity,min);
    }

    public void ReceiveGoods(string name,int quantity)
    {
        try
        {
            var product = _productRepository.GetByName(name);
            _productRepository.Update(name, product.Quantity +  quantity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        
    }

    public void BackUp()
    {
        _productRepository.CreateBackUp();
    }

    public IReadOnlyList<Product> GetLowCountProducts()
    {
        var list = new List<Product>();
        foreach (var product in _productRepository.GetAll())
        {
            if (product.Quantity < product.Min)
                list.Add(product);
            
        }
        return list;
        
    }
    

    public void DeleteProduct(string name)
    {
        _productRepository.DeleteByName(name);
    }

    public void DispatchGoods(string name, int quantity)
    {
        try
        {
            var product = _productRepository.GetByName(name);
            if (product.Quantity - quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            _productRepository.Update(name, product.Quantity -  quantity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }

    public void PrintStockReport()
    {
        foreach (var product in _productRepository.GetAll())
        {
            Console.WriteLine(product);
        }
    }
}