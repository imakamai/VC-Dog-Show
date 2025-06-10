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
        }

        public Dog(int id, string name, string bread, int age, Gender gender, double wieght, double size, byte[] pedigre, Competitionncs competitionncs)
        {
            Id = id;
            Name = name;
            Bread = bread;
            Age = age;
            Gender = gender;
            Wieght = wieght;
            Size = size;
            Pedigre = pedigre;
            Competitionncs = competitionncs;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Bread {  get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Wieght { get; set; }
        public double Size { get; set; }
        public byte[] Pedigre { get; set; }
        public Competitionncs Competitionncs { get; set; }
    }
}
