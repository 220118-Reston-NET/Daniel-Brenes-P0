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
                                SET customerName = @name, customerAddress = @address, customerEmail = @email, customerPhoneNumber = @phoneNumber, customerWallet = @wallet
                                where customerId = @id;";
            using (SqlConnection con = new SqlConnection (_connectionStrings))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.Parameters.AddWithValue("@name", p_customer.Name);
                com.Parameters.AddWithValue("@address", p_customer.Address);
                com.Parameters.AddWithValue("@email", p_customer.Email);
                com.Parameters.AddWithValue("@phoneNumber", p_customer.PhoneNumber);
                com.Parameters.AddWithValue("@wallet", p_customer.Wallet);
                com.Parameters.AddWithValue("@id", p_customer.CustomerId);
            }
            return p_customer;
        }
        
        public Customer AddCustomer(Customer p_customer)
        {
            string sqlQuery = @"insert into Customer 
                            values(@customerName,  @customerAddress, @customerEmail,@customerPhoneNumber, @customerWallet, @customerPin)";


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
                command.Parameters.AddWithValue("@customerPin", p_customer.Pin);
                command.ExecuteScalar();
            }
            // using (SqlConnection con = new SqlConnection(_connectionStrings))
            // {
            //     con.Open();

            //     SqlCommand command = new SqlCommand(sqlQuery3, con);
            //     // command.Parameters.AddWithValue("@customerID", p_customer.CustomerID);
            //     command.Parameters.AddWithValue("@customerName", p_customer.Name);
            //     SqlDataReader reader = command.ExecuteReader();
            //     while (reader.Read())
            //     {
            //             p_customer.CustomerId = reader.GetInt32(0);
            //     }
            // }
            // using (SqlConnection con = new SqlConnection(_connectionStrings))
            // {
            //     con.Open();

            //     SqlCommand command = new SqlCommand(sqlQuery2, con);
            //     command.Parameters.AddWithValue("@customerId", p_customer.CustomerId);
            //     command.Parameters.AddWithValue("@customerPin", p_customer.Pin);
            //     command.ExecuteScalar();
            // }
            

            return p_customer;
        }
        // public Order PlaceOrder(List<LineItem> p_lineitemlist, double p_total, int p_customerid, int p_storefrontid)
        // {
        //     Order newOrder = new Order();
        //     string sqlQuery = @"Insert into Orders
        //                             values(@total, @storefrontid, @customerid)";
        //                             //values(@orderId, @total, @storefrontid, @customerid)";
        //     using (SqlConnection con = new SqlConnection(_connectionStrings))
        //     {
        //         con.Open();
        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         // command.Parameters.AddWithValue("@orderId" , newOrder.OrderId);
        //         command.Parameters.AddWithValue("@total" , p_total);
        //         command.Parameters.AddWithValue("@storefrontid" , p_storefrontid);
        //         command.Parameters.AddWithValue("@customerid" , p_customerid);
        //         command.ExecuteScalar();
        //     }
        //     return newOrder;
        // }   
        public Order PlaceOrder(Order p_order)
        {
            string firstQuery = @"update Inventory
                                        set totalQty = @newQuantity
                                            where productId = @productId and storeFrontId = @storeFrontId";
            List<Inventory> storeInventory = GetInventoryByStoreFront(p_order.StoreFrontId);
            Order badOrder = new Order();
            try
            {
            for(int i =0; i < storeInventory.Count; i++)
            {
                if (storeInventory[i].Quantity < p_order.LineItems[i].Quantity)
                {
                        throw new Exception("Not enough products");
                }
                else
                    storeInventory[i].Quantity -= p_order.LineItems[i].Quantity;
            
            

            // string firstQuery = @"update Inventory
            //                             set totalQty = @newQuantity
            //                                 where productId = @productId and storeFrontId = @storeFrontId";
            // foreach (var item in p_order.LineItems)
            // {
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(firstQuery, con);
                command.Parameters.AddWithValue("@newQuantity" , storeInventory[i].Quantity);
                command.Parameters.AddWithValue("@productId" , storeInventory[i].ProductId);
                command.Parameters.AddWithValue("@storeFrontId" , storeInventory[i].StoreFrontId);
                command.ExecuteScalar();
            }
            }
            }
            catch(System.Exception ex)
            {
                return badOrder;
            }

            // Order newOrder = new Order();
            string sqlQuery = @"Insert into Orders
                                    values(@orderId, @total, @storefrontid, @customerid, @dateTime)";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderId" , p_order.OrderId);
                command.Parameters.AddWithValue("@total" , p_order.Total);
                command.Parameters.AddWithValue("@storefrontid" , p_order.StoreFrontId);
                command.Parameters.AddWithValue("@customerid" , p_order.CustomerId);
                command.Parameters.AddWithValue("@dateTime", p_order.dateCreated);
                command.ExecuteScalar();
            }
            string sqlQuery2 = @"Insert into LineItem
                                    values(@quantity, @orderId, @productId, @subTotal, @productName)";
            foreach (var item in p_order.LineItems)
            {
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery2, con);
                command.Parameters.AddWithValue("@quantity" , item.Quantity);
                command.Parameters.AddWithValue("@orderId" , item.OrderId);
                command.Parameters.AddWithValue("@productId" , item.ProductId);
                command.Parameters.AddWithValue("@subTotal" , item.subTotal);
                command.Parameters.AddWithValue("@productName", item.ProductName);
                command.ExecuteScalar();
            }
            }
            return p_order;
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
        public List<Customer> SearchCustomer(string p_inputString)
        { 
            List<Customer> listOfCustomer = new List<Customer>();
            Customer myCustomer = new Customer();

            string sqlQuery = @"select * from Customer
                                    where customerName contains @customerName";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerName", p_inputString);
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
                // Console.WriteLine("Please press Enter to continue");
                //     Console.ReadLine();
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
            return listOfCustomer;
        }
        public List<Customer> SearchCustomerByEmail(string p_email)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            string sqlQuery = @"select * from Customer
                                    where customerEmail = @customerEmail";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerEmail", p_email);
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
            return listOfCustomer;
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
                        StoreInventory = GetInventoryByStoreFront(reader.GetInt32(0)),
                        Orders = GetOrderHistoryByStoreId(reader.GetInt32(0))
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
            List<Product> listOfProducts = new List<Product>();

            return listOfProducts;
        }

  
        public Inventory ReplenishQuantity(int p_quantity, int p_storeFrontId, int p_productId)
        {
            Inventory updateItem = new Inventory();

            string sqlQuery =  @"update Inventory
                                        set totalQty = @newQuantity
                                            where productId = @productId and storeFrontId = @storeFrontId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@newQuantity", p_quantity);
                command.Parameters.AddWithValue("@storeFrontId", p_storeFrontId);
                command.Parameters.AddWithValue("@productId", p_productId);
                command.ExecuteNonQuery();
                updateItem.Quantity = p_quantity;
                updateItem.StoreFrontId = p_storeFrontId;
                updateItem.ProductId = p_productId;
            return updateItem;
        }
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
                        // lineItem.StoreFrontId = reader.GetInt32(3);
                        lineItem.subTotal = (double)reader.GetDecimal(4);
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
            // string sqlQuery2 = @"select * from LineItem
            //                         where customerId = @customerId";
                                    
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
                        CustomerId = reader.GetInt32(3),
                        dateCreated = reader.GetDateTime(4),
                        LineItems = GetLineItemByOrderId(reader.GetInt32(0))
                        });
                }
            }
            return listOfOrders;
        }

        public bool VerifyCustomer(int p_id, string p_pin)
        {
            Customer myCustomer = new Customer();
            bool returnVal = false;

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
                    if (p_pin.Equals(reader.GetString(6)))
                    {
                        returnVal = true;
                    }
                }
            }
            return returnVal;
        }
        public bool VerifyManager(int p_id, string p_pin)
        {
            Manager currentManager = new Manager();
            bool returnVal = false;

            string sqlQuery = @"select * from StoreManager
                                    where storeManagerId = @p_Id";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@p_id", p_id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (p_pin.Equals(reader.GetString(1)))
                    {
                        returnVal = true;
                    }
                }
            }
            return returnVal;
        }
        public List<LineItem> GetLineItemByOrderId(int p_orderId)
        {
            
            List<LineItem> listOfLineItem = new List<LineItem>();
            
            string sqlQuery = @"select l.orderId , l.productId, l.productName , l.quantity , l.subTotal from Orders o 
                            inner join LineItem l on l.orderId = o.orderId 
                            where o.orderId = @orderId";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderId", p_orderId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfLineItem.Add(new LineItem(){
                        OrderId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        subTotal = (double)reader.GetDecimal(4)
                    });
                }
            }
            return listOfLineItem;

        }

        public List<Inventory> GetInventoryByStoreFront(int p_id)
        {
            List<Inventory> listOfInventory = new List<Inventory>();
            string sqlQuery = @"select i.storeFrontId, i.productId, p.productName, i.totalQty from Inventory i
		                            inner join Product p on i.productId = p.productId
                                    where storeFrontId = @p_id";                
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@p_id", p_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        listOfInventory.Add(new Inventory(){
                        StoreFrontId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Quantity = reader.GetInt32(3)
                        });
                }
            }
            return listOfInventory;
        }

        public List<Order> GetOrderHistoryByStoreId(int p_storeId)
        {
            StoreFront currentStore = new StoreFront();
            List<Order> listOfOrders = new List<Order>();
            string sqlQuery = @"select * from Orders
                                    where storeFrontId = @p_storeId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@p_storeId", p_storeId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderId = reader.GetInt32(0),
                        Total = (double)reader.GetDecimal(1),
                        StoreFrontId = reader.GetInt32(2),
                        CustomerId = reader.GetInt32(3),
                        dateCreated = reader.GetDateTime(4),
                        LineItems = GetLineItemByOrderId(reader.GetInt32(0))
                        });
                }
            }
            return listOfOrders;
        }
        public List<Order> GetOrderHistoryByStore(int p_storeId)
        {
            //StoreFront currentStore = new StoreFront();
            List<Order> listOfOrders = new List<Order>();
            string sqlQuery = @"select * from Orders
                                    where storeFrontId = @p_storeId
                                    order by DATEPART(Day, dateTimeCreated) ASC, total DESC";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@p_storeId", p_storeId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderId = reader.GetInt32(0),
                        Total = (double)reader.GetDecimal(1),
                        StoreFrontId = reader.GetInt32(2),
                        CustomerId = reader.GetInt32(3),
                        dateCreated = reader.GetDateTime(4),
                        LineItems = GetLineItemByOrderId(reader.GetInt32(0))
                        });
                }
            }
            return listOfOrders;
        }
    }
}