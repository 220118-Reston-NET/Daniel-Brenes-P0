using BL;
using StoreModel;

namespace StoreUI
{
    public class ReplenishInventory : IMenu
    {
        private static LineItem _newLineItem = new LineItem();
        private IStoreBL _storeBL;
        private List<LineItem> _listOfLineItem;
        public ReplenishInventory(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter the Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Quantity to Add");
            int quantity = Convert.ToInt32(Console.ReadLine());

            _newLineItem = _storeBL.ReplenishQuantity(productId, quantity);

            Console.WriteLine("================");
            Console.WriteLine("Replenishing Inventory ");
            Console.WriteLine(_newLineItem);
            Console.WriteLine();
        }
        public string UserChoice()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            return "MainMenu";
        }

    }
}