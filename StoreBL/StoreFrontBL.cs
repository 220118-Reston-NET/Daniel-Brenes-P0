using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontRepo _repo;
        public StoreFrontBL(IStoreFrontRepo p_repo)
        {
            _repo = p_repo;
        }
        public StoreFront AddStoreFront(StoreFront p_store)
        {
            return p_store;

        }
    }
}