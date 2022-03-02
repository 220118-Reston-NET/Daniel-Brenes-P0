using StoreModel;

namespace BL
{
    public interface IStoreBL
    {
        Boolean VerifyCustomer(int p_id, string p_pin);
        Boolean VerifyManager(int p_id, string p_pin);
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomerById(int p_id);
        List<Customer> SearchCustomerByName(string inputString);
        List<Customer> SearchCustomerByAddress(string inputString);
        List<Customer> SearchCustomerByEmail(string inputString);
        List<Customer> SearchCustomerByPhoneNumber(string inputString);
        List<Customer> GetAllCustomer();
        List<Inventory> GetInventoryByStoreFront(int p_id);
        Task <List<Customer>> GetAllCustomerAsync();
        List<Product> GetAllProducts();
        List<LineItem> GetLineItemByOrderId(int p_id);
        LineItem GetLineItem(int p_id);
        Inventory ReplenishQuantity(int p_quantity, int p_storeId, int p_id);
        List<StoreFront> GetAllStoreFront();
        Order PlaceOrder(Order p_order);
        List<Order> GetAllOrders();
        List<Order> GetOrderByCustomerId(int p_id);
        List<Order> GetOrderHistoryByStoreId(int p_id);
        Customer UpdateCustomer(Customer p_customer);
    }
}