using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class PlaceOrder : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public PlaceOrder(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Display()
        {
            Console.WriteLine("Press 1 To Select StoreFront");
            Console.WriteLine("Press 0 To Go Back");

        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "ReplenishInventory";
               
                default:
                   Console.WriteLine("Please press Enter to continue");
                   Console.ReadLine();
                    return "MainMenu";

            }

            return "";
        }

    }
}