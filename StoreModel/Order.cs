namespace StoreModel
{

    public class Order
    {
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