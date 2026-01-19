namespace DogShow.Modules.DTO.User
{
    public class UpdateUserRequest
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
