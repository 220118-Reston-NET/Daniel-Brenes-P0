namespace StoreModel
{
    public class Inventory
    {
        public int ProductId {get; set;}
        public string ProductName{get; set;}
        public int Quantity{get; set;}
        public int StoreFrontId {get; set;}

        public Inventory()
       {
            ProductName = "";
            Quantity = 0;
            ProductId = 0;
            StoreFrontId = 0;
       }

    }
}