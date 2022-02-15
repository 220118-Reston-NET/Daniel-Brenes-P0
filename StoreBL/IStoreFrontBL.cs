using StoreModel;

namespace StoreBL
{
    public interface IStoreFrontBL
    {
        StoreFront AddStoreFront(StoreFront p_store);
        List<StoreFront> GetAllStoreFront();
    }
}