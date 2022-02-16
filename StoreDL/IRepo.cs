using StoreModel;

namespace StoreDL
{
    public interface IRepo
    {
        StoreFront AddStoreFront(StoreFront p_store);
        StoreFront GetStoreFront(int p_id);
        Order PlaceOrder(List<LineItem> p_lineitemlist, double p_total, int p_customerid, int p_storefrontid);
        List<Order> GetAllOrders();
        List<StoreFront> GetAllStoreFront();
        List<Customer> GetAllCustomer();
        Customer AddCustomer(Customer p_customer);
        List<Customer> SearchCustomer(string p_inputString);
        List<Customer> SearchCustomerById(int p_id);
        List<Product> GetAllProducts();
        List<Product> GetProductById(int p_id);
        List<LineItem> GetLineItemByStoreId(int p_id);
        LineItem ReplenishQuantity(int p_id, int p_quantity);
    }
}