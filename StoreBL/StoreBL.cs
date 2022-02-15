using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class StoreBL : IStoreBL
    {
        private IRepo _repo;
        public StoreBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            throw new NotImplementedException();
        }

        public StoreFront AddStoreFront(StoreFront p_store)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAllStoreFront()
        {
            throw new NotImplementedException();
        }

        public List<LineItem> GetLineItemByStoreId(int p_id)
        {
            throw new NotImplementedException();
        }

        public StoreFront GetStoreFront(int p_id)
        {
            throw new NotImplementedException();
        }

        public LineItem ReplenishQuantity(int p_id, int p_quantity)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomerByAddress(string inputString)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomerByEmail(string inputString)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomerById(int p_id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomerByName(string inputString)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomerByPhoneNumber(string inputString)
        {
            throw new NotImplementedException();
        }
    }
}