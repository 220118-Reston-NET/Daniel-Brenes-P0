//Updating this file to push to git
namespace StoreModel
{
public class Customer
{
    public string Name{ get; set;}
    public string Address {get; set;}
    private List<Order> _orders;
    public List<Order> Orders
    {
        get {return _orders;}
        set 
        {
            if(value.Count < 0)
            {  
                _orders = value;

            }
            else
            {
                throw new Exception ("Orders is empty");
            }
        }
    }
}
}

