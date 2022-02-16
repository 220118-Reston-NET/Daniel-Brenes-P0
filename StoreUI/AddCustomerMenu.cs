using StoreModel;
using BL;

namespace StoreUI
{
    public class AddCustomerMenu : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private IStoreBL _customerBL;
        public AddCustomerMenu(IStoreBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[6] Initial Wallet : $" + _newCustomer.Wallet);
            Console.WriteLine("[5] Name - "  + _newCustomer.Name);
            Console.WriteLine("[4] Address - " + _newCustomer.Address);
            Console.WriteLine("[3] Email - " + _newCustomer.Email);
            Console.WriteLine("[2] Phone Number - " + _newCustomer.PhoneNumber);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    try
                    {
                    Log.Information("Adding customer \n " + _newCustomer);
                    _customerBL.AddCustomer(_newCustomer);
                    Log.Information("Successful at adding customer");
                    }
                    catch (Exception exc)
                    {
                        Log.Warning("Failed to add customer");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                    }
                    _newCustomer = new Customer();
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter an Phone Number");
                    _newCustomer.PhoneNumber = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter an email");
                    _newCustomer.Email = Console.ReadLine();
                    return "AddCustomer";
                case "4": 
                    Console.WriteLine("Please enter an address!");
                    _newCustomer.Address = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                    Console.WriteLine("Please enter a name!");
                    _newCustomer.Name = Console.ReadLine();
                    return "AddCustomer";
                case "6":
                    Console.WriteLine("Please enter the starting wallet");
                    _newCustomer.Wallet = Convert.ToDouble(Console.ReadLine());
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";

            }
        }

    }
}