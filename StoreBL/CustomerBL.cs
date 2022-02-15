using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepo _repo;
        public CustomerBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            return _repo.AddCustomer(c_customer);

        }
        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
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