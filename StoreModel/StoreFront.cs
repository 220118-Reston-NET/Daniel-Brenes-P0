//Updating this file to push to git
namespace StoreModel
{
public class StoreFront
{
    public int StoreID {get; set;}
    public string Name{ get; set;}
    public string Address {get; set;}
    public string TypeOfStore{get; set;}
    private List<Product> _products;
    private List<Product> Products{get; set;}
    private List<Order> _orders;
    public List<Order> Orders
    {
        get {return _orders;}
        set 
        {
        }
    }
    public StoreFront()
    {
        Name = "";
        Address = "";
        TypeOfStore = "";

    }
    public override string ToString()
    {
            return $"Name: {Name}\nAddress: {Address}\nType Of Store: {TypeOfStore}\n";
    }
}
}

