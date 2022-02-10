using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class AddStoreFrontMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        //private static Customer _newCustomer = new Customer();
        //private ICustomerBL _customerBL;
        private static StoreFront _newStoreFront = new StoreFront();
        private IStoreFrontBL _storeBL;
        public AddStoreFrontMenu(IStoreFrontBL p_storefront)
        {
            _storeBL = p_storefront;
        }
        public void Display()
        {
            Console.WriteLine("Enter Store information");
            Console.WriteLine("[4] Name - "  + _newStoreFront.Name);
            Console.WriteLine("[3] Address - " + _newStoreFront.Address);
            Console.WriteLine("[2] Type of Store" + _newStoreFront.TypeOfStore);
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
                    _storeBL.AddStoreFront(_newStoreFront);
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter the type of StoreFront:");
                    Console.WriteLine("Apparel, Grocery, Luxury, Liquor or Other");
                    _newStoreFront.TypeOfStore = Console.ReadLine();
                    return "AddCustomer";
                case "3": 
                    Console.WriteLine("Please enter the StoreFront Address");
                    _newStoreFront.Address = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Please enter the StoreFront Name");
                    _newStoreFront.Name = Console.ReadLine();
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddStoreFront";

            }
        }

    }
}