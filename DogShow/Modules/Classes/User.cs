namespace DogShow.Modules.Classes
{
    public class User 
    {
        public User()
        {
        }

        public User(Guid id, string username, string password, string name, string lastName, string email, string phone, string address, string city, string postalCode, string state)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            PostalCode = postalCode;
            State = state;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
    }
}
