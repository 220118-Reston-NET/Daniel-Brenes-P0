using StoreModel;

namespace StoreDL
{
    public interface IRepo
    {
        Boolean VerifyCustomer(int p_id, string p_pin);
        Boolean VerifyManager(int p_id, string p_pin);
        List<Customer> SearchCustomer(string p_inputString);
        List<Customer> SearchCustomerById(int p_id);
        List<Customer> SearchCustomerByEmail(string p_email);
        // List<Product> GetProductById(int p_id);
        // StoreFront AddStoreFront(StoreFront p_store);
        // StoreFront GetStoreFront(int p_id);
        Order PlaceOrder(Order p_order);
        // Order PlaceOrder(List<LineItem> p_lineitemlist, double p_total, int p_customerid, int p_storefrontid);
        List<Order> GetAllOrders();
        List<Order> GetOrderHistoryByStore(int p_id);
        List<LineItem> GetLineItemByOrderId(int p_orderId);
        List<StoreFront> GetAllStoreFront();
        List<Inventory> GetInventoryByStoreFront(int p_id);
        List<Order> GetOrderHistoryByStoreId(int p_storeId);
        List<Customer> GetAllCustomer();
        Task <List<Customer>> GetAllCustomerAsync();
        Customer AddCustomer(Customer p_customer);
        List<Product> GetAllProducts();
        // List<LineItem> GetLineItemByStoreId(int p_id);
        LineItem GetLineItem(int p_id);
        Inventory ReplenishQuantity(int p_quantity, int p_storeFrontId, int p_productId);
        Customer UpdateCustomer(Customer p_customer);
        List<Order> GetOrderByCustomerId(int p_id);
    }
}