using DogShow.Modules.Classes;

namespace DogShow.Modules.DTO.Dog
{
    public class DogDTO
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public string Pedigree { get; set; }
    }
}
