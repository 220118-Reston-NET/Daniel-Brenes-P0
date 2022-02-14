using StoreModel;
using StoreBL;

namespace StoreUI
{

    public class ViewCustomer : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public ViewCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Display()
        {
                  List<Customer> listOfCustomer = _customerBL.GetAllCustomer();
                    foreach (var item in listOfCustomer)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
    
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";

            }
        }

    }
}