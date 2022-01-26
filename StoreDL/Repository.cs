using System.Text.Json;

namespace PokeDL
{


    public class Repository : IRepository
    {
        private string _filepath = "../StoreDL/Database/";
        private string _jsonString;

        public Customer AddCustomer(Customer p_customer)
        {
            string path = _filepath + "Customer.json";
            List<Customer> listOfCustomer = new List<Customer>();
            listOfCustomer.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(p_customer, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString);

            return p_customer;

        }
        public List<Customer> GetAllCustomer()
        {
            _jsonString = File.ReadAllText(_filepath + "Customer.json");

            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
    }
}