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

