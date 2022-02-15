namespace StoreModel
{
    public class Product
    {
        public int ProductId{get; set;}
        public string Name{get; set;}
        public double Price{get; set;}
        public string Desc{get; set;}
        public Product()
        {
            Name = "";
            Price = 0.0;
            Desc = "";
        }
        public override string ToString()
        {
         return $"Name: {Name}\nPrice: {Price}\nDescription: {Desc}\n";
        }
    }

}