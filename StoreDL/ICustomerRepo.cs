using StoreModel;

namespace StoreDL;
public interface ICustomerRepo
{
    Customer AddCustomer(Customer p_customer);
    Customer SearchCustomer(Customer p_customer);
    List<Customer> GetAllCustomer();


}
