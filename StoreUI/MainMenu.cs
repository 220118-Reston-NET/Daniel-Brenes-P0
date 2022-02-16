namespace StoreUI
{
    /*
        MainMenu inherits IMenu interface but since it is a class it needs to give actual implementation details to the methods
        stated inside of the interface
    */
    public class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Outdoor Shopping Mall");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[5] Place Order");
            
            //Console.WriteLine("[4] View Products by Store");
            Console.WriteLine("[4] View StoreFronts/Products and/or Replenish Inventory");
            Console.WriteLine("[3] View Customers");
            Console.WriteLine("[2] Search Customers");
            Console.WriteLine("[1] Add A Customer to the Mall");
            Console.WriteLine("[0] Exit");
        }
        
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "AddCustomer";
                case "2":
                    return "SearchCustomer";
                case "3":
                    return "ViewCustomer";
                case "4":
                    return "ViewStoreFront";
                case "5":
                    return "PlaceOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}