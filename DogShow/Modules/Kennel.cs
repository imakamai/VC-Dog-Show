namespace DogShow.Modules
{
    public class Kennel
    {
        public Kennel()
        {
        }

        public Kennel(int id, string name, Owner owner, string location, string dogsBread, string phone)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Location = location;
            DogsBread = dogsBread;
            this.phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public string Location { get; set; }
        public string DogsBread {  get; set; }
        public string phone { get; set; }


    }
}
