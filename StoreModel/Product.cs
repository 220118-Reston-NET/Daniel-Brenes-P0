namespace StoreModel
{

    public class Product
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public double Price{get; set;}
        public string Desc{get; set;}

        //public int ProductQuantity{get; set;}

        public Product()
        {
            Name = "";
            Price = 0;
            Desc = "";
        }
        public override string ToString()
        {
         return $"Name: {Name}\nPrice: {Price}\nDescription: {Desc}\n";
        }
    }

}