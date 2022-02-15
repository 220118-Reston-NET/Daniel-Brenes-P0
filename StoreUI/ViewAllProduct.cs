using StoreModel;
using BL;

namespace StoreUI
{
    public class ViewAllProduct : IMenu
    {
        private static Product _newProduct = new Product();
        private IStoreBL _productBL;
        public ViewAllProduct(IStoreBL p_productBL)
        {
            _productBL = p_productBL;
        }
        public void Display()
        {
                  List<Product> listOfProduct = _productBL.GetAllProducts();
                    foreach (var item in listOfProduct)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Press 1 To Replenish Inventory");
                    Console.WriteLine("Press 0 To Go Back");
                    
                   
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
                   Console.WriteLine("Please press Enter to continue");
                   Console.ReadLine();
                    return "MainMenu";

            }
        }

    }
}