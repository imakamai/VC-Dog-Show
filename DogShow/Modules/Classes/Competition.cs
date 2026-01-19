namespace DogShow.Modules.Classes
{
    public class Competition
    {
        public Competition()
        {
            Judges = new List<Judge>();
        }

        public Competition(int id, string title, DateOnly acquisitionDate, TimeOnly acquisitionTime, string acquisitionPlace, List<Judge> judges)
        {
            Id = id;
            Title = title;
            AcquisitionDate = acquisitionDate;
            AcquisitionTime = acquisitionTime;
            AcquisitionPlace = acquisitionPlace;
            Judges = judges;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly AcquisitionDate { get; set; }
        public TimeOnly AcquisitionTime { get; set; }
        public string AcquisitionPlace {  get; set; } = string.Empty;
        public List<Judge>? Judges { get; set; }
        public DateOnly ApplicationDeadline { get; set; }

    }
}
