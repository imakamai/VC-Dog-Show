namespace DogShow.Modules
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

        public Dog(int id, string name, string breed, int age, Gender gender, double weight, double size, byte[] pedigree)
        {
            Id = id;
            Name = name;
            Breed = breed; 
            Age = age;
            Gender = gender;
            Weight = weight; 
            Size = size;
            Pedigree = pedigree;
            
            Forms = new List<FormForDogs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; } 
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; } 
        public double Size { get; set; }
        public byte[] Pedigree { get; set; } 
        public int? OwnerId { get; set; } 
        public virtual Owner Owner { get; set; }

        public int? KennelId { get; set; } 
        public virtual Kennel Kennel { get; set; }

        public virtual ICollection<FormForDogs> Forms { get; set; }


    }
}
