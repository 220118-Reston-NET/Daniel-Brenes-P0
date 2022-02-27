using StoreModel;

namespace BL
{
    public interface IStoreBL
    {
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomerById(int p_id);
        List<Customer> SearchCustomerByName(string inputString);
        List<Customer> SearchCustomerByAddress(string inputString);
        List<Customer> SearchCustomerByEmail(string inputString);
        List<Customer> SearchCustomerByPhoneNumber(string inputString);
        List<Customer> GetAllCustomer();
        Task <List<Customer>> GetAllCustomerAsync();
        List<Product> GetAllProducts();
        List<LineItem> GetLineItemByStoreId(int p_id);
        LineItem GetLineItem(int p_id);
        LineItem ReplenishQuantity(int p_id, int p_quantity);
        StoreFront AddStoreFront(StoreFront p_store);
        StoreFront GetStoreFront(int p_id);
        List<StoreFront> GetAllStoreFront();
        Order PlaceOrder(List<LineItem> p_listOfOrder, double p_total, int p_customerId, int p_storefrontid);
        Order AddOrder(Order p_order);
        List<Order> GetAllOrders();
        Customer UpdateCustomer(Customer p_customer);
    }
}