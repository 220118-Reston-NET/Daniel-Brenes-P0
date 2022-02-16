using System.Data.SqlClient;
using StoreModel;

namespace StoreDL
{
    public class SQLRepo : IRepo
    {
        //SQLRepository now requires you to provide a connectionstring to an existing database to create an object out of it
        //It will also allow SQLRepository to dynamically point to different databases as long as you have the connection string for it
        // Customer AddCustomer(Customer p_customer);
         //Customer SearchCustomer(Customer p_customer);
        //List<Customer> GetAllCustomer();

        private readonly string _connectionStrings;
        public SQLRepo(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer AddCustomer(Customer p_customer)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into Customer 
                            values(@customerName,  @customerAddress, @customerEmail,@customerPhoneNumber, @customerWallet)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs, it will still automatically close any resources
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will how the sqlQuery that will execute on the currently connection we have in the con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                // command.Parameters.AddWithValue("@customerID", p_customer.CustomerID);
                command.Parameters.AddWithValue("@customerName", p_customer.Name);
                command.Parameters.AddWithValue("@customerAddress", p_customer.Address);
                command.Parameters.AddWithValue("@customerEmail", p_customer.Email);
                command.Parameters.AddWithValue("@customerPhoneNumber", p_customer.PhoneNumber);
                command.Parameters.AddWithValue("@customerWallet", p_customer.Wallet);

                //Executes the SQL statement
                command.ExecuteNonQuery();

            }

            return p_customer;
        }
        public Order PlaceOrder(List<LineItem> p_listoflineitem, double p_total, int p_customerid, int p_storefrontid)
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
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                        listOfCustomer.Add(new Customer(){
                        //Zero-based column index
                        CustomerId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
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

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                        listOfCustomer.Add(new Customer(){
                        //Zero-based column index
                        CustomerId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = (double)reader.GetDecimal(5)
                    });
                }
            }

            return listOfCustomer;
        }
        public List<Customer> SearchCustomerById(int p_id)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            Customer myCustomer = new Customer();
            string sqlQuery = @"select customerId, customerName, customerEmail,customerPhoneNumber,customerAddress from Customer";
                           // where customerID = @customerId";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerId", p_id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        //CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        //Wallet = reader.GetDouble(5)
                    });
                }
            }
                Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
            return listOfCustomer;
            // int customerID = p_id;
            // Customer selectionCustomer = new Customer();
            // string sqlQuery = @"select p_id from Customer";

            // using (SqlConnection con = new SqlConnection(_connectionStrings))
            // {
            //     //Opens connection to the database
            //     con.Open();

            //     //Create command object that has our sqlQuery and con object
            //     SqlCommand command = new SqlCommand(sqlQuery, con);

            //     //SqlDataReader is a class specialized in reading outputs that came from a sql statement
            //     //Usually this outputs are in a form of a table and keep that in mind
            //     SqlDataReader reader = command.ExecuteReader();

            //     //Read() methods checks if you have more rows to go through
            //     //If there is another row = true, if not = false
            //     while (reader.Read())
            //     {
            //             listOfCustomer.Add(new Customer(){
            //             //Zero-based column index
            //             CustomerID = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
            //             Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
            //             Address = reader.GetString(2),
            //             Email = reader.GetString(3),
            //             PhoneNumber = reader.GetString(4),
            //             Wallet = reader.GetInt32(5)
            //         });
            //     }
            // }

            // return listOfCustomer;
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
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                        listOfStoreFront.Add(new StoreFront(){
                        //Zero-based column index
                        StoreID = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
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
                //Opens connection to the database
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
                //Opens connection to the database
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
                        StoreFrontId = reader.GetInt32(3)

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
                //Opens connection to the database
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", p_id);
                //command.CommandText = "update LineItem set quantity = @newQuantity where productId = @productId";
    
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        
                        lineItem.ProductId = reader.GetInt32(0);
                        lineItem.ProductName = reader.GetString(1);
                        lineItem.Quantity = reader.GetInt32(2);// + p_quantity;
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
                //Opens connection to the database
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeFrontId", p_id);
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
    }
}