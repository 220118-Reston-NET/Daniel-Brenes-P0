using BL;
using StoreModel;

namespace StoreUI
{
    public class OrderByStore : IMenu
    {
        private static Order _newOrder = new Order();
        private IStoreBL _storeBL;
        private Order _myCart;
        private List<LineItem> _shoppingCart;
        public OrderByStore(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Display()
        {
            _shoppingCart = new List<LineItem>();
            _myCart = new Order();
            List<Customer> listOfCustomer = _storeBL.GetAllCustomer();
            foreach (var item in listOfCustomer)
            {
                Console.WriteLine("================");
                Console.WriteLine(item);
            }
            Console.WriteLine("================");
            Console.Write("Enter the Customer Id : ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            List<StoreFront> listOfStoreFronts = _storeBL.GetAllStoreFront();
            foreach (var item in listOfStoreFronts)
            {
                Console.WriteLine("================");
                Console.WriteLine(item);
            }
            Console.WriteLine("================");
            Console.Write("Enter the Store Id : ");
            int storeId = Convert.ToInt32(Console.ReadLine());

            List<LineItem> listOfLineItem = _storeBL.GetLineItemByStoreId(storeId);
            Console.WriteLine("========== LineItems ==========");
            foreach (var item in listOfLineItem)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Enter the Product Id :");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Quantity to Add to Cart :");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();


        }
        public string UserChoice()
        {

            return "MainMenu";
        }
    }
}