using StoreModel;

namespace StoreBL
{
    public interface IProductBL
    {
       // List<Product> GetProductByStoreId(int p_id);
        List<Product> GetAllProducts();
    }
}