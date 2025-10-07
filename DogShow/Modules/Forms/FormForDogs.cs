using DogShow.Modules.Classes;

namespace DogShow.Modules.Forms
{
    public class FormForDogs
    {
        public FormForDogs()
        {
        }

        public FormForDogs(int id, int dogId, Guid userId, Dog dog, User user)
        {
            Id = id;
            DogId = dogId;
            UserId = userId;
            Dog = dog;
            User = user;
        }

        public int Id { get; set; }
        public int DogId { get; set; }
        public Guid UserId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual User User { get; set; }
    }
}
