namespace DogShow.Modules.DTO.Dog
{
    public class DogDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateOnly Birth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public string Pedigree { get; set; } 
    }
}
