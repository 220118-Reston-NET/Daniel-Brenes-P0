using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class ViewAllProduct : IMenu
    {
        private static Product _newProduct = new Product();
        private IProductBL _productBL;
        public ViewAllProduct(IProductBL p_productBL)
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
                   
        }
        public string UserChoice()
        {
            Console.WriteLine("Please press Enter to continue");
            string userInput = Console.ReadLine();

           // switch (userInput)
            {
               
             //   default:
                //    Console.WriteLine("Please press Enter to continue");
               //     Console.ReadLine();
                    return "MainMenu";

            }
        }

    }
}