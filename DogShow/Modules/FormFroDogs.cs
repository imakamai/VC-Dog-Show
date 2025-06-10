namespace DogShow.Modules
{
    public class FormFroDogs
    {
        public FormFroDogs()
        {
        }

        public FormFroDogs(int id, Dog dog, User user)
        {
            Id = id;
            Dog = dog;
            User = user;
        }

        public int Id { get; set; }
        public Dog Dog { get; set; }
        public User User { get; set; }
    }
}
