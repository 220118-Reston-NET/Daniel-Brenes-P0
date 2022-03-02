using StoreModel;
using StoreDL;

namespace BL
{
    public class StoreBL : IStoreBL
    {
        private IRepo _repo;
        public StoreBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }
        public List<Order> GetAllOrders()
        {
            List<Order> myOrders = _repo.GetAllOrders();
            
            return _repo.GetAllOrders();
        }
        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> listOfProduct = _repo.GetAllProducts();
           // listOfProduct = listOfProduct.Where(product => product.StoreId.Equals(p_id))
                        //            .ToList();
                return listOfProduct;
        }
        public List<StoreFront> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }
        public LineItem GetLineItem(int p_id)
        {
            return _repo.GetLineItem(p_id);
        }
        public Inventory ReplenishQuantity(int p_storeId, int p_id, int p_quantity)
        {
            Inventory updateItem = _repo.ReplenishQuantity(p_storeId, p_id, p_quantity);

            return updateItem;
        }
       public List<Customer> SearchCustomerById(int p_id)
        
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.CustomerId.Equals(p_id))
                                    .ToList();
             if (listOfCustomer.Count > 0)
                return listOfCustomer;
            else   
                throw new Exception("No customers found with that ID");                       
        }
        public List<Customer> SearchCustomerByName(string inputString)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.Name.Contains(inputString))
                                    .ToList();
            if (listOfCustomer.Count > 0) 
               { 
               return listOfCustomer;
               }            
            else
                {
                    throw new Exception("No Customers found with that Name");
                }
        }
        public List<Customer> SearchCustomerByAddress(string inputString)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.Address.Contains(inputString))
                                    .ToList();
            if (listOfCustomer.Count > 0) 
               { 
               return listOfCustomer;
               }            
            else
                {
                    throw new Exception("No Customers found with that Address");
                }                 
        }
        public List<Customer> SearchCustomerByEmail(string inputString)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.Email.Contains(inputString))
                                    .ToList();
            if (listOfCustomer.Count > 0) 
               { 
               return listOfCustomer;
               }            
            else
                {
                    throw new Exception("No Customers found with that Email");
                }
        }
        public List<Customer> SearchCustomerByPhoneNumber(string inputString)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.PhoneNumber.Contains(inputString))
                                    .ToList();
            if (listOfCustomer.Count > 0) 
               { 
               return listOfCustomer;
               }            
            else
                {
                    throw new Exception("No Customers found with that Phone Number");
                }
        }
        public Customer UpdateCustomer(Customer p_customer)
        {
            return _repo.UpdateCustomer(p_customer);
        }
        public Order PlaceOrder(Order p_order)
        {
            return _repo.PlaceOrder(p_order);
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _repo.GetAllCustomerAsync();
        }

        public List<Order> GetOrderByCustomerId(int p_id)
        {
            return _repo.GetOrderByCustomerId(p_id);
        }
        public bool VerifyCustomer(int p_id, string p_pin)
        {
            return _repo.VerifyCustomer(p_id, p_pin);
        }

        public List<LineItem> GetLineItemByOrderId(int p_id)
        {
            return _repo.GetLineItemByOrderId(p_id);
        }

        public List<Inventory> GetInventoryByStoreFront(int p_id)
        {
            return _repo.GetInventoryByStoreFront(p_id);
        }

        public List<Order> GetOrderHistoryByStoreId(int p_id)
        {
            return _repo.GetOrderHistoryByStoreId(p_id);
        }

        public bool VerifyManager(int p_id, string p_pin)
        {
            return _repo.VerifyManager(p_id, p_pin);
        }
    }
}