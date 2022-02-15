using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IRepo _repo;
        public ProductBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public List<Product> GetProductByStoreId(int p_id)
        {
            List<Product> listOfProduct = _repo.GetAllProducts();
            //listOfProduct = listOfProduct.Where(product => product.StoreId.Equals(p_id))
              //                      .ToList();
             if (listOfProduct.Count> 0)
                return listOfProduct;
            else   
                throw new Exception("No products found with that ID");  

        }
        public List<Product> GetAllProducts()
        {
            List<Product> listOfProduct = _repo.GetAllProducts();
           // listOfProduct = listOfProduct.Where(product => product.StoreId.Equals(p_id))
                        //            .ToList();
                return listOfProduct;
            

        }
    }
}