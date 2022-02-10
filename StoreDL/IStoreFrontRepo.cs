using StoreModel;

namespace StoreDL;
public interface IStoreFrontRepo
{
    StoreFront AddStoreFront(StoreFront p_store);

    List<StoreFront> GetAllStoreFront();
    

}
