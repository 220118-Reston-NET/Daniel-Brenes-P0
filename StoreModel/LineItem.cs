namespace StoreModel
{
    public class LineItem
    {
        public int ProductId {get; set;}
        public string ProductName{get; set;}
        public int Quantity{get; set;}
        public int StoreFrontId {get; set;}
        public double Price{get; set;}

        public LineItem()
       {
            
            ProductName = "";
            Quantity = 0;
            StoreFrontId = 0;
            Price = 0.0;
        }
        public override string ToString()
        {
            return $"Id: {ProductId} \t\tName: {ProductName} \t\tQuantity: {Quantity} \t\t StoreFrontId: {StoreFrontId} \t\t Price: {Price}";
        }
    }
}