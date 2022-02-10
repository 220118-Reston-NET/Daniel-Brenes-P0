using System.Text.Json;
using StoreModel;

namespace StoreDL
{


    public class StoreFrontRepo : IStoreFrontRepo
    {
        private string _filepath = "../StoreDL/Database/";
        private string _jsonString;

        public StoreFront AddStoreFront(StoreFront p_store)
        {
            string path = _filepath + "StoreFront.json";
            List<StoreFront> listOfStoreFront = new List<StoreFront>();
            listOfStoreFront.Add(p_store);

            _jsonString = JsonSerializer.Serialize(p_store, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString);

            return p_store;

        }
        public List<StoreFront> GetAllStoreFront()
        {
            _jsonString = File.ReadAllText(_filepath + "StoreFront.json");

            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }
    }
}