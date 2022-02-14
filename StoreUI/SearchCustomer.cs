using StoreBL;
using StoreModel;

namespace StoreUI
{
    public class SearchCustomer : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        private List<Customer> _listOfCustomer;
        public SearchCustomer(ICustomerBL p_customerBL)
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

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please enter the Customer ID");
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    //_newCustomer.CustomerID = Convert.ToInt32(Console.ReadLine());
                    //_customerBL.SearchCustomerById(userInt);
                    // int userIn = Convert.ToInt32(Console.ReadLine());
                    // Customer myCustomer = _customerBL.SearchCustomerById(userIn);
                    List<Customer> listOfCustomer = _customerBL.SearchCustomerById(userIn);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter an Phone Number");
                    _newCustomer.PhoneNumber = Console.ReadLine();
                    return "SearchCustomer";
                case "3":
                    Console.WriteLine("Please enter an email");
                    _newCustomer.Email = Console.ReadLine();
                    return "SearchCustomer";
                case "4": 
                    Console.WriteLine("Please enter an address!");
                    _newCustomer.Address = Console.ReadLine();
                    return "SearchCustomer";
                case "5":
                    Console.WriteLine("Please enter a name!");
                    _newCustomer.Name = Console.ReadLine();
                    return "SearchCustomer";
                case "6":
                    Console.WriteLine("Please enter the starting wallet");
                    _newCustomer.Wallet = Convert.ToDouble(Console.ReadLine());
                    return "SearchCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";

            }
        }
    }
}