using StoreModel;
using StoreBL;

namespace StoreUI
{

    public class ViewStoreFrontInventory : IMenu
    {
        private static StoreFront _newStoreFront = new StoreFront();
        private IStoreFrontBL _storefrontBL;
        public ViewStoreFrontInventory(IStoreFrontBL p_storefrontBL)
        {
            _storefrontBL = p_storefrontBL;
        }
        public void Display()
        {
                  
                    
        }
        public string UserChoice()
        {
            Console.WriteLine("Please press Enter to continue");
            string userInput = Console.ReadLine();

            //switch (userInput)
            //{
              //  case "0":
              //      return "MainMenu";
    
               // default:
                //    Console.WriteLine("Please input a valid response");
                 //   Console.WriteLine("Please press Enter to continue");
                 //   Console.ReadLine();
                    return "MainMenu";

           // }
        }

    }
}