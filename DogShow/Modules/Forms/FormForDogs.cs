using DogShow.Modules.Classes;

namespace DogShow.Modules.Forms
{
    public class FormForDogs
    {
        public FormForDogs()
        {
        }

        public FormForDogs(int id, Dog dog, User user)
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
