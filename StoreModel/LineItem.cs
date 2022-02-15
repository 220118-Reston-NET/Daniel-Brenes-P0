namespace StoreModel
{
    public class LineItem
    {
        public int ProductId {get; set;}
        public string ProductName{get; set;}
        public int Quantity{get; set;}


        public LineItem()
       {
            ProductId = 0;
            ProductName = "";
            Quantity = 0;
        }
        public override string ToString()
        {
            return $"Id: {ProductId} \t\tName: {ProductName} \t\tQuantity: {Quantity}";
        }
    }
}