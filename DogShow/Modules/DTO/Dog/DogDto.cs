using DogShow.Modules.Classes;

namespace DogShow.Modules.DTO.Dog
{
    public class DogDTO
    {
        public required string Name { get; set; }
        public required string Breed { get; set; }
        public DateOnly Birth {  get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double? Weight { get; set; }
        public double? Size { get; set; }
        public required string Pedigree { get; set; }
    }
}
