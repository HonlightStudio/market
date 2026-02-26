using CW10B.Model;
using CW10B.Service;

namespace CW10B.Menu;

public class MainMenu(ProductService productService)
{
    private ProductService _productService = productService;

    private string _errorMessage = "";

    public void AddProduct()
    {

        if (string.IsNullOrWhiteSpace(_errorMessage))
            Console.WriteLine(_errorMessage);

        while (true)
        {
            try
            {
                Console.WriteLine("Adding product");
                Console.WriteLine("name:");
                var name = Console.ReadLine();
                Console.WriteLine("Quantity:");
                var Quantity = int.Parse(Console.ReadLine());
                var min = int.Parse(Console.ReadLine());
                _productService.AddProduct(name, Quantity, min);
                _errorMessage = "";
                break;
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }
    }

    public void ReceiveGoods()
    {

        if (string.IsNullOrWhiteSpace(_errorMessage))
            Console.WriteLine(_errorMessage);

        while (true)
        {
            try
            {
                Console.WriteLine("Receive product");
                Console.WriteLine("name:");
                var name = Console.ReadLine();
                Console.WriteLine("Quantity:");
                var Quantity = int.Parse(Console.ReadLine());
                _productService.ReceiveGoods(name, Quantity);
                _errorMessage = "";
                break;
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }
    }

    public void DispatchGoods()
    {


        if (string.IsNullOrWhiteSpace(_errorMessage))
            Console.WriteLine(_errorMessage);

        while (true)
        {
            try
            {
                Console.WriteLine("Dispatch product");
                Console.WriteLine("name:");
                var name = Console.ReadLine();
                Console.WriteLine("Quantity:");
                var Quantity = int.Parse(Console.ReadLine());
                _productService.DispatchGoods(name, Quantity);
                _errorMessage = "";
                break;
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }
    }

    public void PrintStockReport()
    {
        _productService.PrintStockReport();
    }
    public void DeleteProduct()
    {
        if (string.IsNullOrWhiteSpace(_errorMessage))
            Console.WriteLine(_errorMessage);

        while (true)
        {
            try
            {
                Console.WriteLine("Deleting product");
                Console.WriteLine("name:");
                var name = Console.ReadLine();
                _productService.DeleteProduct(name);
                _errorMessage = "";
                break;
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }
    }

    public void Menu()
    {


        Console.WriteLine(@"1:Add product
2:receive goods
3:Dispatch goods
4:Display
5:Delete
6:GetLowQuantity
7:Exit
");

        var command = Console.ReadKey().Key;


        switch (command)
        {
            case ConsoleKey.D1:
                AddProduct();
                break;
            case ConsoleKey.D2:
                ReceiveGoods();
                break;
            case ConsoleKey.D3:
                DispatchGoods();
                break;
            case ConsoleKey.D4:
                PrintStockReport();
                break;
            case ConsoleKey.D5:
                DeleteProduct();
                break;
            case ConsoleKey.D6:
                foreach (var product in _productService.GetLowCountProducts())
                    Console.WriteLine(product);
                break;
            case ConsoleKey.D7:
                break;
            default:
                throw new ArgumentOutOfRangeException();

        }





    }
}