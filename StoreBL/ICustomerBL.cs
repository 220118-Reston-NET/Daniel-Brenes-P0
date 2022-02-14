using StoreModel;

namespace StoreBL
{
    public interface ICustomerBL
    {
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomerById(int p_id);
        List<Customer> SearchCustomer(string inputString);
        List<Customer> GetAllCustomer();



    }
}