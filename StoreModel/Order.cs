namespace StoreModel
{
    public class Order
    {
        public int OrderId{get; set;}
        public int StoreFrontId{get; set;}
        public int CustomerId{get; set;}
        public double Total {get; set;}
        public DateTime dateCreated {get; set;}
        private List<LineItem> _listOfLineItem;
        public List<LineItem> LineItems
        {
        get { return _listOfLineItem; }
        set { _listOfLineItem = value;}
        }
        public Order()
        {
            StoreFrontId = 0;
            CustomerId = 0;
            Total = 0.0;
            dateCreated = DateTime.UtcNow;
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