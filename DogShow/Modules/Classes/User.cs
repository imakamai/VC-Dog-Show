namespace DogShow.Modules.Classes
{
    public class User : Person
    {
        public User()
        {
        }

        public User(int id, string name, string lastName, string email, string phone, string address, string city, string postalCode, string state) : base(id, name, lastName, email, phone, address, city, postalCode, state)
        {
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
