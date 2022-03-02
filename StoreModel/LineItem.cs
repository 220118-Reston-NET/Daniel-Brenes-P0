namespace StoreModel
{
    public class LineItem
    {
        public int OrderId{get; set;}
        public int ProductId {get; set;}
        public string ProductName{get; set;}
        public int Quantity{get; set;}
        public double subTotal {get; set;}

        public LineItem()
       {
            ProductName = "";
            Quantity = 0;
            ProductId = 0;
            subTotal = 0.0;
        }
        public override string ToString()
        {
            return $"Id: {ProductId} \t\tName: {ProductName} \t\tQuantity: {Quantity} \t\t SubTotal: {subTotal}";
        }
    }
}