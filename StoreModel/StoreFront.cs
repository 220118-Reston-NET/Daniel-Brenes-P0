namespace StoreModel
{
public class StoreFront
{
    public int StoreID {get; set;}
    public string Name{ get; set;}
    public string Address {get; set;}
    public string TypeOfStore{get; set;}
    private List<Inventory> _storeInventory;
    public List<Inventory> StoreInventory
    {
        get { return _storeInventory; }
        set 
        {
            if(value.Count > 0)
            {
                _storeInventory = value;
            }
            else
            {
                throw new Exception("No Inventory at this location");
            }
        }
    }
    private List<Order> _orders;
    public List<Order> Orders
    {
        get {return _orders;}
        set 
        {
            if(value.Count > 0)
            {
                _orders = value;
            }
            else
            {
                throw new Exception("No orders at this location");
            }
        }
    }
    public StoreFront()
    {
        Name = "";
        Address = "";
        TypeOfStore = "";
        // _storeInventory = new List<Inventory>()
        // {
        //     new Inventory()
        // };
        // _orders = new List<Order>()
        // {
        //     new Order()
        // };
    }
    public override string ToString()
    {
            return $"Store Id: {StoreID}\nName: {Name}\nAddress: {Address}\nType Of Store: {TypeOfStore}\n";
    }
}
}

