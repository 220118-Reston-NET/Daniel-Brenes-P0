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

        public StoreFront AddStoreFront(StoreFront p_store)
        {
            throw new NotImplementedException();
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

        public List<LineItem> GetLineItemByStoreId(int p_id)
        {
            List<LineItem> listOfLineItem =  _repo.GetLineItemByStoreId(p_id);
            //listOfLineItem = listOfLineItem.Where(lineitem => lineitem.ProductId.Equals(p_id))
            //                        .ToList();
             if (listOfLineItem.Count> 0)
                return listOfLineItem;
            else   
                throw new Exception("No Line Items found with that ID"); 
        }

        public StoreFront GetStoreFront(int p_id)
        {
            return _repo.GetStoreFront(p_id);
        }

        public LineItem ReplenishQuantity(int p_id, int p_quantity)
        {
            LineItem lineItem = _repo.ReplenishQuantity(p_id, p_quantity);

            return lineItem;
        }

       public List<Customer> SearchCustomerById(int p_id)
        
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            listOfCustomer = listOfCustomer.Where(customer => customer.CustomerId.Equals(p_id))
                                    .ToList();
             if (listOfCustomer.Count> 0)
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

            //return _repo.SearchCustomerById(p_id);
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
    }
}