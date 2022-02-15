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
            string sqlQuery = @"select customerID, customerName, customerEmail,customerPhoneNumber,customerAddress from Customer";
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
                        //Zero-based column index
                        ProductId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
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
    }
}