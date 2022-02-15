using BL;
using StoreModel;

namespace StoreUI
{
    public class SearchCustomer : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private IStoreBL _customerBL;
        private List<Customer> _listOfCustomer;
        public SearchCustomer(IStoreBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Display()
        {
            Console.WriteLine("Select Search information");
            Console.WriteLine("[5] Name - ");
            Console.WriteLine("[4] Address - ");
            Console.WriteLine("[3] Email - ");
            Console.WriteLine("[2] Phone Number - ");
            Console.WriteLine("[1] By ID");
            Console.WriteLine("[0] Go Back");
            // _listOfCustomer = _customerBL.SearchCustomer(string inputString);
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            List<Customer> listOfCustomer = new List<Customer>();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please enter the Customer ID");
                    //_newCustomer.CustomerID = Convert.ToInt32(Console.ReadLine());
                    //_customerBL.SearchCustomerById(userInt);
                    // int userIn = Convert.ToInt32(Console.ReadLine());
                    // Customer myCustomer = _customerBL.SearchCustomerById(userIn);
                    // List<Customer> listOfCustomer = _customerBL.SearchCustomerById(userIn);
                    try
                    {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    listOfCustomer = _customerBL.SearchCustomerById(userIn);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch(Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    return "SearchCustomer";
                    }
                case "2":
                    Console.WriteLine("Please enter an Phone Number");
                    try
                    {
                    string phoneNumber = Console.ReadLine();
                    listOfCustomer = _customerBL.SearchCustomerByPhoneNumber(phoneNumber);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch(Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    return "SearchCustomer";
                    }
                case "3":
                    Console.WriteLine("Please enter an email");
                    try
                    {
                    string email = Console.ReadLine();
                    listOfCustomer = _customerBL.SearchCustomerByEmail(email);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    return "SearchCustomer";
                    }
                case "4": 
                    Console.WriteLine("Please enter an address!");
                    try 
                    {
                    string address = Console.ReadLine();
                    listOfCustomer = _customerBL.SearchCustomerByAddress(address);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    return "SearchCustomer";
                    }
                case "5":
                    Console.WriteLine("Please enter a name!");
                    try
                    {
                    string name = Console.ReadLine();
                    listOfCustomer = _customerBL.SearchCustomerByName(name);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    return "SearchCustomer";
                    }
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";

            }
        }
    }
}