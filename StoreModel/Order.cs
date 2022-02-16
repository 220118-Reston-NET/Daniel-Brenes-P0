namespace StoreModel
{

    public class Order
    {
        public static int _orderId = 1000;
        public int OrderId{get; set;}
        public int StoreFrontId{get; set;}
        public int CustomerId{get; set;}
        public double Total {get; set;}
        public List<LineItem> _listOfLineItem;
        public List<LineItem> LineItems
        {
        get { return _listOfLineItem; }
        set { }
        }
        public Order()
        {
            OrderId = ++_orderId;
            StoreFrontId = 0;
            CustomerId = 0;
            Total = 0.0;
            _listOfLineItem = new List<LineItem>()
            {
                new LineItem()
            };
        }
        public override string ToString()
        {
            return $"Order Id: {OrderId} \t\t StoreFront Id: {StoreFrontId} \t\tCustomerId: {CustomerId} \t\tTotal: ${Total}";
        }
    }
}