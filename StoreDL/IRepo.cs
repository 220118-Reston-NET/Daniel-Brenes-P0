using StoreModel;

namespace StoreDL
{
    public interface IRepo
    {
        Boolean VerifyCustomer(string p_id, string p_pin);
        List<Customer> SearchCustomer(string p_inputString);
        List<Customer> SearchCustomerById(int p_id);
        // List<Product> GetProductById(int p_id);
        // StoreFront AddStoreFront(StoreFront p_store);
        // StoreFront GetStoreFront(int p_id);
        Order AddOrder(Order p_order);
        Order PlaceOrder(List<LineItem> p_lineitemlist, double p_total, int p_customerid, int p_storefrontid);
        List<Order> GetAllOrders();
        List<Order> GetOrderHistoryByStoreId(int p_storeId);
        List<Order> GetOrderHistoryByStore(int p_id);
        List<LineItem> GetLineItemByOrderId(int p_orderId);
        List<StoreFront> GetAllStoreFront();
        List<Inventory> GetInventoryByStoreFront(int p_id);
        List<Customer> GetAllCustomer();
        Task <List<Customer>> GetAllCustomerAsync();
        Customer AddCustomer(Customer p_customer);
        List<Product> GetAllProducts();
        // List<LineItem> GetLineItemByStoreId(int p_id);
        LineItem GetLineItem(int p_id);
        LineItem ReplenishQuantity(int p_id, int p_quantity);
        Customer UpdateCustomer(Customer p_customer);
        List<Order> GetOrderByCustomerId(int p_id);
    }
}