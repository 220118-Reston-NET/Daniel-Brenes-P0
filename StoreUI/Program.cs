global using Serilog;
using Microsoft.Extensions.Configuration;
using StoreUI;
using StoreBL;
using StoreDL;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string _connectionString = configuration.GetConnectionString("Reference2DB");
bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();
    
    switch (ans)
    {
        case "ViewAllProducts":
            menu = new ViewAllProduct(new ProductBL (new SQLRepo(_connectionString)));
            break;
        case "ViewCustomer":
            menu = new ViewCustomer(new CustomerBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFrontInventory":
            menu = new ViewStoreFrontInventory(new StoreFrontBL (new SQLRepo(_connectionString)));
            break;
        case "SearchCustomer":
            menu = new SearchCustomer(new CustomerBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFront":
            menu = new ViewStoreFront(new StoreFrontBL(new SQLRepo(_connectionString)));
            break;
        case "AddStoreFront":
            menu = new AddStoreFrontMenu(new StoreFrontBL (new SQLRepo(_connectionString)));
            break;
        case "AddCustomer":
            menu = new AddCustomerMenu(new CustomerBL(new SQLRepo(_connectionString)));
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }
}