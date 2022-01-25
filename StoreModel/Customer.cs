namespace StoreModel
{
public class Customer
{
    public string Name{ get; set;}
    public string Address {get; set;}
       private List<Order> _orders;
    public List<Ability> Abilities
    {
        get {return _abilities;}
        set 
        {
            if(value.Count < 4)
            {  
                _abilities = value;

            }
            else
            {
                throw new Exception ("Pokemon cannot hold more than 4 abilities!");
            }
        }
    }
}
}

