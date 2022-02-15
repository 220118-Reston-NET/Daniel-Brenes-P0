using StoreModel;

namespace StoreBL
{
    public interface ICustomerBL
    {
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomerById(int p_id);
        List<Customer> SearchCustomerByName(string inputString);
        List<Customer> SearchCustomerByAddress(string inputString);
        List<Customer> SearchCustomerByEmail(string inputString);
        List<Customer> SearchCustomerByPhoneNumber(string inputString);
        List<Customer> GetAllCustomer();
        



    }
}