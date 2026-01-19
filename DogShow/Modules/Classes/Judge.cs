namespace DogShow.Modules.Classes
{
    public class Judge
    {
        public Judge()
        {
        }

        public Judge(Guid id, string name, string lastName, int age, int yearsOfExperience)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            YearsOfExperience = yearsOfExperience;
        }

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
