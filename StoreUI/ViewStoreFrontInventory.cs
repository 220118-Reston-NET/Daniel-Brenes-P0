using StoreModel;
using StoreBL;

namespace StoreUI
{

    public class ViewStoreFrontInventory : IMenu
    {
        private IStoreFrontBL _storefrontBL;
        private ILineItemBL _lineItemBL;
        public ViewStoreFrontInventory(ILineItemBL p_lineitemBL)
        {
            _lineItemBL = p_lineitemBL;
        }
        public void Display()
        {
            Console.Write("Enter the store id :");
            int id = Convert.ToInt32(Console.ReadLine());

            List<LineItem> listOfLineItem = _lineItemBL.GetLineItemByStoreId(id);
                foreach (var item in listOfLineItem)
                {
                    Console.WriteLine("================");
                    Console.WriteLine(item);
                }
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