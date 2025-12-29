namespace DogShow.Modules.DTO.Competition
{
    public class CompetitionDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly AcquisitionDate { get; set; }
        public TimeOnly AcquisitionTime { get; set; }
        public string AcquisitionPlace { get; set; } = string.Empty;
        public DateOnly ApplicationDeadline { get; set; }
    }
}
