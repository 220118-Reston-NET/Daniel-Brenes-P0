using StoreModel;

namespace StoreBL
{
    public interface IStoreFrontBL
    {
        StoreFront AddStoreFront(StoreFront p_store);
        StoreFront GetStoreFront(int p_id);
        List<StoreFront> GetAllStoreFront();
        List<Product> GetAllProducts();
    }
}