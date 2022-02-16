using StoreModel;
using BL;

namespace StoreUI
{
    public class PlaceOrder : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private IStoreBL _storeBL;
        public PlaceOrder(IStoreBL p_customerBL)
        {
            _storeBL = p_customerBL;
        }
        public void Display()
        {
            Console.WriteLine(" ==== Place Order ====");
            Console.WriteLine("You will need both Store Id and Customer Id to order!");
            Console.WriteLine("Please enter your selection");
            Console.WriteLine("[4] - View Orders");
            Console.WriteLine("[3] - View All Customer Information");
            Console.WriteLine("[2] - View All Store Information");
            Console.WriteLine("[1] - Start Order!");
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
                    return "OrderByStore";
                case "2":
                List<StoreFront> listOfStoreFronts = _storeBL.GetAllStoreFront();
                foreach (var item in listOfStoreFronts)
                {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                    return "PlaceOrder";
                case "3":
                List<Customer> listOfCustomer = _storeBL.GetAllCustomer();
                foreach (var item in listOfCustomer)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                    }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "PlaceOrder";
                case "4":
                List<Order> listOfOrders = _storeBL.GetAllOrders();
                Console.WriteLine("========View All Orders=======");
                foreach (var item in listOfOrders)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                    return "PlaceOrder";
                default:
                   Console.WriteLine("Please press Enter to continue");
                   Console.ReadLine();
                    return "MainMenu";

            }
        }
    }
}