using StoreModel;

namespace StoreDL
{
    public interface IRepo
    {
        StoreFront AddStoreFront(StoreFront p_store);
        List<StoreFront> GetAllStoreFront();
        List<Customer> GetAllCustomer();
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomer(string p_inputString);
        List<Customer> SearchCustomerById(int p_id);
    }
}