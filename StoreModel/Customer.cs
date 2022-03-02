namespace StoreModel
{
public class Customer
{
    public int CustomerId {get; set;}
    public string Name{ get; set;}
    public string Address {get; set;}
    public string Email {get; set;}
    public string PhoneNumber{get; set;}
    private double _wallet;
    public double Wallet
    {
    get { return _wallet; }
    set 
        {
            if(_wallet >= 0)
            {
                _wallet = value;
            }
            else
            {
                throw new Exception("Wallet cannot be negative");
            }
        }
    }
    public string Pin { get; set;}
    public Customer()
    {
        Name = "";
        Address = "";
        Email = "";
        PhoneNumber = "";
        Wallet = 0.0;
        Pin = "";

    }
    public override string ToString()
    {
            return $"Id: {CustomerId}\nName: {Name}\nAddress: {Address}\nEmail: {Email}\nPhoneNumber: {PhoneNumber}\nWallet: ${Wallet}";
    }
}
}

