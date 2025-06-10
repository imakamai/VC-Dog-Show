namespace DogShow.Modules
{
    public class Competitionncs
    {
        public Competitionncs()
        {
        }

        public Competitionncs(int id, string title, DateOnly acquisitionDate, TimeOnly acquisitionTime, string acquisitionPlace, Judge judge)
        {
            Id = id;
            Title = title;
            AcquisitionDate = acquisitionDate;
            AcquisitionTime = acquisitionTime;
            AcquisitionPlace = acquisitionPlace;
            Judge = judge;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly AcquisitionDate { get; set; }
        public TimeOnly AcquisitionTime { get; set; }
        public string AcquisitionPlace {  get; set; }
        public Judge Judge { get; set; }
    }
}
