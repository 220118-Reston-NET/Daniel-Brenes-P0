using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class AddCustomerMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static Customer _newCustomer = new Customer();
        private IStoreBL _customerBL;
        public AddPokeMenu(IStoreBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter Pokemon information");
            Console.WriteLine("[3] Name - " + _newPoke.Name);
            Console.WriteLine("[2] Level - " + _newPoke.Level);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    _pokeBL.AddPokemon(_newPoke);
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a level!");
                    _newPoke.Level = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "3": 
                    Console.WriteLine("Please enter a name!");
                    _newPoke.Name = Console.ReadLine();
                    return "AddPokemon";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddPokemon";

            }
        }

    }
}