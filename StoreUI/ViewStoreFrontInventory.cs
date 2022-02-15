using StoreModel;
using BL;

namespace StoreUI
{

    public class ViewStoreFrontInventory : IMenu
    {
        private IStoreBL _storefrontBL;
        private IStoreBL _lineItemBL;
        public ViewStoreFrontInventory(IStoreBL p_lineitemBL)
        {
            _lineItemBL = p_lineitemBL;
        }
        public void Display()
        {
            Console.Write("Enter the StoreId :");
            int id = Convert.ToInt32(Console.ReadLine());

            List<LineItem> listOfLineItem = _lineItemBL.GetLineItemByStoreId(id);
            Console.WriteLine("========== LineItems ==========");
                foreach (var item in listOfLineItem)
                {
                    Console.WriteLine(item);
                }
            Console.WriteLine("----------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Replenish Inventory");
            Console.WriteLine("[0] Exit");


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
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";

            }
        }

    }
}