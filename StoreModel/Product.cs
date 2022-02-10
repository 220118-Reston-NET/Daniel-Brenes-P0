namespace StoreModel
{

    public class Product
    {
        public int ProductId{get; set;}
        public string ProductName{get; set;}
        public double ProductPrice{get; set;}
        public string ProductDesc{get; set;}

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