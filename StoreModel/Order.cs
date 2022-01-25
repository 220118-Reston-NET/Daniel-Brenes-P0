namespace StoreModel
{

    public class Order
    {
        private string _orderList;
        public string OrderList 
        {
            get {return _orderlist;}
            set
            {
                if (!_orderList.IsNullOrEmpty())
                {
                    _orderList = value;
                }
                else
                throw new System.Exception("Empty List");
            }
        }
        

    }
}