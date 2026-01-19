
namespace DogShow.Modules.Forms
{
    public class FormDetailDto
    {
        public int Id { get; set; }
        public string CompetitionClass { get; set; }

        // Dog Info
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public int DogAge { get; set; }
        public string DogPedigree { get; set; }

        // User Info
        public string OwnerName { get; set; } // Name + LastName
        public string OwnerUsername { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }

        // Competition Info
        public string CompetitionName { get; set; }
    }
}
