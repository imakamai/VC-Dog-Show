using DogShow.Modules.Classes;

namespace DogShow.Modules.DTO.Application
{
    public class ApplicationDTO
    {
        public int CompetitionId { get; set; }
        public required string CompetitionClass { get; set; }
        public int? DogId { get; set; }

        public string? Name { get; set; }
        public string? Breed { get; set; }
        public DateOnly? Birth { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public double? Weight { get; set; }
        public double? Size { get; set; }
        public string? Pedigree { get; set; }
    }
}
