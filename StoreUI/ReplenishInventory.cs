using BL;
using StoreModel;

namespace StoreUI
{
    public class ReplenishInventory : IMenu
    {
        private static LineItem _newLineItem = new LineItem();
        private IStoreBL _lineItemBL;
        private List<LineItem> _listOfLineItem;
        public ReplenishInventory(IStoreBL p_lineItemBL)
        {
            _lineItemBL = p_lineItemBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter the Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Quantity to Add");
            int quantity = Convert.ToInt32(Console.ReadLine());

            _newLineItem = _lineItemBL.ReplenishQuantity(productId, quantity);

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