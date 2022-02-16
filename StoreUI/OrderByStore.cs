using BL;
using StoreModel;

namespace StoreUI
{
    public class OrderByStore : IMenu
    {
        private Order _newOrder = new Order();
        private IStoreBL _storeBL;
        private Order _myOrder;
        private static List<LineItem> _shoppingCart = new List<LineItem>();
        public OrderByStore(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Display()
        {
            Console.WriteLine("Placing Order");
        }
        public string UserChoice()
        {
            bool repeat = true;
                List<Customer> listOfCustomer = _storeBL.GetAllCustomer();
                foreach (var item in listOfCustomer)
                {
                Console.WriteLine("================");
                Console.WriteLine(item);
                }
                Console.WriteLine("================");
                Console.Write("Enter the Customer Id :");
                int customerId = Convert.ToInt32(Console.ReadLine());

                List<StoreFront> listOfStoreFronts = _storeBL.GetAllStoreFront();
                foreach (var item in listOfStoreFronts)
                {
                    Console.WriteLine("================");
                    Console.WriteLine(item);
                }
                Console.WriteLine("================");
                Console.Write("Enter the Store Id :");
                int storeId = Convert.ToInt32(Console.ReadLine());
                List<LineItem> listOfLineItem = _storeBL.GetLineItemByStoreId(storeId);
                
            while (repeat)
            {
                Console.WriteLine("========== LineItems ==========");
                foreach (var item in listOfLineItem)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter the ProductId to Add to Cart :");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Quantity to Add to Cart :");
                int quantity = Convert.ToInt32(Console.ReadLine());
                LineItem currentItem = _storeBL.GetLineItem(productId);
                currentItem.Quantity = quantity;
                for(int i = 1; i <= quantity; i++)
                {
                    _shoppingCart.Add(currentItem);
                }
                Console.WriteLine("Current Cart: ");
                foreach (var item in _shoppingCart)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press 2 to Add more Items");
                Console.WriteLine("Press 1 to Check Out");
                Console.WriteLine("Press 0 to Cancel Order");
                string userIn = Console.ReadLine();
                switch (userIn)
                {
                    case "2":
                        break;
                    case "1":
                    _newOrder.CustomerId = customerId;
                    _newOrder.StoreFrontId = storeId;
                    foreach(var item in _shoppingCart)
                    {
                        _newOrder.LineItems.Add(item);
                        _newOrder.Total += item.Price;
                    }
                    Console.WriteLine("The total is :$" + _newOrder.Total);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    _newOrder = _storeBL.AddOrder(_newOrder);
                    return "MainMenu";
                    case "0":
                        return "MainMenu";
                    default :
                    Console.WriteLine("Page does not exist!");
                    break;
                }
            }
            
        
        return "MainMenu";
    }
}
}