using DogShow.Modules.Forms;

namespace DogShow.Modules.Classes
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Dog
    {
        public Dog()
        {
            Forms = new List<FormForDogs>();
        }

        public Dog(int id, string name, string breed, int age, Gender gender, double weight, double size, string pedigree, ICollection<FormForDogs> forms)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Age = age;
            Gender = gender;
            Weight = weight;
            Size = size;
            Pedigree = pedigree;
            Forms = forms;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateOnly BirthDate { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public double? Weight { get; set; }
        public double? Size { get; set; }
        public string Pedigree { get; set; }
        public virtual ICollection<FormForDogs> Forms { get; set; }
    }
}