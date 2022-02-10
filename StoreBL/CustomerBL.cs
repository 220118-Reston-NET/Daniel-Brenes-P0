using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepo _repo;
        public CustomerBL(ICustomerRepo p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            return c_customer;

        }
    }
}