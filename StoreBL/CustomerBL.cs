using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(ICustomerRepository p_repo)
        {
            _repo = p_repo;
        }
    }
}