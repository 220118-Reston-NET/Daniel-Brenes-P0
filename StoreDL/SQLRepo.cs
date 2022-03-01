using System.Data.SqlClient;
using StoreModel;

namespace StoreDL
{
    public class SQLRepo : IRepo
    {
        private readonly string _connectionStrings;
        public SQLRepo(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer UpdateCustomer(Customer p_customer)
        {
            string sqlQuery = @"UPDATE Customer
                                SET customerName = @name, customerAddress = @address, customerEmail = @email, customerPhoneNumber = @phoneNumber, = customerWallet = @wallet
                                where customerId = @id;";
            using (SqlConnection con = new SqlConnection (_connectionStrings))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.Parameters.AddWithValue("@name", p_customer.Name);
                com.Parameters.AddWithValue("@address", p_customer.Name);
                com.Parameters.AddWithValue("@email", p_customer.Name);
                com.Parameters.AddWithValue("@phoneNumber", p_customer.Name);
                com.Parameters.AddWithValue("@wallet", p_customer.Name);
                com.Parameters.AddWithValue("@id", p_customer.CustomerId);
            }
            return p_customer;
        }
        
        public Customer AddCustomer(Customer p_customer)
        {
            string sqlQuery = @"insert into Customer 
                            values(@customerName,  @customerAddress, @customerEmail,@customerPhoneNumber, @customerWallet)";
            string sqlQuery2 =  @"insert into CustomerPin 
                                    values(@customerId,  @customerPin)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                // command.Parameters.AddWithValue("@customerID", p_customer.CustomerID);
                command.Parameters.AddWithValue("@customerName", p_customer.Name);
                command.Parameters.AddWithValue("@customerAddress", p_customer.Address);
                command.Parameters.AddWithValue("@customerEmail", p_customer.Email);
                command.Parameters.AddWithValue("@customerPhoneNumber", p_customer.PhoneNumber);
                command.Parameters.AddWithValue("@customerWallet", p_customer.Wallet);
                command.ExecuteScalar();
            }
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery2, con);
                command.Parameters.AddWithValue("@customerId", p_customer.CustomerId);
                command.Parameters.AddWithValue("@customerPin", p_customer.Pin);
                command.ExecuteScalar();
            }

            return p_customer;
        }
        public Order PlaceOrder(List<LineItem> p_lineitemlist, double p_total, int p_customerid, int p_storefrontid)
        {
            Order newOrder = new Order();
            string sqlQuery = @"Insert into Orders
                                    values(@orderId, @total, @storefrontid, @customerid)";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderId" , newOrder.OrderId);
                command.Parameters.AddWithValue("@total" , p_total);
                command.Parameters.AddWithValue("@storefrontid" , p_storefrontid);
                command.Parameters.AddWithValue("@customerid" , p_customerid);
                command.ExecuteScalar();
                
            }
            return newOrder;
        }
        public Order AddOrder(Order p_order)
        {
            Order newOrder = new Order();
            string sqlQuery = @"Insert into Orders
                                    values(@orderId, @total, @storefrontid, @customerid)";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderId" , p_order.OrderId);
                command.Parameters.AddWithValue("@total" , p_order.Total);
                command.Parameters.AddWithValue("@storefrontid" , p_order.StoreFrontId);
                command.Parameters.AddWithValue("@customerid" , p_order.CustomerId);
                command.ExecuteScalar();
            }
            return newOrder;
        }
        public List<Order> GetAllOrders()
        {
            List<Order> listOfOrders = new List<Order>();
            string sqlQuery = @"select * from Orders";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderId = reader.GetInt32(0),
                        Total = (double)reader.GetDecimal(1),
                        StoreFrontId = reader.GetInt32(2),
                        CustomerId = reader.GetInt32(3)
                        });
                }
            }
            return listOfOrders;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> listOfCustomer = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                        listOfCustomer.Add(new Customer(){
                        CustomerId = reader.GetInt32(0), 
                        Name = reader.GetString(1), 
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = (double)reader.GetDecimal(5)
                    });
                }
            }

            return listOfCustomer;
        }
        public List<Customer> SearchCustomer(string inputString)
        { 
            List<Customer> listOfCustomer = new List<Customer>();
            Customer myCustomer = new Customer();

            string sqlQuery = @"select * from Customer
                                    where customerName = @customerName";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerName", inputString);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = reader.GetDouble(5)
                    });
                }
            }
                Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
            return listOfCustomer;
        }
        public List<Customer> SearchCustomerById(int p_id)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            Customer myCustomer = new Customer();

            string sqlQuery = @"select * from Customer
                                    where customerId = @customerId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerId", p_id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = reader.GetDouble(5)
                    });
                }
            }
                Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
            return listOfCustomer;
        }

        public StoreFront AddStoreFront(StoreFront p_store)
        {
            throw new NotImplementedException();
        }
        public StoreFront GetStoreFront(int p_id)
        {
            StoreFront newStoreFront = new StoreFront();
            string sqlQuery = @"select * from StoreFront
                                    where storeFrontId = @storeFrontId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeFrontId" , p_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        
                        newStoreFront.StoreID = reader.GetInt32(0);
                        newStoreFront.Address = reader.GetString(1);
                        newStoreFront.Name = reader.GetString(2);
                        newStoreFront.TypeOfStore = reader.GetString(3);// + p_quantity;
                }
            }
            return newStoreFront;
        }

        public List<StoreFront> GetAllStoreFront()
        {
            List<StoreFront> listOfStoreFront = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                        listOfStoreFront.Add(new StoreFront(){
                        StoreID = reader.GetInt32(0),
                        Name = reader.GetString(1), 
                        Address = reader.GetString(2),
                        TypeOfStore = reader.GetString(3),
                    });
                }
            }
            return listOfStoreFront;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> listOfProduct = new List<Product>();

            string sqlQuery = @"select * from Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                        listOfProduct.Add(new Product(){
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1), 
                        Price = (double)reader.GetDecimal(2),
                        Desc = reader.GetString(3),
                    });
                }
            }

            return listOfProduct;
        }

        public List<Product> GetProductById(int p_id)
        {
            throw new NotImplementedException();
        }

        public List<LineItem> GetLineItemByStoreId(int p_id)
        {
            List<LineItem> listOfLineItem = new List<LineItem>();

            string sqlQuery = @"select * from LineItem
                                    where storeFrontId = @storeFrontId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeFrontId", p_id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                        listOfLineItem.Add(new LineItem(){
                        ProductId = reader.GetInt32(0), 
                        ProductName = reader.GetString(1), 
                        Quantity = reader.GetInt32(2),
                        StoreFrontId = reader.GetInt32(3),
                        Price = (double)reader.GetDecimal(4)

                    });
                }
            }
            return listOfLineItem;
        }
        public LineItem ReplenishQuantity(int p_id, int p_quantity)
        {
            LineItem lineItem = new LineItem();

            string sqlQuery = @"select * from LineItem
                                    where productId = @productId";
            string sqlQuery2 =  @"UPDATE LineItem set quantity = @newQuantity
                                    where productId = @productId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", p_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        
                        lineItem.ProductId = reader.GetInt32(0);
                        lineItem.ProductName = reader.GetString(1);
                        lineItem.Quantity = reader.GetInt32(2);
                        lineItem.StoreFrontId = reader.GetInt32(3);
                        lineItem.Price = (double)reader.GetDecimal(4);
                }
            }
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                lineItem.Quantity = (lineItem.Quantity + p_quantity);
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery2, con);
                command.Parameters.AddWithValue("@productId", p_id);
                command.Parameters.AddWithValue("@newQuantity", lineItem.Quantity);
                command.ExecuteScalar();
            }

            return lineItem;
        }
        public LineItem GetLineItem(int p_id)
        {
            LineItem lineItem = new LineItem();

            string sqlQuery = @"select * from LineItem
                                    where productId = @productId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", p_id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { 
                        lineItem.ProductId = reader.GetInt32(0);
                        lineItem.ProductName = reader.GetString(1);
                        lineItem.Quantity = reader.GetInt32(2);
                        lineItem.StoreFrontId = reader.GetInt32(3);
                        lineItem.Price = (double)reader.GetDecimal(4);
                }
            }
            return lineItem;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            List<Customer> listOfCustomer = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                        listOfCustomer.Add(new Customer(){
                        CustomerId = reader.GetInt32(0), 
                        Name = reader.GetString(1), 
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = (double)reader.GetDecimal(5)
                    });
                }
            }

            return listOfCustomer;
        }

        public List<Order> GetOrderByCustomerId(int p_id)
        {
            List<Order> listOfOrders = new List<Order>();
            string sqlQuery = @"select * from Orders
                                    where customerId = @customerId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerId", p_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderId = reader.GetInt32(0),
                        Total = (double)reader.GetDecimal(1),
                        StoreFrontId = reader.GetInt32(2),
                        CustomerId = reader.GetInt32(3)
                        });
                }
            }
            return listOfOrders;
        }
    }
}