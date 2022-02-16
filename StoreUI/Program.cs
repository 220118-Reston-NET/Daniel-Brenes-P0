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
            Log.Information("Displaying OrderByStore to user");
            menu = new OrderByStore(new StoreBL ( new SQLRepo(_connectionString)));
            break;
        case "ReplenishInventory":
            Log.Information("Displaying ReplenishInventory to user");
            menu = new ReplenishInventory(new StoreBL ( new SQLRepo(_connectionString)));
            break;
        case "ViewAllProducts":
            Log.Information("Displaying ViewAllProducts to user");
            menu = new ViewAllProduct(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewCustomer":
            Log.Information("Displaying ViewCustomer to user");
            menu = new ViewCustomer(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFrontInventory":
            Log.Information("Displaying ViewStoreFrontInventory to user");
            menu = new ViewStoreFrontInventory(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "SearchCustomer":
            Log.Information("Displaying SearchCustomer to user");
            menu = new SearchCustomer(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "ViewStoreFront":
            Log.Information("Displaying ViewStoreFrontMenu to user");
            menu = new ViewStoreFront(new StoreBL(new SQLRepo(_connectionString)));
            break;
        case "AddStoreFront":
            menu = new AddStoreFrontMenu(new StoreBL (new SQLRepo(_connectionString)));
            break;
        case "PlaceOrder":
            Log.Information("Displaying PlaceOrder to user");
            menu = new PlaceOrder( new StoreBL( new SQLRepo(_connectionString)));
            break;
        case "AddCustomer":
            Log.Information("Displaying AddCustomerMenu to user");
            menu = new AddCustomerMenu(new StoreBL(new SQLRepo(_connectionString)));
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "Exit":
            Log.Information("Exiting application");
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }
}