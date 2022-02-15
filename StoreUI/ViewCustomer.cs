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
                   
        }
        public string UserChoice()
        {
            Console.WriteLine("Please press Enter to continue");
            string userInput = Console.ReadLine();

           // switch (userInput)
            {
               
             //   default:
                //    Console.WriteLine("Please press Enter to continue");
               //     Console.ReadLine();
                    return "MainMenu";

            }
        }

    }
}