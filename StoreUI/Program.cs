global using Serilog;
using Microsoft.Extensions.Configuration;
using StoreUI;
using BL;
using StoreDL;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
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
        case "OrderByStore":
            menu = new OrderByStore(new StoreBL ( new SQLRepo(_connectionString)));
            break;
        case "ReplenishInventory":
            menu = new ReplenishInventory(new StoreBL ( new SQLRepo(_connectionString)));
            break;
        case "ViewAllProducts":
            menu = new ViewAllProduct(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewCustomer":
            menu = new ViewCustomer(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFrontInventory":
            menu = new ViewStoreFrontInventory(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "SearchCustomer":
            menu = new SearchCustomer(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFront":
            menu = new ViewStoreFront(new StoreBL(new SQLRepo(_connectionString)));
            break;
        case "AddStoreFront":
            menu = new AddStoreFrontMenu(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "PlaceOrder":
            menu = new PlaceOrder( new StoreBL( new SQLRepo(_connectionString)));
            break;
        case "AddCustomer":
            menu = new AddCustomerMenu(new StoreBL(new SQLRepo(_connectionString)));
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