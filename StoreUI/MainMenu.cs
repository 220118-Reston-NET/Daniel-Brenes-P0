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
            Console.WriteLine("[4] View Stores and/or Products");
            Console.WriteLine("[3] View Orders");
            Console.WriteLine("[2] Add A Store to the Mall");
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
                    return "AddStoreFront";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}