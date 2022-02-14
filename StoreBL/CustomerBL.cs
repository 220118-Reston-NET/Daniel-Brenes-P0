using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepo _repo;
        public CustomerBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            return _repo.AddCustomer(c_customer);

        }
        public List<Customer> SearchCustomer(string inputString)
        {
            return _repo.SearchCustomer(inputString);
        }
        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }
        public List<Customer> SearchCustomerById(int p_id)
        
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();

            //return _repo.SearchCustomerById(p_id);
            return listOfCustomer.Where(customer => customer.CustomerID.Equals(p_id))
                                    .ToList();
        }
    }
}