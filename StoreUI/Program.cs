global using Serilog;
using Microsoft.Extensions.Configuration;
using StoreUI;
using StoreBL;
using StoreDL;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();


bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();
    
    switch (ans)
    {
        case "AddStoreFront":
            menu = new AddStoreFrontMenu(new StoreFrontBL (new StoreFrontRepo()));
            break;
        case "AddCustomer":
            menu = new AddCustomerMenu(new CustomerBL(new CustomerRepo()));
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