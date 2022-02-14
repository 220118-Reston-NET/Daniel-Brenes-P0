using System.Data.SqlClient;
using StoreModel;

namespace StoreDL
{
    public class SQLStoreFront : IStoreFrontRepo
    {
        //SQLRepository now requires you to provide a connectionstring to an existing database to create an object out of it
        //It will also allow SQLRepository to dynamically point to different databases as long as you have the connection string for it
        // Customer AddCustomer(Customer p_customer);
         //Customer SearchCustomer(Customer p_customer);
        //List<Customer> GetAllCustomer();

        private readonly string _connectionStrings;
        public SQLStoreFront(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer AddStoreFront(StoreFront p_storefront)
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

        // public List<Ability> GetAbilitiesByPokeId(int p_pokeId)
        // {
        //     List<Ability> listOfAbility = new List<Ability>();
            
        //     string sqlQuery = @"select a.abId ,a.abName , a.abPP , a.abPower , a.abAccuracy from Pokemon p 
        //                     inner join pokemons_abilities pa on p.pokeId = pa.pokeId 
        //                     inner join Ability a on a.abId = pa.abId 
        //                     where p.pokeId = @pokeId";
            
        //     using (SqlConnection con = new SqlConnection(_connectionStrings))
        //     {
        //         con.Open();

        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         command.Parameters.AddWithValue("@pokeId", p_pokeId);

        //         SqlDataReader reader = command.ExecuteReader();

        //         while (reader.Read())
        //         {
        //             listOfAbility.Add(new Ability(){
        //                 //Reader column is NOT based on table structure but based on what your select query statement is displaying
        //                 AbId = reader.GetInt32(0),
        //                 Name = reader.GetString(1),
        //                 PP = reader.GetInt32(2),
        //                 Power = reader.GetInt32(3),
        //                 Accuracy = reader.GetInt32(4)
        //             });
        //         }
        //     }
        //     return listOfAbility;
        // }

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
                        CustomerID = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Wallet = reader.GetInt32(5)
                    });
                }
            }

            return listOfCustomer;
        }
    }
}