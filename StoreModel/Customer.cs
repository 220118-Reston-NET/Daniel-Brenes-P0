//Updating this file to push to git
namespace StoreModel
{
public class Customer
{
    public int CustomerId {get; set;}
    public string Name{ get; set;}
    public string Address {get; set;}
    public string Email {get; set;}
    public string PhoneNumber{get; set;}
    public double Wallet{ get; set;}

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
                throw new Exception ("Order is empty");
            }
        }
    }
    public Customer()
    {
        Name = "";
        Address = "";
        Email = "";
        PhoneNumber = "";
        Wallet = 0.0;

    }
    public override string ToString()
    {
            return $"Id: {CustomerId}\nName: {Name}\nAddress: {Address}\nEmail: {Email}\nPhoneNumber: {PhoneNumber}\nWallet: ${Wallet}";
    }
}
}

