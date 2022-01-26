namespace StoreDL;
public interface IRepository
{
    Customer AddCustomer(Customer p_customer);

    List<Customer> GetAllCustomer();

}
