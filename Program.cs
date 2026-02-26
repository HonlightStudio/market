// See https://aka.ms/new-console-template for more information

using CW10B.Logger;
using CW10B.Menu;
using CW10B.Repository;
using CW10B.Service;

var main = new MainMenu(new ProductService(new FileLogger(),new ProductRepository()));
main.Menu();