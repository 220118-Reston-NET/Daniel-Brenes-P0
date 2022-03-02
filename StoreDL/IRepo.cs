using StoreModel;

namespace StoreDL
{
    public interface IRepo
    {
        /// <summary>
        /// Verifies Customer Pin matches Customer Id
        /// </summary>
        /// <param name="p_id"> Customer Id</param>
        /// <param name="p_pin"> Customer Pin</param>
        /// <returns> True if Valid </returns>
        Boolean VerifyCustomer(int p_id, string p_pin);
        /// <summary>
        /// Verifies Manager Pin matches Manager Id
        /// </summary>
        /// <param name="p_id"> Manager Id</param>
        /// <param name="p_pin">Manager Pin</param>
        /// <returns> True if Valid </returns>
        Boolean VerifyManager(int p_id, string p_pin);
        /// <summary>
        /// Searches customer By email
        /// </summary>
        /// <param name="p_email"> customer email</param>
        /// <returns> The list of customers</returns>
        List<Customer> SearchCustomerByEmail(string p_email);
        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="p_order"> The order to be placed </param>
        /// <returns></returns>
        Order PlaceOrder(Order p_order);
        /// <summary>
        /// Gets a list of orders
        /// </summary>
        /// <returns> The List of orders</returns>
        List<Order> GetAllOrders();
        /// <summary>
        /// Gets Line Items By Order Id
        /// </summary>
        /// <param name="p_orderId"> the OrderId</param>
        /// <returns> The List of Line items </returns>
        List<LineItem> GetLineItemByOrderId(int p_orderId);
        /// <summary>
        /// Gets All StoreFronts
        /// </summary>
        /// <returns> List of Store Fronts </returns>
        List<StoreFront> GetAllStoreFront();
        /// <summary>
        /// Gets Inventory by Store
        /// </summary>
        /// <param name="p_id"> StoreFront id </param>
        /// <returns> The List of Inventory </returns>
        List<Inventory> GetInventoryByStoreFront(int p_id);
        /// <summary>
        /// Gets Order History by Store
        /// </summary>
        /// <param name="p_storeId"> The Store Id</param>
        /// <returns> The List of Orders </returns>
        List<Order> GetOrderHistoryByStoreId(int p_storeId);
        /// <summary>
        /// Gets All Customers
        /// </summary>
        /// <returns> The List of Customers </returns>
        List<Customer> GetAllCustomer();
        /// <summary>
        /// Task List based on await
        /// </summary>
        /// <returns></returns>
        Task <List<Customer>> GetAllCustomerAsync();
        /// <summary>
        /// Adds a customer to the databse
        /// </summary>
        /// <param name="p_customer"> The customer to add</param>
        /// <returns> The added customer </returns>
        Customer AddCustomer(Customer p_customer);
        List<Product> GetAllProducts();
        LineItem GetLineItem(int p_id);
        Inventory ReplenishQuantity(int p_quantity, int p_storeFrontId, int p_productId);
        Customer UpdateCustomer(Customer p_customer);
        List<Order> GetOrderByCustomerId(int p_id);
    }
}