using StoreModel;
using BL;

namespace StoreUI
{

    public class ViewStoreFront : IMenu
    {
        private static StoreFront _newStoreFront = new StoreFront();
        private IStoreBL _storefrontBL;
        public ViewStoreFront(IStoreBL p_storefrontBL)
        {
            _storefrontBL = p_storefrontBL;
        }
        public void Display()
        {
                List<StoreFront> listOfStoreFronts = _storefrontBL.GetAllStoreFront();
                foreach (var item in listOfStoreFronts)
                {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                }
                
                // Console.WriteLine("Press Enter to continue");
                // Console.ReadLine();
                Console.WriteLine("======================");
                Console.WriteLine("View Products");
                Console.WriteLine("[2] View by StoreID");
                Console.WriteLine("[1] View All Products");
                Console.WriteLine("[0] to Go Back ");
                
                    
        }
        public string UserChoice()
        {
            
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 0:
                   return "MainMenu";
                case 1:
                    return "ViewAllProducts";
                case 2:
                    return "ViewStoreFrontInventory";
                
    
               default:
                   Console.WriteLine("Please input a valid response");
                   Console.WriteLine("Please press Enter to continue");
                   Console.ReadLine();
                    return "MainMenu";

           }
        }

    }
}