using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IRepo _repo;
        public StoreFrontBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public StoreFront AddStoreFront(StoreFront p_store)
        {
            return p_store;

        }
        public StoreFront GetStoreFront(int p_id)
        {
            return _repo.GetStoreFront(p_id);
        }
        public List<StoreFront> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
    }
}