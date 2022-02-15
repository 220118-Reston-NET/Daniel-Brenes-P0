namespace StoreModel
{

    public class Order
    {
        public int OrderId{get; set;}
        public int StoreFrontId{get; set;}

        public double Total {get; set;}
        private string _orderList;
        public string OrderList 
        {
            get {return _orderList;}
            set
            {
                if (_orderList.Length > 0)
                {
                    _orderList = value;
                }
                else
                throw new System.Exception("Empty List");
            }
        }
        

    }
}