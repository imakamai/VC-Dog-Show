namespace DogShow.Modules.DTO.Dog
{
    public class DogDisplayDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Breed { get; set; }
        public DateOnly Birth { get; set; }
        public int Age { get; set; }
        public required string Gender { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public required string Pedigree { get; set; } 
    }
}
