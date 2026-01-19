namespace DogShow.Modules.DTO.User
{
    public class RegisterRequest
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
