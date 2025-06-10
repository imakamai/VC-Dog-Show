namespace DogShow.Modules
{
    public class Judge : Person
    {
        public Judge()
        {
        }

        public Judge(int id, string name, string lastName, string email, string phone, string address, string city, string postalCode, string state) : base(id, name, lastName, email, phone, address, city, postalCode, state)
        {
        }

        public int Id { get; set; }
    }
}
