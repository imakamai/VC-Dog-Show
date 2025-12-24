namespace DogShow.Modules.Classes
{
    public enum RewardTypeByBreedClass
    {
        CAC, //Candidate for National Beauty Champion
        CACIB, //Candidate for International Beauty Champion
        RCAC, // Reserve Candidate for National Beauty Champion
        RCACIB, // Reserve Candidate for International Beauty Champion
        PRM, // Prize of the Breed
        JuniorWinner, // Junior Winner
        VeteranWinner, // Veteran Winner
        BOS, //Best Opposite Sex
        WD, 
        WB

    }

    public enum RewardTypeByTheHonor
    {
        BOB, // Best of Breed
        BOG, // Best of Group
        BIS, // Best in Show
        JuniorBIS, // Junior Best in Show
        VeteranBIS, // Veteran Best in Show
        BestCouple, // Best Couple
        BestProgenyGroup // Best Progeny Group
    }

    public class Reward
    {

        public Reward() { }

        

        public int Id { get; set; }
        public string Name { get; set; }
        public RewardTypeByBreedClass rewardTypeByBreedClass { get; set; }
        public RewardTypeByTheHonor rewardTypeByTheHonor { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
    }
}
